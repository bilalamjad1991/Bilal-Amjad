//package main
package bankApp

import (
	"container/list"
	"github.com/gorilla/websocket"
	"github.com/uis-dat520-s18/glabs/grouplab4/bank"
	dtr "github.com/uis-dat520-s18/glabs/grouplab4/detector"
	mlpx "github.com/uis-dat520-s18/glabs/grouplab4/multipaxos"
	"log"
	"net/http"
	"strings"
)

func NewWS(ld *dtr.MonLeaderDetector, proposer *mlpx.Proposer, acceptor *mlpx.Acceptor, learner *mlpx.Learner, srvChans SrvChannels, cli *InternalClient) *WS_Server {
	node_id := AddrToIDMap[GetIPAddr()]
	fd := dtr.NewEvtFailureDetector(
		node_id,
		ClusterIDs,
		ld,
		DELTA,
		srvChans.HbChan,
	)

	return &WS_Server{
		ID:                  node_id,
		Fd:                  fd,
		Adu:                 0,
		Proposer:            proposer,
		Acceptor:            acceptor,
		Learner:             learner,
		CurrentLeader:       node_id,
		WsChans:             srvChans,
		ExtClientConns:      make(map[string]*websocket.Conn),
		InternalClientConns: make(map[string]*websocket.Conn),
		ClValInList:         list.New(),
		ChosenValInList:     list.New(),
		BankAccounts:        make(map[int]*bank.Account),
		NextAccountNumber:   1,
		InternalClient:      cli,
		TransactionHistory:  make(map[int][]TransactionLog),
	}
}

func (ws *WS_Server) Start() {
	// handle internal incoming message from fd and paxos components
	go ws.HandleInternalIncomingMessage()

	// handle external incoming websocket value from client or other nodes
	go ws.HandleWebSocketConnection()
}

// Stop  server.
func (ws *WS_Server) Stop() {
	log.Println("WS_Server stop")
	ws.WsChans.StopChan <- struct{}{}
}

var upgrader = websocket.Upgrader{
	CheckOrigin:     func(r *http.Request) bool { return true },
	ReadBufferSize:  1024,
	WriteBufferSize: 1024,
}

func (ws *WS_Server) ServeWs(w http.ResponseWriter, r *http.Request) {
	conn, err := upgrader.Upgrade(w, r, nil)

	if err != nil {
		log.Println(err)
		return
	}
	// create client
	clIPAddr := strings.Split(conn.RemoteAddr().String(), ":")
	_, ok := AddrToIDMap[clIPAddr[0]]
	if !ok {
		if ws.CurrentLeader != ws.ID {
			ws.LeaderRedirect(conn, clIPAddr[0], 0)
		} else {
			ws.ExtClientConns[clIPAddr[0]] = conn
			go ws.handleExternalClientMessage(conn, clIPAddr[0])
		}
	} else {
		log.Printf("New Internal client connected: %s", clIPAddr)
		ws.InternalClientConns[clIPAddr[0]] = conn
		ws.InternalClient.connectToServerIfNotConnected(clIPAddr[0])
		go ws.handleInternalClientMessage(conn, clIPAddr[0])
	}

}

func (ws *WS_Server) HandleInternalIncomingMessage() {
	for {
		select {
		case hb := <-ws.WsChans.HbChan:
			//log.Println("Heardbeat received from FD")
			if hb.Request {
				if hb.To == hb.From {
					hbReply := dtr.Heartbeat{From: hb.From, To: hb.To, Request: false}
					ws.Fd.DeliverHeartbeat(hbReply)
				} else {
					ws.SendToClient(HB, hb)
				}
			} else {
				// for hb_res, send the response to client and client will send to
				// destination server
				ws.SendToClient(HB, hb)

			}
		case prepare := <-ws.WsChans.PrepareChan:
			log.Printf("Prepare receive from Proposer: %s \n", prepare.String())
			ws.Acceptor.DeliverPrepare(prepare)
			ws.SendToClient(PREPARE, prepare)
		case promise := <-ws.WsChans.PromiseChan:
			log.Printf("Promise receive from Acceptor: %s \n", promise.String())
			if ws.ID == promise.To {
				ws.Proposer.DeliverPromise(promise) // Deliver promise to this node proposer
			} else {
				ws.SendToClient(PROMISE, promise)
			}
		case accept := <-ws.WsChans.AcceptChan:
			log.Printf("Accept receive from Proposer: %s \n", accept.String())
			ws.Acceptor.DeliverAccept(accept)
			ws.SendToClient(ACCEPT, accept)
		case learn := <-ws.WsChans.LearnChan:
			ws.Learner.DeliverLearn(learn) // Deliver learn message from acceptor to this node learner
			ws.SendToClient(LEARN, learn)
		case chosen_val := <-ws.WsChans.ChosenValChan:
			log.Printf("Chosen value learned from learner: %v \n", chosen_val)
			// handle operation for decided value
			ws.HandleChosenValue(chosen_val)
		case new_leader := <-ws.WsChans.SrvLdrChan:
			log.Printf("New leader change occer: leader = %d\n", new_leader)
			ws.CurrentLeader = new_leader

		case <-ws.WsChans.StopChan:
			return
		}
	}
}

func (ws *WS_Server) HandleWebSocketConnection() {
	//hub := newHub()
	//go hub.run()
	http.HandleFunc("/ws", func(w http.ResponseWriter, r *http.Request) {
		ws.ServeWs(w, r)
	})

	err := http.ListenAndServe(GetIPAddr()+":"+TCP_PORT, nil) // IDToAddrMap[ws.ID]
	if err != nil {
		log.Fatal("ListenAndServe: ", err)
	}
}

// send data to internal client
func (ws *WS_Server) SendToClient(t string, d interface{}) {
	// send the data to internal client and the client will send
	// to destination server via socket
	msg_date := MsgData{Type: t, Data: d}
	//log.Printf("[SendToClient]: Sending data to internal client: %v", msg_date)
	ws.WsChans.SrvMsgOutChan <- msg_date
}

func (ws *WS_Server) HandleChosenValue(chosen_val mlpx.DecidedValue) {

	if int(chosen_val.SlotID) > (ws.Adu + 1) { // Works with alpha > 1
		ws.ChosenValInList.PushBack(chosen_val)
		return
	}
	if !chosen_val.Value.Noop {
		ws.processChosenValue(chosen_val)

	}

	ws.Adu++                              // Increment server adu
	ws.Proposer.IncrementAllDecidedUpTo() // Increment Proposer adu

	//Process any pending transaction
	if ws.ChosenValInList.Len() > 0 {
		newVal := ws.ChosenValInList.Front().Value.(mlpx.DecidedValue)
		ws.ChosenValInList.Remove(ws.ChosenValInList.Front())
		ws.HandleChosenValue(newVal)
	}
}
