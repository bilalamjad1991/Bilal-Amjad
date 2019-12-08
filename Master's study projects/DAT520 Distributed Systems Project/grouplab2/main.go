package main

import (
	detector "github.com/uis-dat520-s18/glabs/grouplab1/detector"
	tcpsocket "github.com/uis-dat520-s18/glabs/grouplab2/tcpsocket"
	paxos "github.com/uis-dat520-s18/glabs/grouplab2/singlepaxos"
	"log"
)
var mapOfNodeIDsIPAddr = map[int]string{
	0: "152.94.1.110",
	1: "152.94.1.111",
	2: "152.94.1.113",
}

type DistributedApp struct {
	ldrSubscriber <-chan int
	stop          chan bool 
}

func InitApp(ldrSubscriber <-chan int) (*DistributedApp, error) {
	appHandle := DistributedApp{
		ldrSubscriber: ldrSubscriber,
		stop:          make(chan bool),
	}

	return &appHandle, nil
}

func (a *DistributedApp) Start() {
	var gotLeader int

	go func() {
		for {
			select {
			case gotLeader = <-a.ldrSubscriber: 
				log.Printf("Elected Leader Node: %d", gotLeader)
			case <-a.stop:
				return
			}
		}
	}()
}

func (a *DistributedApp) Stop() {
	a.stop <- true
}

func main() {
	done := make(chan bool)                  
	msgIn := make(chan tcpsocket.ClMessage, 1000)  
	msgOut := make(chan tcpsocket.ClMessage, 1000) 

	prepareOut := make(chan paxos.Prepare, 1000) 
	acceptOut := make(chan paxos.Accept, 1000)   

	promiseOut := make(chan paxos.Promise, 1000) 
	learnOut := make(chan paxos.Learn, 1000)     
	choosenValOut := make(chan paxos.Value, 1)   

	thisNodeAddr := tcpsocket.GetIPAddr() 

	ld := detector.NewMonLeaderDetector(tcpsocket.ClusterOfThree) 

	proposer := paxos.NewProposer( 
		tcpsocket.MapOfIPAddrNodeIDs[thisNodeAddr],
		len(tcpsocket.ClusterOfThree),
		ld,
		prepareOut,
		acceptOut,
	)

	acceptor := paxos.NewAcceptor(
		tcpsocket.MapOfIPAddrNodeIDs[thisNodeAddr],
		promiseOut,
		learnOut,
	)

	learner := paxos.NewLearner(
		tcpsocket.MapOfIPAddrNodeIDs[thisNodeAddr], 
		len(tcpsocket.ClusterOfThree), 
		choosenValOut
	) 

	srv, _ := tcpsocket.InitServer(ld, msgIn, msgOut, proposer, acceptor, learner,
		prepareOut, acceptOut, promiseOut, learnOut, choosenValOut) 
	cl, _ := tcpsocket.InitClient(msgIn, msgOut) 

	srv.Start()      
	defer srv.Stop() 

	cl.Start()      
	defer cl.Stop() 

	srv.Fd.Start()      
	defer srv.Fd.Stop() 

	ldrSubscriber := ld.Subscribe()      
	apl, _ := InitApp(ldrSubscriber) 
	apl.Start()                          
	defer apl.Stop()                   

	srv.Proposer.Start()      
	defer srv.Proposer.Stop() 

	srv.Acceptor.Start()     
	defer srv.Acceptor.Stop() 

	srv.Learner.Start()      
	defer srv.Learner.Stop() 

	<-done 
}
