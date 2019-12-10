//package main
package bankApp

import (
	"time"
	"os"
	"net"
	"github.com/gorilla/websocket"
	dtr "github.com/uis-dat520-s18/glabs/grouplab4/detector"
	mlpx "github.com/uis-dat520-s18/glabs/grouplab4/multipaxos"
	"github.com/uis-dat520-s18/glabs/grouplab4/bank"
	"container/list"
)

// external client message type

const(
	Txn = "Txn"
	Signup = "Signup"
	Signin = "Signin"
	Balance = "Balance"
	Deposit = "Deposit"
	Withdraw = "Withdraw"
	Transfer = "Transfer"
	TCP_PORT = "3000"
	NEW_ACC = bank.Create
	Error = "Error"
	Redirect = "Redirect"

)

// to create account
type NewAccount struct {
	ClientID string `json:"client_id"`
	ClientSeq int `json:"client_seq"`
	FirstName string `json:"first_name"`
	LastName  string `json:"last_name"`
	Password  string `json:"password"`
	Balance   int `json:"balance"`
	AccountNum int `json:"account_num:omitempty"`
}


// external client message struct
type ExtClientMessage struct {
	Type string `json:"type"`
	Data    interface{} `json:"data,omitempty"`
}

type ResponseData struct {
	ClientID string `json:"client_id,omitempty"`
	ClientSeq int `json:"client_seq"`
	FirstName string `json:"first_name,omitempty"`
	LastName string `json:"last_name,omitempty"`
	AccountNum int `json:"account_num,omitempty"`
	Balance int	`json:"balance,omitempty"`
	Amount int `json:"amount,omitempty,omitempty"` // withdraw, deposit or transfer amount
	ToAccountNumber int `json:"to_account_number,omitempty"` // transfer account number
	TransactionHistory []TransactionLog `json:"transaction_history,omitempty"` // transaction history, send when signin
	ErrorString string `json:"error_string,omitempty"`
	LeaderUrl string `json:"leader_url,omitempty"`
} 
// login
type Login struct {
	ClientID string `json:"client_id"`
	ClientSeq int `json:"client_seq"`
	AccountNum  int `json:"account_num"`
	Password string `json:"password"`
}


// CLuster related data types declaration

var ClusterIDs = []int{0, 1, 2}
var ClusterAddrs = []string{"152.94.1.110", "152.94.1.111", "152.94.1.114"}

var IDToAddrMap = map[int]string{
	0: "152.94.1.110",
	1: "152.94.1.111",
	2: "152.94.1.114",
}

var AddrToIDMap = map[string]int{
	"152.94.1.110": 0,
	"152.94.1.111": 1,
	"152.94.1.114": 2,
}
// internal message types
const (
	DELTA      = time.Second // delta for timeout
	HB         = "HB"
	PREPARE    = "PREPARE"
	PROMISE    = "PROMISE"
	ACCEPT     = "ACCEPT"
	LEARN      = "LEARN"
	CHOSEN_VAL = "CHOSEN_VAL"
)

type WS_Server struct {
	ID                  int 	//node id
	ExtClientConns       map[string]*websocket.Conn // Dictionary of external client address and conns
	InternalClientConns map[string]*websocket.Conn // Dictionary of client nodeID and conns
	Fd                  *dtr.EvtFailureDetector
	Proposer            *mlpx.Proposer
	Acceptor            *mlpx.Acceptor
	Learner             *mlpx.Learner
	CurrentLeader       int
	WsChans             SrvChannels |				// All the channels external to network layer
	ClValInList   *list.List 						// List of client value received from external client
	ChosenValInList *list.List
	Adu int 										// Current slot ID
	BankAccounts map[int]*bank.Account
	NextAccountNumber int
	InternalClient *InternalClient
	TransactionHistory map[int][]TransactionLog
}

type TransactionLog struct {
	Txn interface{} `json:"txn"`
}

type SrvChannels struct {
	HbChan        chan dtr.Heartbeat     // Channel for receiving outgoing heartbeat messages
	PrepareChan   chan mlpx.Prepare      // Channel to recv prepare message
	AcceptChan    chan mlpx.Accept       // Channel to recv accept message
	PromiseChan   chan mlpx.Promise      // Channel to recv promise message
	LearnChan     chan mlpx.Learn        // Channel to recv learn value message
	ChosenValChan chan mlpx.DecidedValue // Channel to recv chosen value from learner
	SrvLdrChan    chan int               // Get leader subscription via app layer
	StopChan      chan struct{}          // Channel to stop server
	SrvMsgInChan  chan MsgData
	SrvMsgOutChan chan MsgData
}

type MsgData struct {
	Type string `json:"type"`
	Data interface{} `json:"data"`
}

// Client data
type InternalClient struct {
	ID                int                 // This node ID
	Conns map[string]*websocket.Conn // Dictionary of node and it's conn handle
	ClientMsgInChan    chan MsgData      // Channel to synchronize incoming message from server
	ClientMsgOutChan   chan MsgData      // Channel to synchronize outgoing message to server
	StopChan              chan struct{}       // Channel for signalling a stop request to the start run loop
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

func GetTransactionType(txn bank.Operation) string {
	switch txn {
	case bank.Balance:
		return Balance
	case bank.Deposit:
		return Deposit
	case bank.Withdrawal:
		return Withdraw
	case bank.Transfer:
		return Transfer
	case bank.Create:
		return Signup
	default:
		return "Unknowm"
	}
}