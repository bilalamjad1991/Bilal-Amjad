package main

import (
	"flag"
	"github.com/uis-dat520-s18/glabs/grouplab4/bankApp"
	dtr "github.com/uis-dat520-s18/glabs/grouplab4/detector"
	mlpx "github.com/uis-dat520-s18/glabs/grouplab4/multipaxos"
)

func main() {
	flag.Parse()
	done := make(chan bool)

	PrepareChan := make(chan mlpx.Prepare, 1000)
	AcceptChan := make(chan mlpx.Accept, 1000)
	PromiseChan := make(chan mlpx.Promise, 1000)
	LearnChan := make(chan mlpx.Learn, 1000)
	ChosenValChan := make(chan mlpx.DecidedValue, 1)
	SrvLdrChan := make(chan int, 1)
	HBChan := make(chan dtr.Heartbeat, 16)
	MsgInChan := make(chan bankApp.MsgData)
	MsgOutChan := make(chan bankApp.MsgData)

	SrvChans := bankApp.SrvChannels{
		PrepareChan:   PrepareChan,
		AcceptChan:    AcceptChan,
		PromiseChan:   PromiseChan,
		LearnChan:     LearnChan,
		ChosenValChan: ChosenValChan,
		SrvLdrChan:    SrvLdrChan,
		HbChan:        HBChan,
		SrvMsgInChan:  MsgInChan,
		SrvMsgOutChan: MsgOutChan,
	}

	ld := dtr.NewMonLeaderDetector(bankApp.ClusterIDs)
	node_id := bankApp.AddrToIDMap[bankApp.GetIPAddr()]

	// initialize paxos components
	adu := 0
	proposer := mlpx.NewProposer(
		node_id,
		len(bankApp.ClusterIDs),
		adu,
		ld,
		PrepareChan,
		AcceptChan,
	)
	proposer.SrvLdrChan = SrvChans.SrvLdrChan // Link server channel to Proposer channel to receive leader information

	acceptor := mlpx.NewAcceptor(
		node_id,
		PromiseChan,
		LearnChan,
	)

	learner := mlpx.NewLearner(
		node_id, //ntw.MapOfIPAddrNodeIDs[thisNodeAddr],
		len(bankApp.ClusterIDs),
		ChosenValChan,
	)

	int_client := bankApp.NewInternalClient(MsgInChan, MsgOutChan)
	ws := bankApp.NewWS(ld, proposer, acceptor, learner, SrvChans, int_client) //bankApp.NewWS(SrvChans)

	ws.Start()
	defer ws.Stop()

	int_client.Start()
	defer int_client.Stop()

	// start failure detector
	ws.Fd.Start()
	defer ws.Fd.Stop()

	// invoke paxos components
	ws.Proposer.Start()
	defer ws.Proposer.Stop()

	ws.Acceptor.Start()
	defer ws.Acceptor.Stop()

	ws.Learner.Start()
	defer ws.Learner.Stop()

	<-done // Ends this program when this channel receives - true

}
