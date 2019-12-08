package tcpsocket

import (
	"encoding/gob"
	"fmt"
	"log"
	"net"
	"os"
	"strings"
	"time"

	"github.com/uis-dat520-s18/glabs/grouplab1/detector"
)

var LOCAL_ADDR string

const (
	PORT  = "29170"     // TCP server port
	DELTA = time.Second // timeout
)

var ClusterOfThree = []int{0, 1, 2}

var mapOfIPAddrNodeIDs = map[string]int{
	"152.94.1.100": 0,
	"152.94.1.152": 1,
	"152.94.1.154": 2,
}

type DistributedSrv struct {
	srvListener  *net.TCPListener
	Fd           *detector.EvtFailureDetector
	hbOut        chan detector.Heartbeat
	msgSrvIn     chan ClMessage
	msgSrvOut    chan ClMessage
	clNodeIDConn map[int]net.Conn
	stop         chan bool
}

type commProto struct {
	MsgType    string // REQ_HB, RES_HB
	FromNodeID int    // id of client
	ToNodeID   int    // id of server
	Request    bool   // true -> request, false -> reply
}

type ClMessage struct {
	clCommProto commProto
	clConn      net.Conn
}

func InitServer(ld *detector.MonLeaderDetector, msgIn chan ClMessage, msgOut chan ClMessage) (*DistributedSrv, error) {
	log.SetFlags(log.Ldate | log.Ltime)
	LOCAL_ADDR = GetIPAddr()
	hbOut := make(chan detector.Heartbeat, 16)
	fd := detector.NewEvtFailureDetector(mapOfIPAddrNodeIDs[LOCAL_ADDR], ClusterOfThree, ld, DELTA, hbOut)

	service := LOCAL_ADDR + ":" + PORT
	tcpAddr, err := net.ResolveTCPAddr("tcp", service)
	checkError(err)
	listener, err := net.ListenTCP("tcp", tcpAddr)
	checkError(err)

	srvHandle := DistributedSrv{
		srvListener:  listener,
		Fd:           fd,
		hbOut:        hbOut,
		msgSrvIn:     msgIn,
		msgSrvOut:    msgOut,
		clNodeIDConn: make(map[int]net.Conn),
		stop:         make(chan bool),
	}

	return &srvHandle, nil
}

func (srv *DistributedSrv) StartServer() {
	go srv.HandleNewClientConn()
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

func (srv *DistributedSrv) StopServer() {
	srv.stop <- true
}

func (srv *DistributedSrv) HandleNewClientConn() {
	go srv.srvHandleThisNodeOutMsg()

	for {
		clConn, err := srv.srvListener.Accept()
		if err != nil {
			clConn = nil
		} else {
			clIPAddr := strings.Split(clConn.RemoteAddr().String(), ":")
			srv.clNodeIDConn[mapOfIPAddrNodeIDs[clIPAddr[0]]] = clConn

			go srv.srvRecvPeerMsg(clIPAddr[0], clConn)
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
			srv.clNodeIDConn[mapOfIPAddrNodeIDs[peerClAddr]] = nil
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
	}
}

func (srv *DistributedSrv) srvHandleThisNodeOutMsg() {
	hbFD := detector.Heartbeat{To: -1, From: -1, Request: false}
	var clData commProto

	for {
		select {
		case hbFD = <-srv.hbOut:
			if hbFD.Request {
				if hbFD.From == hbFD.To { // HB request to this node
					hbReply := detector.Heartbeat{From: hbFD.From, To: hbFD.To, Request: false}
					srv.Fd.DeliverHeartbeat(hbReply) // Deliver HB reply to this node
				} else { // Deliver HB request to peer node
					clData = commProto{MsgType: "REQ_HB", FromNodeID: hbFD.From, ToNodeID: hbFD.To}
					srv.msgSrvOut <- ClMessage{clCommProto: clData, clConn: nil}
				}
			} else { // HB response to peer node
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
		}
	}
}

// Get localhost IPv4 address
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

func checkError(err error) {
	if err != nil {
		fmt.Fprintf(os.Stderr, "Fatal error: %s", err.Error())
		os.Exit(1)
	}
}
