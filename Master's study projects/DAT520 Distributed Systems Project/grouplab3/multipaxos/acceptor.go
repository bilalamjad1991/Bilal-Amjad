// +build !solution

package multipaxos

import "sort"

// Acceptor represents an acceptor as defined by the Multi-Paxos algorithm.
type Acceptor struct {
	id          int
	lastPrmRnd  Round
	lastPrmSlot SlotID
	lastAccRnd  Round
	lastAccSlot SlotID
	lastAccVal  Value
	prepareIn   chan Prepare
	promiseOut  chan<- Promise
	acceptIn    chan Accept
	learnOut    chan<- Learn
	allAccSlots map[SlotID]PromiseSlot
	stop        chan struct{}
}

// NewAcceptor returns a new single-decree Paxos acceptor.
// It takes the following arguments:
//
// id: The id of the node running this instance of a Paxos acceptor.
//
// promiseOut: A send only channel used to send promises to other nodes.
//
// learnOut: A send only channel used to send learns to other nodes.
func NewAcceptor(id int, promiseOut chan<- Promise, learnOut chan<- Learn) *Acceptor {
	return &Acceptor{
		id:          id,
		lastAccRnd:  NoRound,
		lastPrmRnd:  NoRound,
		prepareIn:   make(chan Prepare, 1000),
		promiseOut:  promiseOut,
		acceptIn:    make(chan Accept, 1000),
		learnOut:    learnOut,
		allAccSlots: make(map[SlotID]PromiseSlot),
		stop:        make(chan struct{}),
	}
}

// Start starts a's main run loop as a separate goroutine. The main run loop
// handles incoming prepare and accept messages.
func (a *Acceptor) Start() {
	go func() {
		for {
			select {
			case prp := <-a.prepareIn:
				prm, output := a.handlePrepare(prp)
				if output {
					a.promiseOut <- prm
				}
			case acc := <-a.acceptIn:
				learn, output := a.handleAccept(acc)
				if output {
					a.learnOut <- learn
				}
			case <-a.stop:
				return
			}
		}
	}()
}

// Stop stops a's main run loop.
func (a *Acceptor) Stop() {
	a.stop <- struct{}{}
}

// DeliverPrepare delivers prepare prp to acceptor a.
func (a *Acceptor) DeliverPrepare(prp Prepare) {
	a.prepareIn <- prp
}

// DeliverAccept delivers accept acc to acceptor a.
func (a *Acceptor) DeliverAccept(acc Accept) {
	a.acceptIn <- acc
}

// Internal: handlePrepare processes prepare prp according to the Multi-Paxos
// algorithm. If handling the prepare results in acceptor a emitting a
// corresponding promise, then output will be true and prm contain the promise.
// If handlePrepare returns false as output, then prm will be a zero-valued
// struct.
func (a *Acceptor) handlePrepare(prp Prepare) (prm Promise, output bool) {
	if prp.Crnd > a.lastPrmRnd {
		a.lastPrmRnd = prp.Crnd
		a.lastPrmSlot = prp.Slot

		accSlots := []PromiseSlot{}
		for slotID, prmSlot := range a.allAccSlots {
			if slotID >= prp.Slot {
				accSlots = append(accSlots, prmSlot)
			}
		}

		sort.Sort(BySlotID(accSlots))
		promise := Promise{To: prp.From, From: a.id, Rnd: a.lastPrmRnd}

		if len(accSlots) > 0 {
			promise.Slots = accSlots
		}

		return promise, true
	}

	return Promise{}, false
}

// Internal: handleAccept processes accept acc according to the Multi-Paxos
// algorithm. If handling the accept results in acceptor a emitting a
// corresponding learn, then output will be true and lrn contain the learn.  If
// handleAccept returns false as output, then lrn will be a zero-valued struct.
func (a *Acceptor) handleAccept(acc Accept) (lrn Learn, output bool) {
	if acc.Rnd >= a.lastPrmRnd {
		a.lastPrmRnd = acc.Rnd
		a.lastPrmSlot = acc.Slot
		a.lastAccRnd = acc.Rnd
		a.lastAccSlot = acc.Slot
		a.lastAccVal = acc.Val

		accSlot := PromiseSlot{ID: acc.Slot, Vrnd: a.lastAccRnd, Vval: a.lastAccVal}
		prevSlot, ok := a.allAccSlots[acc.Slot]

		if (ok && prevSlot.Vrnd < acc.Rnd) || !ok {
			a.allAccSlots[acc.Slot] = accSlot
		}

		learn := Learn{From: a.id, Slot: a.lastAccSlot, Rnd: a.lastAccRnd, Val: a.lastAccVal}

		return learn, true
	} else {
		return Learn{}, false
	}
}

type BySlotID []PromiseSlot

// find the length of slice
func (slice BySlotID) Len() int {
	return len(slice)
}

// to find minimum ID
func (slice BySlotID) Less(i, j int) bool {
	return slice[i].ID < slice[j].ID
}

//  to swap entries
func (slice BySlotID) Swap(i, j int) {
	slice[i], slice[j] = slice[j], slice[i]
}
