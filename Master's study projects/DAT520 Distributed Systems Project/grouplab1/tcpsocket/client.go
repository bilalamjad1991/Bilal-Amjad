package tcpsocket

import (
	"encoding/gob"
	"log"
	"net"
	"time"
)

type ClientData struct {
	srvConn           net.Conn
	serverIPAddrConns map[string]net.Conn //// node and its conn handle
	msgClIn           chan ClMessage      // Channel for message from server
	msgClOut          chan ClMessage      // Channel for message to server
	stop              chan bool           // indicator to stop the start run loop
}

var nodesAddrConns = map[string]net.Conn{
	"152.94.1.100": nil,
	"152.94.1.152": nil,
	"152.94.1.154": nil,
}

var dictNodeIDsIPAddr = map[int]string{
	0: "152.94.1.100",
	1: "152.94.1.152",
	2: "152.94.1.154",
}

func InitClient(msgIn chan ClMessage, msgOut chan ClMessage) (*ClientData, error) {
	log.SetFlags(log.Ldate | log.Ltime)

	LOCAL_ADDR = GetIPAddr()

	clHandle := ClientData{
		srvConn:           nil,
		msgClIn:           msgIn,
		msgClOut:          msgOut,
		serverIPAddrConns: nodesAddrConns,
		stop:              make(chan bool),
	}

	return &clHandle, nil
}

func (c *ClientData) StartClient() {
	go c.connectServers()
	var msgClOut ClMessage

	go func() {
		for {
			select {
			case msgClOut = <-c.msgClOut:
				c.clHandleOutgoingMsg(msgClOut)
			case <-c.stop:
				return
			}
		}
	}()
}

func (c *ClientData) StopClient() {
	c.stop <- true
}

func (c *ClientData) connectServers() {
	for {
		for srvHost, conn := range c.serverIPAddrConns {
			if conn == nil {
				peerSrvConn, err := net.Dial("tcp", srvHost+":"+PORT)
				if err != nil {
				} else {
					if srvHost == LOCAL_ADDR {
						c.srvConn = peerSrvConn
					}

					c.serverIPAddrConns[srvHost] = peerSrvConn
					go c.clHandleIncomingMsg(mapOfIPAddrNodeIDs[srvHost], srvHost, peerSrvConn)
				}
			}
		}

		time.Sleep(5000 * time.Millisecond)
	}
}

func (c *ClientData) clSendDataToServer(peerSrvHost string, peerSrvConn net.Conn, dataToPeerSrv commProto) {
	if peerSrvConn != nil {
		srvWriteGob := gob.NewEncoder(peerSrvConn)
		err := srvWriteGob.Encode(dataToPeerSrv)
		if err != nil {
			peerSrvConn.Close()
			c.serverIPAddrConns[peerSrvHost] = nil
		}
	}
}

func (c *ClientData) clHandleOutgoingMsg(msgClOut ClMessage) {
	switch msgClOut.clCommProto.MsgType {
	case "REQ_HB": // Deliver HB request to peer node
		peerSrvHost := dictNodeIDsIPAddr[msgClOut.clCommProto.ToNodeID]
		peerSrvConn := c.serverIPAddrConns[peerSrvHost]
		c.clSendDataToServer(peerSrvHost, peerSrvConn, msgClOut.clCommProto)
	}
}

func (c *ClientData) clHandleIncomingMsg(peerSrvNodeID int, peerSrvHost string, peerSrvConn net.Conn) {
	for {
		var srvData commProto
		srvReadGob := gob.NewDecoder(peerSrvConn)
		err := srvReadGob.Decode(&srvData)
		if err != nil {
			peerSrvConn.Close()
			c.serverIPAddrConns[peerSrvHost] = nil
			return
		}

		if len(srvData.MsgType) > 0 {
			c.msgClIn <- ClMessage{clCommProto: srvData, clConn: nil}
		}
	}
}
