package tcpsocket

import (
	"encoding/gob"
	"log"
	"net"
	"strings"
	"os"
	"time"

	detector "github.com/uis-dat520-s18/glabs/grouplab1/detector"
	paxos "github.com/uis-dat520-s18/glabs/grouplab2/singlepaxos"
)



var NATIVE_CONN_ADDR string 

const (
	NW_CONN_PROTO = "tcp"       
	TCP_CONN_PORT = "29170"     
	DELTA         = time.Second 
)

var ClusterOfThree = []int{0, 1, 2}

var clusterAddrConns = map[string]net.Conn{
	"152.94.1.110": nil,
	"152.94.1.111": nil,
	"152.94.1.113": nil,
}

var MapOfIPAddrNodeIDs = map[string]int{
	"152.94.1.110": 0,
	"152.94.1.111": 1,
	"152.94.1.113": 2,
}

var mapOfNodeIDsIPAddr = map[int]string{
	0: "152.94.1.110",
	1: "152.94.1.111",
	2: "152.94.1.113",
}

type DistributedSrv struct {
	id            int                     
	srvListener   *net.TCPListener        
	Fd            *detector.EvtFailureDetector 
	hbOut         chan detector.Heartbeat      
	msgSrvIn      chan ClMessage          
	msgSrvOut     chan ClMessage          
	clNodeIDConn  map[int]net.Conn       
	extClAddrConn map[string]net.Conn    
	Proposer      *paxos.Proposer          
	Acceptor      *paxos.Acceptor          
	Learner       *paxos.Learner           
	prepareOut    chan paxos.Prepare       
	acceptOut     chan paxos.Accept        
	promiseOut    chan paxos.Promise       
	learnOut      chan paxos.Learn         
	chosenValOut  chan paxos.Value         
	sentChosenVal bool                    // suppress duplicate chosen value from learner
	stop          chan bool               
}

type DistributedCl struct {
	id                int                 
	serverIPAddrConns map[string]net.Conn 
	msgClIn           chan ClMessage      
	msgClOut          chan ClMessage      
	stop              chan bool           
}

type commProto struct {
	MsgType    string // REQ_HB, RES_HB, PREPARE, PROMISE, ACCEPT, LEARN, EXTCLVALUE
	FromNodeID int    
	ToNodeID   int    
	Rnd        int    
	Val        string 
	Vrnd       int    
	Request    bool   
}

type ClMessage struct {
	clCommProto commProto
	clConn      net.Conn
}

func GetIPAddr() string {
	addrs, err := net.InterfaceAddrs()
	if err != nil {
		os.Stderr.WriteString("Error: " + err.Error() + "\n")
		os.Exit(1)
	}

	for _, a := range addrs {
		if ipnet, ok := a.(*net.IPNet); ok && !ipnet.IP.IsLoopback() {
			if ipnet.IP.To4() != nil {
				return ipnet.IP.String()
			}
		}
	}
	return ""
}

func InitServer(ld *detector.MonLeaderDetector, msgIn chan ClMessage, msgOut chan ClMessage,
	proposer *paxos.Proposer, acceptor *paxos.Acceptor, learner *paxos.Learner,
	prpOut chan paxos.Prepare, accOut chan paxos.Accept, promOut chan paxos.Promise,
	lrnValOut chan paxos.Learn, chValOut chan paxos.Value,
) (*DistributedSrv, error) {

	log.SetFlags(log.Ldate | log.Ltime)

	NATIVE_CONN_ADDR = GetIPAddr()

	hbOut := make(chan detector.Heartbeat, 16)
	fd := detector.NewEvtFailureDetector(MapOfIPAddrNodeIDs[NATIVE_CONN_ADDR], ClusterOfThree, ld, DELTA, hbOut)

	srvResAddr, err := net.ResolveTCPAddr(NW_CONN_PROTO, NATIVE_CONN_ADDR+":"+TCP_CONN_PORT)
	if err != nil {
		return nil, err
	}

	srvListener, err_lis := net.ListenTCP(NW_CONN_PROTO, srvResAddr)
	if err_lis != nil {
		return nil, err_lis
	}

	srvHandle := DistributedSrv{
		id:            MapOfIPAddrNodeIDs[NATIVE_CONN_ADDR],
		srvListener:   srvListener,
		Fd:            fd,
		hbOut:         hbOut,
		msgSrvIn:      msgIn,
		msgSrvOut:     msgOut,
		clNodeIDConn:  make(map[int]net.Conn),
		extClAddrConn: make(map[string]net.Conn),
		Proposer:      proposer,
		Acceptor:      acceptor,
		Learner:       learner,
		prepareOut:    prpOut,
		acceptOut:     accOut,
		promiseOut:    promOut,
		learnOut:      lrnValOut,
		chosenValOut:  chValOut,
		stop:          make(chan bool),
	}

	return &srvHandle, nil
}

func (srv *DistributedSrv) Start() {
	go srv.srvHandleNewClientConn()
	var clNewMsg ClMessage

	go func() {
		for {
			select {
			case clNewMsg = <-srv.msgSrvIn:
				srv.srvHandlePeerInMsg(clNewMsg)
			case <-srv.stop:
				return
			}
		}
	}()
}

func (srv *DistributedSrv) Stop() {
	srv.stop <- true
}

func (srv *DistributedSrv) srvHandleNewClientConn() {
	go srv.srvHandleThisNodeOutMsg()

	for {
		clConn, err := srv.srvListener.Accept()
		if err != nil {
			clConn = nil
		} else {
			clIPAddr := strings.Split(clConn.RemoteAddr().String(), ":")

			if _, ok := MapOfIPAddrNodeIDs[clIPAddr[0]]; !ok && srv.extClAddrConn[clIPAddr[0]] == nil {
				srv.extClAddrConn[clIPAddr[0]] = clConn
				go srv.srvRecvExtClMsg(clIPAddr[0], clConn)
			} else {
				srv.clNodeIDConn[MapOfIPAddrNodeIDs[clIPAddr[0]]] = clConn
				go srv.srvRecvPeerMsg(clIPAddr[0], clConn)
			}
		}
	}
}

func (srv *DistributedSrv) srvNotifyChosenValue(chVal string) {
	for extClAddr, extClConn := range srv.extClAddrConn {
		if extClConn != nil {
			extClData := commProto{MsgType: "CHVALUE", FromNodeID: srv.id, Val: chVal}
			clWriteGob := gob.NewEncoder(extClConn)
			err := clWriteGob.Encode(extClData)
			if err != nil {
				extClConn.Close()
				srv.extClAddrConn[extClAddr] = nil
			}
		}
	}
}

func (srv *DistributedSrv) srvRecvPeerMsg(peerClAddr string, peerClConn net.Conn) {
	for {
		var clData commProto
		clReadGob := gob.NewDecoder(peerClConn)
		err := clReadGob.Decode(&clData)
		if err != nil {
			peerClConn.Close()
			srv.clNodeIDConn[MapOfIPAddrNodeIDs[peerClAddr]] = nil
			return
		}

		if len(clData.MsgType) > 0 {
			srv.msgSrvIn <- ClMessage{clCommProto: clData, clConn: nil}
		}
	}
}

func (srv *DistributedSrv) srvRecvExtClMsg(peerClAddr string, peerClConn net.Conn) {
	for {
		var clData commProto
		clReadGob := gob.NewDecoder(peerClConn)
		err := clReadGob.Decode(&clData)
		if err != nil {
			peerClConn.Close()
			srv.extClAddrConn[peerClAddr] = nil
			return
		}

		if len(clData.MsgType) > 0 {
			srv.msgSrvIn <- ClMessage{clCommProto: clData, clConn: nil}
		}
	}
}

func (srv *DistributedSrv) srvHandlePeerInMsg(clNewMsg ClMessage) {
	switch clNewMsg.clCommProto.MsgType {
	case "REQ_HB": 
		hbReq := detector.Heartbeat{From: clNewMsg.clCommProto.FromNodeID, To: clNewMsg.clCommProto.ToNodeID, Request: true}
		srv.Fd.DeliverHeartbeat(hbReq)
	case "RES_HB": 
		hbReply := detector.Heartbeat{From: clNewMsg.clCommProto.FromNodeID, To: clNewMsg.clCommProto.ToNodeID, Request: false}
		srv.Fd.DeliverHeartbeat(hbReply)
	case "PREPARE": 
		prepareIn := paxos.Prepare{From: clNewMsg.clCommProto.FromNodeID, Crnd: paxos.Round(clNewMsg.clCommProto.Rnd)}
		srv.Acceptor.DeliverPrepare(prepareIn)
	case "PROMISE": 
		promiseIn := paxos.Promise{
			To:   clNewMsg.clCommProto.ToNodeID,
			From: clNewMsg.clCommProto.FromNodeID,
			Rnd:  paxos.Round(clNewMsg.clCommProto.Rnd),
			Vrnd: paxos.Round(clNewMsg.clCommProto.Vrnd),
			Vval: paxos.Value(clNewMsg.clCommProto.Val),
		}
		srv.Proposer.DeliverPromise(promiseIn)
	case "ACCEPT": 
		acceptIn := paxos.Accept{From: clNewMsg.clCommProto.FromNodeID, Rnd: paxos.Round(clNewMsg.clCommProto.Rnd), Val: paxos.Value(clNewMsg.clCommProto.Val)}
		srv.Acceptor.DeliverAccept(acceptIn)
	case "LEARN": 
		learnIn := paxos.Learn{From: clNewMsg.clCommProto.FromNodeID, Rnd: paxos.Round(clNewMsg.clCommProto.Rnd), Val: paxos.Value(clNewMsg.clCommProto.Val)}
		srv.Learner.DeliverLearn(learnIn)
	case "EXTCLVALUE": 
		srv.Proposer.DeliverClientValue(paxos.Value(clNewMsg.clCommProto.Val))
		srv.sentChosenVal = false
	}
}

func (srv *DistributedSrv) srvHandleThisNodeOutMsg() {
	hbFD := detector.Heartbeat{To: -1, From: -1, Request: false}
	prepareOut := paxos.Prepare{From: int(paxos.NoRound), Crnd: paxos.NoRound}
	promiseOut := paxos.Promise{To: int(paxos.NoRound), From: int(paxos.NoRound), Rnd: paxos.NoRound, Vrnd: paxos.NoRound, Vval: paxos.ZeroValue}
	acceptOut := paxos.Accept{From: int(paxos.NoRound), Rnd: paxos.NoRound, Val: paxos.ZeroValue}
	learnOut := paxos.Learn{From: int(paxos.NoRound), Rnd: paxos.NoRound, Val: paxos.ZeroValue}
	var valOut paxos.Value
	var clData commProto

	for {
		select {
		case hbFD = <-srv.hbOut:
			if hbFD.Request { 
				if hbFD.From == hbFD.To {
					hbReply := detector.Heartbeat{From: hbFD.From, To: hbFD.To, Request: false}
					srv.Fd.DeliverHeartbeat(hbReply) 
				} else {
					clData = commProto{MsgType: "REQ_HB", FromNodeID: hbFD.From, ToNodeID: hbFD.To}
					srv.msgSrvOut <- ClMessage{clCommProto: clData, clConn: nil} 
				}
			} else { 
				clData = commProto{MsgType: "RES_HB", FromNodeID: hbFD.From, ToNodeID: hbFD.To}
				if srv.clNodeIDConn[hbFD.To] != nil {
					clReadGob := gob.NewEncoder(srv.clNodeIDConn[hbFD.To])
					err := clReadGob.Encode(&clData)
					if err != nil {
						srv.clNodeIDConn[hbFD.To].Close()
						srv.clNodeIDConn[hbFD.To] = nil
					}
				}
			}
		case prepareOut = <-srv.prepareOut:
			srv.Acceptor.DeliverPrepare(prepareOut) 
			clData = commProto{MsgType: "PREPARE", FromNodeID: prepareOut.From, Rnd: int(prepareOut.Crnd)}
			srv.msgSrvOut <- ClMessage{clCommProto: clData, clConn: nil} 
		case promiseOut = <-srv.promiseOut:
			if srv.id == promiseOut.To {
				srv.Proposer.DeliverPromise(promiseOut) 
			} else {
				clData = commProto{MsgType: "PROMISE", FromNodeID: promiseOut.From, ToNodeID: promiseOut.To, Rnd: int(promiseOut.Rnd), Vrnd: int(promiseOut.Vrnd), Val: string(promiseOut.Vval)}
				srv.msgSrvOut <- ClMessage{clCommProto: clData, clConn: nil} 
			}
		case acceptOut = <-srv.acceptOut:
			srv.Acceptor.DeliverAccept(acceptOut) 
			clData = commProto{MsgType: "ACCEPT", FromNodeID: acceptOut.From, Rnd: int(acceptOut.Rnd), Val: string(acceptOut.Val)}
			srv.msgSrvOut <- ClMessage{clCommProto: clData, clConn: nil} 
		case learnOut = <-srv.learnOut:
			srv.Learner.DeliverLearn(learnOut) 
			clData = commProto{MsgType: "LEARN", FromNodeID: learnOut.From, Rnd: int(learnOut.Rnd), Val: string(learnOut.Val)}
			srv.msgSrvOut <- ClMessage{clCommProto: clData, clConn: nil} 
		case valOut = <-srv.chosenValOut:
			if !srv.sentChosenVal {
				srv.srvNotifyChosenValue(string(valOut))
				srv.sentChosenVal = true
			}
		}
	}
}
