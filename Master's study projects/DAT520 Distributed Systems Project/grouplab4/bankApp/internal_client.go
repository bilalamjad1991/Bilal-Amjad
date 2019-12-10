package bankApp

import (
	"github.com/gorilla/websocket"
	dtr "github.com/uis-dat520-s18/glabs/grouplab4/detector"
	mlpx "github.com/uis-dat520-s18/glabs/grouplab4/multipaxos"
	"log"
	"net/url"
	"time"
)

func NewInternalClient(msgIn chan MsgData, msgOut chan MsgData) *InternalClient {
	return &InternalClient{
		ID:               AddrToIDMap[GetIPAddr()],
		ClientMsgInChan:  msgOut,
		ClientMsgOutChan: msgIn,
		StopChan:         make(chan struct{}),
		Conns:            make(map[string]*websocket.Conn),
	}
}

func (cl *InternalClient) Start() {
	go cl.ConnectToSocketServers()

	go func() {
		for {
			select {
			case msgIn := <-cl.ClientMsgInChan:
				cl.HandleIncomingChanMsg(msgIn)
			case <-cl.StopChan:
				for _, conn := range cl.Conns {
					conn.Close()
				}
				return
			}
		}
	}()
}

func (cl *InternalClient) Stop() {
	cl.StopChan <- struct{}{}
}

func (cl *InternalClient) ConnectToSocketServers() {
	for {
		for _, v := range ClusterAddrs {
			if v != GetIPAddr() && cl.Conns[v] == nil {
				u := url.URL{Scheme: "ws", Host: v + ":" + TCP_PORT, Path: "/ws"}
				//log.Printf("connecting to %s", u.String())

				conn, _, err := websocket.DefaultDialer.Dial(u.String(), nil)
				if err != nil {
					//log.Println("dial error:", err)
				} else {
					cl.Conns[v] = conn
					//defer conn.Close()
				}
			}
		}
		time.Sleep(3000 * time.Millisecond)
	}
}

func (cl *InternalClient) CloseConnection(ipaddr string) {
	conn := cl.Conns[ipaddr]
	if conn != nil {
		conn.Close()
		delete(cl.Conns, ipaddr)
	}
}

func (cl *InternalClient) connectToServerIfNotConnected(ip string) {
	time.Sleep(3000 * time.Millisecond)
	if cl.Conns[ip] == nil {
		for {
			if cl.Conns[ip] == nil {
				u := url.URL{Scheme: "ws", Host: ip + ":" + TCP_PORT, Path: "/ws"}
				log.Printf("reconnecting to %s", u.String())

				conn, _, err := websocket.DefaultDialer.Dial(u.String(), nil)
				if err != nil {
					//log.Println("dial error:", err)
				} else {
					cl.Conns[ip] = conn
					//defer conn.Close()
				}
			} else {
				break
			}
			time.Sleep(3000 * time.Millisecond)
		}
	}
}

func (cl *InternalClient) HandleIncomingChanMsg(msg MsgData) {
	// handle here
	//log.Printf("[client] chan rec data: %v", msg)
	switch msg.Type {
	case HB:
		hb := msg.Data.(dtr.Heartbeat)
		conn, ok := cl.Conns[IDToAddrMap[hb.To]]
		if ok {
			conn.WriteJSON(msg)
		}
	case PREPARE:
		//prepare := msg.Data.(mlpx.Prepare)
		for ip, conn := range cl.Conns {
			if ip != GetIPAddr() && conn != nil {
				conn.WriteJSON(msg)
			}
		}
	case ACCEPT:
		//accept := msg.Data.(mlpx.Accept)
		for ip, conn := range cl.Conns {
			if ip != GetIPAddr() && conn != nil {
				conn.WriteJSON(msg)
			}
		}
	case PROMISE:
		promise := msg.Data.(mlpx.Promise)
		conn, ok := cl.Conns[IDToAddrMap[promise.To]]
		if ok {
			conn.WriteJSON(msg)
		}
	case LEARN:
		//learn := msg.Data.(mlpx.Learn)
		for ip, conn := range cl.Conns {
			if ip != GetIPAddr() && conn != nil {
				conn.WriteJSON(msg)
			}
		}
	}
}
