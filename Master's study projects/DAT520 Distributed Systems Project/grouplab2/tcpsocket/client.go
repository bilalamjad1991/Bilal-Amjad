package tcpsocket

import (
	"encoding/gob"
	"log"
	"net"
	"time"
)

func InitClient(msgIn chan ClMessage, msgOut chan ClMessage) (*DistributedCl, error) {
	log.SetFlags(log.Ldate | log.Ltime)

	NATIVE_CONN_ADDR = GetIPAddr()

	clHandle := DistributedCl{
		id:                MapOfIPAddrNodeIDs[NATIVE_CONN_ADDR],
		msgClIn:           msgIn,
		msgClOut:          msgOut,
		serverIPAddrConns: clusterAddrConns,
		stop:              make(chan bool),
	}

	return &clHandle, nil
}

func (c *DistributedCl) Start() {
	go c.connToServers()
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

func (c *DistributedCl) Stop() {
	c.stop <- true
}

func (c *DistributedCl) connToServers() {
	for {
		for peerSrvHost, conn := range c.serverIPAddrConns {
			if conn == nil {
				if peerSrvHost != NATIVE_CONN_ADDR {
					peerSrvConn, err := net.Dial(NW_CONN_PROTO, peerSrvHost+":"+TCP_CONN_PORT)
					if err != nil {
					} else {
						err = peerSrvConn.(*net.TCPConn).SetKeepAlive(true)
						if err != nil {
						} else {
							err = peerSrvConn.(*net.TCPConn).SetKeepAlivePeriod(1800 * time.Second)
							if err != nil {
							}
						}

						c.serverIPAddrConns[peerSrvHost] = peerSrvConn
						go c.clHandleIncomingMsg(MapOfIPAddrNodeIDs[peerSrvHost], peerSrvHost, peerSrvConn)
					}
				}
			}
		}

		time.Sleep(3000 * time.Millisecond)
	}
}

func (c *DistributedCl) clSendDataToServer(peerSrvHost string, peerSrvConn net.Conn, dataToPeerSrv commProto) {
	if peerSrvConn != nil {
		clData := dataToPeerSrv
		srvWriteGob := gob.NewEncoder(peerSrvConn)
		err := srvWriteGob.Encode(clData)
		if err != nil {
			peerSrvConn.Close()
			c.serverIPAddrConns[peerSrvHost] = nil
		}
	}
}

func (c *DistributedCl) clHandleOutgoingMsg(msgClOut ClMessage) {
	switch msgClOut.clCommProto.MsgType {
	case "REQ_HB": 
		peerSrvHost := mapOfNodeIDsIPAddr[msgClOut.clCommProto.ToNodeID]
		peerSrvConn := c.serverIPAddrConns[peerSrvHost]
		c.clSendDataToServer(peerSrvHost, peerSrvConn, msgClOut.clCommProto)
	case "PREPARE": 
		for peerSrvHost, peerSrvConn := range c.serverIPAddrConns {
			msgClOut.clCommProto.ToNodeID = MapOfIPAddrNodeIDs[peerSrvHost]
			c.clSendDataToServer(peerSrvHost, peerSrvConn, msgClOut.clCommProto)
		}
	case "PROMISE": 
		peerSrvHost := mapOfNodeIDsIPAddr[msgClOut.clCommProto.ToNodeID]
		peerSrvConn := c.serverIPAddrConns[peerSrvHost]
		c.clSendDataToServer(peerSrvHost, peerSrvConn, msgClOut.clCommProto)
	case "ACCEPT": 
		for peerSrvHost, peerSrvConn := range c.serverIPAddrConns {
			msgClOut.clCommProto.ToNodeID = MapOfIPAddrNodeIDs[peerSrvHost]
			c.clSendDataToServer(peerSrvHost, peerSrvConn, msgClOut.clCommProto)
		}
	case "LEARN": 
		for peerSrvHost, peerSrvConn := range c.serverIPAddrConns {
			msgClOut.clCommProto.ToNodeID = MapOfIPAddrNodeIDs[peerSrvHost]
			c.clSendDataToServer(peerSrvHost, peerSrvConn, msgClOut.clCommProto)
		}
	}
}

func (c *DistributedCl) clHandleIncomingMsg(peerSrvNodeID int, peerSrvHost string, peerSrvConn net.Conn) {
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


