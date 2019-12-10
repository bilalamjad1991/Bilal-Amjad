// +build !solution

package detector

import "time"

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
	suspected := make(map[int]bool)
	alive := make(map[int]bool)

	for _, p := range nodeIDs {
		alive[p] = true
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
		hbIn:   make(chan Heartbeat, 8),
		stop:   make(chan struct{}),

		testingHook: func() {}, // DO NOT REMOVE THIS LINE. A no-op when not testing.
	}
}

// Start starts e's main run loop as a separate goroutine. The main run loop
// handles incoming heartbeat requests and responses. The loop also trigger e's
// timeout procedure at an interval corresponding to e's internal delay
// duration variable.
func (e *EvtFailureDetector) Start() {
	e.timeoutSignal = time.NewTicker(e.delay)
	go func() {
		for {
			e.testingHook() // DO NOT REMOVE THIS LINE. A no-op when not testing.
			select {
			case hIn := <-e.hbIn:
				//// Handle incoming heartbeat: request by sending it over send channel, reply by marking it as alive
				if hIn.Request {
					e.hbSend <- Heartbeat{To: hIn.From, From: e.id, Request: false}
				} else {
					e.alive[hIn.From] = true
				}
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
	e.stop <- struct{}{}
}

// Internal: timeout runs e's timeout procedure.
func (e *EvtFailureDetector) timeout() {
	// if alive ∩ suspected ̸= nil then delay := delay + Δ;
	for p := range e.alive {
		if e.suspected[p] {
			e.delay += e.delta
			break
		}
	}
	// forall p do
	for p := range e.nodeIDs {
		//if (p ̸e alive) ∧ (p ̸e suspected) then add to suspected
		if !e.alive[p] && !e.suspected[p] {
			e.suspected[p] = true
			e.sr.Suspect(p)
		} else if e.alive[p] && e.suspected[p] { // else if (p e alive) ∧ (p e suspected) then remove from suspected
			delete(e.suspected, p)
			e.sr.Restore(p)
		}
		// trigger < pl, Send | p, [HEARTBEATREQUEST] >;
		e.hbSend <- Heartbeat{To: p, From: e.id, Request: true}
		//delete(e.alive, p)
	}
	// empty alive set
	e.alive = make(map[int]bool)
	//starttimer (delay);
	e.timeoutSignal = time.NewTicker(e.delay)
}
