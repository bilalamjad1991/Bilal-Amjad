package main

import (
	"bufio"
	"encoding/gob"
	"fmt"
	"net"
	"os"
	"time"
)


var NATIVE_CONN_ADDR string 

const (
	NW_CONN_PROTO = "tcp"   
	TCP_CONN_PORT = "29170" 
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

type DistributedExtCl struct {
	serverIPAddrConns map[string]net.Conn //nodes and connection handles
	msgClIn           chan ClMessage      // message from other node
	usrInput          string           
	getUsrInput bool
	stop        chan bool 
}

type commProto struct {
	MsgType    string // EXTCLVALUE, CHVALUE
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

// Get localhost IPv4 address
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
///////////////////////******************

func InitExtClient() (*DistributedExtCl, error) {
	NATIVE_CONN_ADDR = GetIPAddr()

	extClHandle := DistributedExtCl{
		msgClIn:           make(chan ClMessage, 1000),
		serverIPAddrConns: clusterAddrConns,
		usrInput:          "",
		getUsrInput: false,
		stop:        make(chan bool),
	}

	return &extClHandle, nil
}

func (c *DistributedExtCl) Start() {
	go c.clConnToServers()
	c.getUsrInput = true
	go c.clHandleOutgoingMsg()
	var msgIn ClMessage

	go func() {
		for {
			select {
			case msgIn = <-c.msgClIn:
				fmt.Printf("The consensus value: '%s' from node %d \n",
					msgIn.clCommProto.Val, msgIn.clCommProto.FromNodeID)
				c.getUsrInput = true
			case <-c.stop:
				return
			}
		}
	}()
}

func (c *DistributedExtCl) Stop() {
	c.stop <- true
}

func (c *DistributedExtCl) clConnToServers() {
	for {
		for peerSrvHost, conn := range c.serverIPAddrConns {
			if conn == nil {
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

		time.Sleep(3000 * time.Millisecond)
	}
}

func (c *DistributedExtCl) clSendDataToServer() {
	for peerSrvHost, peerSrvConn := range c.serverIPAddrConns {
		if peerSrvConn != nil {
			dataToPeerSrv := commProto{MsgType: "EXTCLVALUE", Val: c.usrInput}
			srvWriteGob := gob.NewEncoder(peerSrvConn)
			err := srvWriteGob.Encode(dataToPeerSrv)
			if err != nil {
				peerSrvConn.Close()
				c.serverIPAddrConns[peerSrvHost] = nil
			}
		}
	}
}

func (c *DistributedExtCl) clHandleOutgoingMsg() {
	scanner := bufio.NewScanner(os.Stdin)

	for {
		if c.getUsrInput {
			fmt.Printf("Enter the proposed value: ")
			scanner.Scan()
			c.usrInput = scanner.Text()

			fmt.Printf("Notifying the nodes with proposed value: '%s'\n", c.usrInput)
			c.clSendDataToServer()
			c.getUsrInput = false
		}

		time.Sleep(2000 * time.Millisecond)
	}
}

func (c *DistributedExtCl) clHandleIncomingMsg(peerSrvNodeID int, peerSrvHost string, peerSrvConn net.Conn) {
	for {
		var srvData commProto
		srvReadGob := gob.NewDecoder(peerSrvConn)
		err := srvReadGob.Decode(&srvData)
		if err != nil {
			peerSrvConn.(*net.TCPConn).Close()
			c.serverIPAddrConns[peerSrvHost] = nil
			return
		}

		if len(srvData.Val) > 0 {
			c.msgClIn <- ClMessage{clCommProto: srvData, clConn: nil}
		}
	}
}


func main() {
	done := make(chan bool)        
	extCl, _ := InitExtClient() 

	extCl.Start()      
	defer extCl.Stop() 

	<-done 
}
