package main

import (
	dtr "github.com/uis-dat520-s18/glabs/grouplab1/detector"
	mlpx "github.com/uis-dat520-s18/glabs/grouplab3/multipaxos"
	tcpsocket "github.com/uis-dat520-s18/glabs/grouplab3/tcpsocket"
	"log"
)

var NATIVE_CONN_ADDR string

var mapOfNodeIDsIPAddr = map[int]string{
	0: "152.94.1.110",
	1: "152.94.1.111",
	2: "152.94.1.113",
}

type DistributedApp struct {
	leader int
	ld     dtr.LeaderDetector
	stop   chan struct{}
}

func InitApp(ld *dtr.MonLeaderDetector) (*DistributedApp, error) {
	appHandle := DistributedApp{
		leader: -1,
		ld:     ld,
		stop:   make(chan struct{}),
	}

	return &appHandle, nil
}

func (a *DistributedApp) Start() {
	log.SetFlags(log.Ldate | log.Ltime)
	var gotLeader int
	ldrSubscriber := a.ld.Subscribe()

	go func() {
		for {
			select {
			case gotLeader = <-ldrSubscriber:
				log.Printf("Elected Leader Node: %d", gotLeader)
				a.leader = gotLeader
			case <-a.stop:
				return
			}
		}
	}()
}

func (a *DistributedApp) Stop() {
	a.stop <- struct{}{}
}

func main() {
	log.SetFlags(log.Ldate | log.Ltime)

	done := make(chan bool)
	msgIn := make(chan tcpsocket.ClMessage, 1000)
	msgOut := make(chan tcpsocket.ClMessage, 1000)

	prepareOut := make(chan mlpx.Prepare, 1000)
	acceptOut := make(chan mlpx.Accept, 1000)

	promiseOut := make(chan mlpx.Promise, 1000)
	learnOut := make(chan mlpx.Learn, 1000)
	chosenValOut := make(chan mlpx.DecidedValue, 1)

	srvLdrIn := make(chan int, 1)
	adu := 0

	srvChannel := tcpsocket.SrvChannels{
		HbOut:        nil,
		PrepareOut:   prepareOut,
		AcceptOut:    acceptOut,
		PromiseOut:   promiseOut,
		LearnOut:     learnOut,
		ChosenValOut: chosenValOut,
		SrvLdrIn:     srvLdrIn,
	}

	thisNodeAddr := tcpsocket.GetIPAddr()

	ld := dtr.NewMonLeaderDetector(tcpsocket.ClusterOfThree)

	proposer := mlpx.NewProposer(
		tcpsocket.MapOfIPAddrNodeIDs[thisNodeAddr],
		len(tcpsocket.ClusterOfThree),
		adu,
		ld,
		prepareOut,
		acceptOut,
	)
	proposer.SrvLdr = srvChannel.SrvLdrIn

	acceptor := mlpx.NewAcceptor(
		tcpsocket.MapOfIPAddrNodeIDs[thisNodeAddr],
		promiseOut,
		learnOut,
	)

	learner := mlpx.NewLearner(tcpsocket.MapOfIPAddrNodeIDs[thisNodeAddr], len(tcpsocket.ClusterOfThree), chosenValOut)

	srv, _ := tcpsocket.InitServer(ld, msgIn, msgOut, proposer, acceptor, learner, srvChannel)
	cl, _ := tcpsocket.InitClient(msgIn, msgOut)

	apl, _ := InitApp(ld)

	apl.Start()
	defer apl.Stop()

	srv.Start()
	defer srv.Stop()

	cl.Start()
	defer cl.Stop()

	srv.Fd.Start()
	defer srv.Fd.Stop()

	srv.Proposer.Start()
	defer srv.Proposer.Stop()

	srv.Acceptor.Start()
	defer srv.Acceptor.Stop()

	srv.Learner.Start()
	defer srv.Learner.Stop()

	<-done
}
