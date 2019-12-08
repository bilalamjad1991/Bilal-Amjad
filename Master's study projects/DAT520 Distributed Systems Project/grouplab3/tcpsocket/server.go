package tcpsocket

import (
	"container/list"
	"encoding/gob"
	dtr "github.com/uis-dat520-s18/glabs/grouplab1/detector"
	bank "github.com/uis-dat520-s18/glabs/grouplab3/bank"
	mlpx "github.com/uis-dat520-s18/glabs/grouplab3/multipaxos"
	"io"
	"log"
	"net"
	"os"
	"strings"
	"time"
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
	Fd            *dtr.EvtFailureDetector
	msgSrvIn      chan ClMessage
	msgSrvOut     chan ClMessage
	clNodeIDConn  map[int]net.Conn
	extClAddrConn map[string]net.Conn
	Proposer      *mlpx.Proposer
	Acceptor      *mlpx.Acceptor
	Learner       *mlpx.Learner
	sendClVal     bool
	curLeader     int
	adu           int
	srvCh         SrvChannels
	usrAccnt      map[int]bank.Account
	clValInList   *list.List
	dcdValInList  *list.List
	stop          chan struct{}
}

type SrvChannels struct {
	HbOut        chan dtr.Heartbeat
	PrepareOut   chan mlpx.Prepare
	AcceptOut    chan mlpx.Accept
	PromiseOut   chan mlpx.Promise
	LearnOut     chan mlpx.Learn
	ChosenValOut chan mlpx.DecidedValue
	SrvLdrIn     chan int
}

// Client data
type DistributedCl struct {
	id                int
	serverIPAddrConns map[string]net.Conn
	msgClIn           chan ClMessage
	msgClOut          chan ClMessage
	stop              chan struct{}
}

type commProto struct {
	MsgType     string
	FromNodeID  int
	ToNodeID    int
	SlotID      int
	Rnd         int
	Val         mlpx.Value
	Slots       []mlpx.PromiseSlot
	IPAddr      string
	TxnResponse mlpx.Response
	StateType   int
	Request     bool
}

type ClMessage struct {
	clCommProto commProto
	clConn      net.Conn
}

func GetIPAddr() string {
	addrs, err := net.InterfaceAddrs()
	if err != nil {
		os.Stderr.WriteString("Oops: " + err.Error() + "\n")
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

func InitServer(ld *dtr.MonLeaderDetector, msgIn chan ClMessage, msgOut chan ClMessage,
	proposer *mlpx.Proposer, acceptor *mlpx.Acceptor, learner *mlpx.Learner, srvChannel SrvChannels) (*DistributedSrv, error) {

	log.SetFlags(log.Ldate | log.Ltime)

	NATIVE_CONN_ADDR = GetIPAddr()

	hbOut := make(chan dtr.Heartbeat, 16)
	fd := dtr.NewEvtFailureDetector(MapOfIPAddrNodeIDs[NATIVE_CONN_ADDR], ClusterOfThree, ld, DELTA, hbOut)
	srvChannel.HbOut = hbOut

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
		msgSrvIn:      msgIn,
		msgSrvOut:     msgOut,
		clNodeIDConn:  make(map[int]net.Conn),
		extClAddrConn: make(map[string]net.Conn),
		Proposer:      proposer,
		Acceptor:      acceptor,
		Learner:       learner,
		sendClVal:     true,
		curLeader:     MapOfIPAddrNodeIDs[NATIVE_CONN_ADDR],
		adu:           0,
		srvCh:         srvChannel,
		usrAccnt:      make(map[int]bank.Account),
		clValInList:   list.New(),
		dcdValInList:  list.New(),
		stop:          make(chan struct{}),
	}

	return &srvHandle, nil
}

// Main start point for server
func (srv *DistributedSrv) Start() {
	go srv.srvHandleNewClientConn()
	var clNewMsg ClMessage

	go func() {
		for {
			select {
			case clNewMsg = <-srv.msgSrvIn:
				go srv.srvHandlePeerInMsg(clNewMsg)
			case <-srv.stop:
				return
			}
		}
	}()
}

func (srv *DistributedSrv) Stop() {
	srv.stop <- struct{}{}
}

func (srv *DistributedSrv) srvHandleNewClientConn() {
	go srv.srvHandleThisNodeOutMsg()

	for {
		clConn, err := srv.srvListener.Accept()
		if err != nil {
			clConn = nil
		} else {
			clIPAddr := strings.Split(clConn.RemoteAddr().String(), ":")

			if _, ok := MapOfIPAddrNodeIDs[clIPAddr[0]]; !ok {
				srv.extClAddrConn[clIPAddr[0]] = clConn
				go srv.srvRecvExtClMsg(clIPAddr[0], clConn)
			} else {
				srv.clNodeIDConn[MapOfIPAddrNodeIDs[clIPAddr[0]]] = clConn
				go srv.srvRecvPeerMsg(clIPAddr[0], clConn)
			}
		}
	}
}

func (srv *DistributedSrv) srvSendTxnResponse(txnResponse mlpx.Response) {
	extClConn := srv.extClAddrConn[txnResponse.ClientID]
	if extClConn != nil {
		extClData := commProto{MsgType: "TRANSACTION_RESULT", FromNodeID: srv.id, TxnResponse: txnResponse}
		clWriteGob := gob.NewEncoder(extClConn)
		err := clWriteGob.Encode(extClData)
		if err == io.EOF {
			extClConn.Close()
			srv.extClAddrConn[txnResponse.ClientID] = nil
		}
	}
}

func (srv *DistributedSrv) srvRecvPeerMsg(peerClAddr string, peerClConn net.Conn) {
	for {
		if peerClConn != nil {
			clData := new(commProto)
			clReadGob := gob.NewDecoder(peerClConn)
			err := clReadGob.Decode(&clData)
			if err == io.EOF {
				peerClConn.Close()
				srv.clNodeIDConn[MapOfIPAddrNodeIDs[peerClAddr]] = nil
				return
			} else if err == nil {
				if len(clData.MsgType) > 0 {
					srv.msgSrvIn <- ClMessage{clCommProto: *clData, clConn: nil}
				}
			}
		}
	}
}

func (srv *DistributedSrv) srvRecvExtClMsg(peerClAddr string, peerClConn net.Conn) {
	for {
		if peerClConn != nil {
			clData := new(commProto)
			clReadGob := gob.NewDecoder(peerClConn)
			err := clReadGob.Decode(&clData)
			if err == io.EOF {
				peerClConn.Close()
				srv.extClAddrConn[peerClAddr] = nil
				return
			} else if err == nil {
				if srv.curLeader != srv.id {
					extClData := commProto{MsgType: "REDIRECT", FromNodeID: srv.id}
					extClData.IPAddr = mapOfNodeIDsIPAddr[srv.curLeader]
					clWriteGob := gob.NewEncoder(peerClConn)
					err := clWriteGob.Encode(extClData)
					if err == io.EOF || err == nil {
						time.Sleep(5 * time.Millisecond)
						peerClConn.Close()
						srv.extClAddrConn[peerClAddr] = nil
						return
					}
				} else {
					if len(clData.MsgType) > 0 {
						srv.msgSrvIn <- ClMessage{clCommProto: *clData, clConn: nil}
					}
				}
			}
		}
	}
}

func (srv *DistributedSrv) srvHandleDecidedValue(dcdVal mlpx.DecidedValue) {
	if int(dcdVal.SlotID) > (srv.adu + 1) {
		srv.dcdValInList.PushBack(dcdVal)
		return
	}

	if !dcdVal.Value.Noop {
		usrAccnt, ok := srv.usrAccnt[dcdVal.Value.AccountNum]
		if !ok {
			usrAccnt = bank.Account{Number: dcdVal.Value.AccountNum, Balance: 0}
			srv.usrAccnt[dcdVal.Value.AccountNum] = usrAccnt
		}

		txnResult := usrAccnt.Process(dcdVal.Value.Txn)
		srv.usrAccnt[dcdVal.Value.AccountNum] = usrAccnt

		txnResponse := mlpx.Response{dcdVal.Value.ClientID, dcdVal.Value.ClientSeq, txnResult}
		if srv.curLeader == srv.id {
			srv.srvSendTxnResponse(txnResponse)
		}
	}

	srv.adu++
	srv.Proposer.IncrementAllDecidedUpTo()

	if srv.dcdValInList.Len() > 0 {
		newDcdVal := srv.dcdValInList.Front().Value.(mlpx.DecidedValue)
		srv.dcdValInList.Remove(srv.dcdValInList.Front())
		srv.srvHandleDecidedValue(newDcdVal)
	}
}

func (srv *DistributedSrv) srvHandlePeerInMsg(clNewMsg ClMessage) {
	switch clNewMsg.clCommProto.MsgType {
	case "REQ_HB":
		hbReq := dtr.Heartbeat{From: clNewMsg.clCommProto.FromNodeID, To: clNewMsg.clCommProto.ToNodeID, Request: true}
		srv.Fd.DeliverHeartbeat(hbReq)
	case "RES_HB":
		hbReply := dtr.Heartbeat{From: clNewMsg.clCommProto.FromNodeID, To: clNewMsg.clCommProto.ToNodeID, Request: false}
		srv.Fd.DeliverHeartbeat(hbReply)
	case "PREPARE":
		prepareIn := mlpx.Prepare{From: clNewMsg.clCommProto.FromNodeID, Slot: mlpx.SlotID(clNewMsg.clCommProto.SlotID), Crnd: mlpx.Round(clNewMsg.clCommProto.Rnd)}
		srv.Acceptor.DeliverPrepare(prepareIn)
	case "PROMISE":
		promiseIn := mlpx.Promise{
			To:    clNewMsg.clCommProto.ToNodeID,
			From:  clNewMsg.clCommProto.FromNodeID,
			Rnd:   mlpx.Round(clNewMsg.clCommProto.Rnd),
			Slots: clNewMsg.clCommProto.Slots,
		}
		srv.Proposer.DeliverPromise(promiseIn)
	case "ACCEPT":
		acceptIn := mlpx.Accept{From: clNewMsg.clCommProto.FromNodeID, Slot: mlpx.SlotID(clNewMsg.clCommProto.SlotID), Rnd: mlpx.Round(clNewMsg.clCommProto.Rnd), Val: mlpx.Value(clNewMsg.clCommProto.Val)}
		srv.Acceptor.DeliverAccept(acceptIn)
	case "LEARN":
		learnIn := mlpx.Learn{From: clNewMsg.clCommProto.FromNodeID, Slot: mlpx.SlotID(clNewMsg.clCommProto.SlotID), Rnd: mlpx.Round(clNewMsg.clCommProto.Rnd), Val: mlpx.Value(clNewMsg.clCommProto.Val)}
		srv.Learner.DeliverLearn(learnIn)
	case "EXTCLVALUE":
		srv.clValInList.PushBack(clNewMsg.clCommProto.Val)
		srv.Proposer.DeliverClientValue(mlpx.Value(clNewMsg.clCommProto.Val))
	}
}

func (srv *DistributedSrv) srvHandleThisNodeOutMsg() {
	var gotLeader int

	for {
		select {
		case hbFD := <-srv.srvCh.HbOut:
			if hbFD.Request {
				if hbFD.From == hbFD.To {
					hbReply := dtr.Heartbeat{From: hbFD.From, To: hbFD.To, Request: false}
					srv.Fd.DeliverHeartbeat(hbReply)
				} else {
					clData := commProto{MsgType: "REQ_HB", FromNodeID: hbFD.From, ToNodeID: hbFD.To}
					srv.msgSrvOut <- ClMessage{clCommProto: clData, clConn: nil}
				}
			} else {
				clData := commProto{MsgType: "RES_HB", FromNodeID: hbFD.From, ToNodeID: hbFD.To}
				if srv.clNodeIDConn[hbFD.To] != nil {
					clWriteGob := gob.NewEncoder(srv.clNodeIDConn[hbFD.To])
					err := clWriteGob.Encode(clData)
					if err == io.EOF {
						log.Printf("[NTW/Server]: srvHandleThisNodeOutMsg() [%v] NodeID [%d]\n", err.Error(), hbFD.To)
						srv.clNodeIDConn[hbFD.To].Close()
						srv.clNodeIDConn[hbFD.To] = nil
					}
				}
			}
		case prepareOut := <-srv.srvCh.PrepareOut:
			srv.Acceptor.DeliverPrepare(prepareOut)
			clData := commProto{MsgType: "PREPARE", FromNodeID: prepareOut.From, SlotID: int(prepareOut.Slot), Rnd: int(prepareOut.Crnd)}
			srv.msgSrvOut <- ClMessage{clCommProto: clData, clConn: nil}
		case promiseOut := <-srv.srvCh.PromiseOut:
			if srv.id == promiseOut.To {
				srv.Proposer.DeliverPromise(promiseOut)
			} else {
				clData := commProto{MsgType: "PROMISE", FromNodeID: promiseOut.From, ToNodeID: promiseOut.To, Rnd: int(promiseOut.Rnd), Slots: promiseOut.Slots}
				srv.msgSrvOut <- ClMessage{clCommProto: clData, clConn: nil}
			}
		case acceptOut := <-srv.srvCh.AcceptOut:
			srv.Acceptor.DeliverAccept(acceptOut)
			clData := commProto{MsgType: "ACCEPT", FromNodeID: acceptOut.From, SlotID: int(acceptOut.Slot), Rnd: int(acceptOut.Rnd), Val: acceptOut.Val}
			srv.msgSrvOut <- ClMessage{clCommProto: clData, clConn: nil}
		case learnOut := <-srv.srvCh.LearnOut:
			srv.Learner.DeliverLearn(learnOut)
			clData := commProto{MsgType: "LEARN", FromNodeID: learnOut.From, SlotID: int(learnOut.Slot), Rnd: int(learnOut.Rnd), Val: learnOut.Val}
			srv.msgSrvOut <- ClMessage{clCommProto: clData, clConn: nil}
		case dcdVal := <-srv.srvCh.ChosenValOut:
			srv.srvHandleDecidedValue(dcdVal)
		case gotLeader = <-srv.srvCh.SrvLdrIn:
			srv.curLeader = gotLeader
		}
	}
}
