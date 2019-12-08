package main

import (
	"encoding/gob"
	"fmt"
	bank "github.com/uis-dat520-s18/glabs/grouplab3/bank"
	mlpx "github.com/uis-dat520-s18/glabs/grouplab3/multipaxos"
	"io"
	"math/rand"
	"net"
	"os"
	"time"
)

var NATIVE_CONN_ADDR string

const (
	NW_CONN_PROTO      = "tcp"
	TCP_CONN_PORT      = "29170"
	LDR_CONN_NUM_RETRY = 3
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
	serverIPAddrConns map[string]net.Conn
	randNodeID        int
	ldrNodeHost       string
	ldrNodeConn       net.Conn
	ldrConnRetryCnt   int
	msgClIn           chan ClMessage
	usrAccntNum       int
	usrTransType      int
	usrAmnt           int
	seqNum            int
	getUsrInput       chan struct{}
	readInput         bool
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
	UsrAccnt    map[string]bank.Account
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

func InitExtClient() (*DistributedExtCl, error) {
	NATIVE_CONN_ADDR = GetIPAddr()

	extClHandle := DistributedExtCl{
		msgClIn:           make(chan ClMessage, 1000),
		serverIPAddrConns: clusterAddrConns,
		getUsrInput:       make(chan struct{}),
		stop:              make(chan struct{}),
	}

	return &extClHandle, nil
}

func (c *DistributedExtCl) Start() {
	go c.clHandleOutgoingMsg()
	c.getUsrInput <- struct{}{}

	go func() {
		for {
			select {
			case msgIn := <-c.msgClIn:
				if c.seqNum == msgIn.clCommProto.TxnResponse.ClientSeq {
					txnResponse := msgIn.clCommProto.TxnResponse
					if txnResponse.TxnRes.ErrorString == "" {
						fmt.Printf("Transaction successful: Account #: %d Balance: %d NOK\n\n",
							txnResponse.TxnRes.AccountNum, txnResponse.TxnRes.Balance)
					} else {
						fmt.Printf("Transaction failed: %s\n\n", txnResponse.TxnRes.ErrorString)
					}
				} else {
					fmt.Printf("Cient sequence number mismatch: Client Seq Num: %d Got seq num: %d\n\n",
						c.seqNum, msgIn.clCommProto.Val.ClientSeq)
				}
				c.seqNum++
				c.getUsrInput <- struct{}{}
			case <-c.stop:
				os.Exit(1)
			}
		}
	}()
}

func (c *DistributedExtCl) Stop() {
	c.stop <- struct{}{}
}

func (c *DistributedExtCl) clConnToServer(spawnHndInMsg bool) {
	c.ldrConnRetryCnt = 0
	for c.ldrNodeConn == nil && c.ldrConnRetryCnt <= LDR_CONN_NUM_RETRY {
		if c.ldrNodeHost == "" {
			c.randNodeID = c.genRandNum(0, 3)
			c.ldrNodeHost = mapOfNodeIDsIPAddr[c.randNodeID]
		} else {
			c.randNodeID = MapOfIPAddrNodeIDs[c.ldrNodeHost]
		}

		peerSrvConn, err := net.DialTimeout(NW_CONN_PROTO, c.ldrNodeHost+":"+TCP_CONN_PORT, 3*time.Second)
		if err != nil {
			c.ldrNodeHost = ""
			c.ldrConnRetryCnt++
			continue
		} else {
			err = peerSrvConn.(*net.TCPConn).SetKeepAlive(true)
			if err != nil {
			} else {
				err = peerSrvConn.(*net.TCPConn).SetKeepAlivePeriod(1800 * time.Second)
				if err != nil {
				}
			}

			if spawnHndInMsg {
				go c.clHandleIncomingMsg()
			}

			c.ldrNodeConn = peerSrvConn
		}
	}

	if c.ldrConnRetryCnt >= LDR_CONN_NUM_RETRY {
		fmt.Println()
		fmt.Printf("The bank system isn't available now. Please try again later.\n")
		c.stop <- struct{}{}
	}
}

func (c *DistributedExtCl) clSendDataToServer() {
	if c.ldrNodeConn != nil {
		usrTxn := bank.Transaction{Op: bank.Operation(c.usrTransType), Amount: c.usrAmnt}
		clVal := mlpx.Value{ClientID: NATIVE_CONN_ADDR, ClientSeq: c.seqNum, Noop: false, AccountNum: c.usrAccntNum, Txn: usrTxn}

		dataToPeerSrv := commProto{MsgType: "EXTCLVALUE", Val: clVal}
		srvWriteGob := gob.NewEncoder(c.ldrNodeConn)
		err := srvWriteGob.Encode(dataToPeerSrv)
		if err == io.EOF {
			c.ldrNodeConn.Close()
			c.ldrNodeConn = nil
			c.ldrNodeHost = ""

			go c.clConnToServer(false)
		} else if err == nil {
			fmt.Println("Started transaction. Please wait.")
		}
	}
}

func (c *DistributedExtCl) clHandleOutgoingMsg() {
	for {
		select {
		case <-c.getUsrInput:
			c.usrAccntNum, c.usrTransType, c.usrAmnt = 0, 0, 0

			fmt.Print("Enter Account Number: ")
			fmt.Scan(&c.usrAccntNum)
			for c.usrAccntNum < 0 {
				fmt.Println("Incorrect account number. Try again.")
				fmt.Print("Enter Account Number: ")
				fmt.Scan(&c.usrAccntNum)
			}

			fmt.Print("Enter Transaction option (0: Balance | 1: Deposit | 2: Withdrawal): ")
			fmt.Scan(&c.usrTransType)
			for c.usrTransType < 0 || c.usrTransType > 2 {
				fmt.Println("Incorrect transaction option. Try again.")
				fmt.Print("Enter Transaction option (0: Balance | 1: Deposit | 2: Withdrawal): ")
				fmt.Scan(&c.usrTransType)
			}

			c.usrAmnt = 0
			if c.usrTransType != 0 {
				fmt.Print("Enter Amount: ")
				fmt.Scan(&c.usrAmnt)
				for c.usrAmnt < 0 {
					fmt.Println("Incorrect amount provided. Try again.")
					fmt.Print("Enter Amount: ")
					fmt.Scan(&c.usrAmnt)
				}
				fmt.Printf("Summary: Account number: %d, Transaction option: %d, Amount: %d\n",
					c.usrAccntNum, c.usrTransType, c.usrAmnt)
			} else {
				fmt.Printf("Summary: Account number: %d, Transaction option: %d\n",
					c.usrAccntNum, c.usrTransType)
			}

			c.readInput = true

			if c.ldrNodeConn == nil {
				c.clConnToServer(true)
			}

			go c.clSendDataToServer()
			c.readInput = false
		}
	}
}

func (c *DistributedExtCl) clHandleRedirect() {
	c.clConnToServer(true)
	go c.clSendDataToServer()
}

func (c *DistributedExtCl) clHandleIncomingMsg() {
	for {
		if c.ldrNodeConn != nil {
			var srvData commProto
			srvReadGob := gob.NewDecoder(c.ldrNodeConn)
			err := srvReadGob.Decode(&srvData)
			if err == io.EOF {
				c.ldrNodeConn.Close()
				c.ldrNodeConn = nil
				c.ldrNodeHost = ""

				time.Sleep(8 * time.Second)
				go c.clConnToServer(true)
				return
			} else if err == nil {
				if len(srvData.MsgType) > 0 {
					switch srvData.MsgType {
					case "REDIRECT":
						c.ldrNodeConn.Close()
						c.ldrNodeConn = nil
						c.ldrNodeHost = srvData.IPAddr

						c.clHandleRedirect()
						return
					case "TRANSACTION_RESULT":
						msgFromPeer := ClMessage{clCommProto: srvData, clConn: nil}
						c.msgClIn <- msgFromPeer
					}
				}
			}
		}
	}
}

func (c *DistributedExtCl) genRandNum(min, max int) int {
	rand.Seed(time.Now().UTC().UnixNano())
	return rand.Intn(max-min) + min
}

func main() {
	done := make(chan bool)
	extCl, _ := InitExtClient()

	extCl.Start()
	defer extCl.Stop()

	<-done
}
