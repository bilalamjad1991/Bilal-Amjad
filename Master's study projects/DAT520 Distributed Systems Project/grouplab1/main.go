package main

import (
	dtr "github.com/uis-dat520-s18/glabs/grouplab1/detector"
	tcpsocket "github.com/uis-dat520-s18/glabs/grouplab1/tcpsocket"
	"log"
)

var dictNodeIDsIPAddr = map[int]string{
	0: "152.94.1.100",
	1: "152.94.1.152",
	2: "152.94.1.154",
}

type DistributedApp struct {
	ldrSubscriber <-chan int // for subscribing to leader Detector
	stop          chan bool  // to send a stop request to the start run loop
}

func InitApp(ldrSubscriber <-chan int) (*DistributedApp, error) {
	appHandle := DistributedApp{
		ldrSubscriber: ldrSubscriber,
		stop:          make(chan bool),
	}

	return &appHandle, nil
}

func (a *DistributedApp) Start() {
	log.SetFlags(log.Ldate | log.Ltime)
	var gotLeader int

	go func() {
		for {
			select {
			case gotLeader = <-a.ldrSubscriber: // check for leader change
				log.Printf("Newly elected leader : [%s:%d]", dictNodeIDsIPAddr[gotLeader], gotLeader)
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
	log.SetFlags(log.Ldate | log.Ltime)
	done := make(chan bool)                        // indicator to end this program
	msgIn := make(chan tcpsocket.ClMessage, 1000)  // Channel to synchronize HB requests between server/client
	msgOut := make(chan tcpsocket.ClMessage, 1000) // channel to synchronize HB requests between server/client

	ld := dtr.NewMonLeaderDetector(tcpsocket.ClusterOfThree)

	srv, _ := tcpsocket.InitServer(ld, msgIn, msgOut)
	cl, _ := tcpsocket.InitClient(msgIn, msgOut)

	srv.StartServer()
	defer srv.StopServer()

	cl.StartClient()
	defer cl.StopClient()

	srv.Fd.Start()
	defer srv.Fd.Stop()

	ldrSubscriber := ld.Subscribe()
	apl, _ := InitApp(ldrSubscriber)
	apl.Start()
	defer apl.Stop()

	<-done // exit program if true //
}
