// +build !solution

package detector

import (
	"time"
	"log"
)

// EvtFailureDetector represents a Eventually Perfect Failure Detector as
// described at page 53 in:
// Christian Cachin, Rachid Guerraoui, and Luís Rodrigues: "Introduction to
// Reliable and Secure Distributed Programming" Springer, 2nd edition, 2011.
type EvtFailureDetector struct {
	id        int          // this node's id
	nodeIDs   []int        // node ids for every node in cluster
	alive     map[int]bool // map of node ids considered alive
	suspected map[int]bool // map of node ids  considered suspected

	sr SuspectRestorer // Provided SuspectRestorer implementation

	delay         time.Duration // the current delay for the timeout procedure
	delta         time.Duration // the delta value to be used when increasing delay
	timeoutSignal *time.Ticker  // the timeout procedure ticker

	hbSend chan<- Heartbeat // channel for sending outgoing heartbeat messages
	hbIn   chan Heartbeat   // channel for receiving incoming heartbeat messages
	stop   chan struct{}    // channel for signaling a stop request to the main run loop

	testingHook func() // DO NOT REMOVE THIS LINE. A no-op when not testing.
}

// NewEvtFailureDetector returns a new Eventual Failure Detector. It takes the
// following arguments:
//
// id: The id of the node running this instance of the failure detector.
//
// nodeIDs: A list of ids for every node in the cluster (including the node
// running this instance of the failure detector).
//
// ld: A leader detector implementing the SuspectRestorer interface.
//
// delta: The initial value for the timeout interval. Also the value to be used
// when increasing delay.
//
// hbSend: A send only channel used to send heartbeats to other nodes.
func NewEvtFailureDetector(id int, nodeIDs []int, sr SuspectRestorer, delta time.Duration, hbSend chan<- Heartbeat) *EvtFailureDetector {
	alive := make(map[int]bool)
	suspected := make(map[int]bool)

	for _, nodeID := range nodeIDs {
		alive[nodeID] = true
	}

	return &EvtFailureDetector{
		id:        id,
		nodeIDs:   nodeIDs,
		alive:     alive,
		suspected: suspected,

		sr: sr,

		delay: delta,
		delta: delta,

		hbSend: hbSend,
		hbIn:   make(chan Heartbeat, 10000),
		stop:   make(chan struct{}),

		testingHook: func() {}, // DO NOT REMOVE THIS LINE. A no-op when not testing.
	}
}

// Start starts e's main run loop as a separate goroutine. The main run loop
// handles incoming heartbeat requests and responses. The loop also trigger e's
// timeout procedure at an interval corresponding to e's internal delay
// duration variable.
func (e *EvtFailureDetector) Start() {
	//log.Println("[FD]: failure detector started")
	e.timeoutSignal = time.NewTicker(e.delay)
	go func() {
		for {
			e.testingHook() // DO NOT REMOVE THIS LINE. A no-op when not testing.
			select {
			case hbInTmp := <-e.hbIn:
				e.handleHBRequest(hbInTmp)
			case <-e.timeoutSignal.C:
				e.timeout()
			case <-e.stop:
				return
			}
		}
	}()
}

// DeliverHeartbeat delivers heartbeat hb to failure detector e.
func (e *EvtFailureDetector) DeliverHeartbeat(hb Heartbeat) {
	e.hbIn <- hb
}

// Stop stops e's main run loop.
func (e *EvtFailureDetector) Stop() {
	log.Println("[FD]: Fd stop")
	e.stop <- struct{}{}
}

// Internal: timeout runs e's timeout procedure.
func (e *EvtFailureDetector) timeout() {
	e.computeDelay()

	e.suspectRestore()

	e.timeoutSignal = time.NewTicker(e.delay)
}

// Handle heartbeat request and if required send a heartbeat
func (e *EvtFailureDetector) handleHBRequest(hbInTmp Heartbeat) {
	if hbInTmp.Request {
		e.hbSend <- Heartbeat{To: hbInTmp.From, From: e.id, Request: false}
	} else {
		e.alive[hbInTmp.From] = true
	}
}

// Compute timeout delay
func (e *EvtFailureDetector) computeDelay() {
	// Find intersection of alive and suspected node
	for nodeID := range e.alive {
		if e.suspected[nodeID] {
			e.delay += e.delta
			break
		}
	}
}

// Register suspect or restore, and send heartbeat
func (e *EvtFailureDetector) suspectRestore() {
	for nodeID := range e.nodeIDs {
		if !e.alive[nodeID] && !e.suspected[nodeID] { // Register suspect
			e.suspected[nodeID] = true // Add node to suspect list
			e.sr.Suspect(nodeID)
		} else if e.alive[nodeID] && e.suspected[nodeID] { // Register restore
			delete(e.suspected, nodeID) //Remove node from suspect list
			e.sr.Restore(nodeID)
		}
		e.hbSend <- Heartbeat{To: nodeID, From: e.id, Request: true} // Send heartbeat request for each of the nodes
		//log.Println("[FD]: Send HB request")
		delete(e.alive, nodeID)                                      // Remove nodeID from Alive set
	}
}
