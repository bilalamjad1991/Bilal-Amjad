// +build !solution

package multipaxos

import (
	"container/list"
	//"fmt"
	"fmt"
	"github.com/uis-dat520-s18/glabs/grouplab4/detector"
	"time"
)

// Proposer represents a proposer as defined by the Multi-Paxos algorithm.
type Proposer struct {
	id     int // Node ID
	quorum int // Quorum value
	n      int // Number of nodes

	crnd     Round  // Current round value
	adu      SlotID // Slot number
	nextSlot SlotID // Next slot number

	promises     []*Promise // Slice of pointers to Promise message
	promiseCount int        // Count of promise message to find majority of acceptors

	phaseOneDone           bool         // Flag to inform proposer to stop sending prepare
	phaseOneProgressTicker *time.Ticker // Timeout for phase one prepare message

	acceptsOut *list.List // List of accept messages that are to be sent to acceptor
	requestsIn *list.List // List of client value

	ld     detector.LeaderDetector // Interface to leader detector
	leader int                     // Current leader

	prepareOut chan<- Prepare // Channel to send Prepare message
	acceptOut  chan<- Accept  // Channel to send Accept message
	promiseIn  chan Promise   // Channel to receive Promise message
	cvalIn     chan Value     // Channel to receive client value

	incDcd chan struct{}
	stop   chan struct{} // Channel for signalling a stop request to the start run loop

	prmSlots         map[int]PromiseSlot // Proposer state of promise slot in phaseone
	minSeenSlotVal   int                 // Lowest seen slot value index of proposer state to be included in accept
	maxSeenSlotVal   int                 // Highest seen slot value index of proposer state to be included in accept
	avoidPrePhaseOne bool                // Flag to avoid pre phaseone Prepare broadcast
	SrvLdrChan       chan int            // Channel to send leader value to server
	syncPrm          bool
}

// NewProposer returns a new Multi-Paxos proposer. It takes the following
// arguments:
//
// id: The id of the node running this instance of a Paxos proposer.
//
// nrOfNodes: The total number of Paxos nodes.
//
// adu: all-decided-up-to. The initial id of the highest _consecutive_ slot
// that has been decided. Should normally be set to -1 initially, but for
// testing purposes it is passed in the constructor.
//
// ld: A leader detector implementing the detector.LeaderDetector interface.
//
// prepareOut: A send only channel used to send prepares to other nodes.
//
// The proposer's internal crnd field should initially be set to the value of
// its id.
func NewProposer(id, nrOfNodes, adu int, ld detector.LeaderDetector, prepareOut chan<- Prepare, acceptOut chan<- Accept) *Proposer {
	return &Proposer{
		id:     id,
		quorum: (nrOfNodes / 2) + 1,
		n:      nrOfNodes,

		crnd:     Round(id),
		adu:      SlotID(adu),
		nextSlot: 0,

		promises: make([]*Promise, nrOfNodes),

		phaseOneProgressTicker: time.NewTicker(time.Second),

		acceptsOut: list.New(),
		requestsIn: list.New(),

		ld:     ld,
		leader: ld.Leader(),

		prepareOut: prepareOut,
		acceptOut:  acceptOut,
		promiseIn:  make(chan Promise, 8),
		cvalIn:     make(chan Value, 8),

		incDcd:   make(chan struct{}),
		stop:     make(chan struct{}),
		prmSlots: map[int]PromiseSlot{},

		avoidPrePhaseOne: true,
	}

}

// Start starts p's main run loop as a separate goroutine.
func (p *Proposer) Start() {
	trustMsgs := p.ld.Subscribe()
	go func() {
		for {
			select {
			case prm := <-p.promiseIn:
				accepts, output := p.handlePromise(prm)
				if !output {
					continue
				}
				//fmt.Printf("[Proposer]: Accepts in incoming promise %v \n", accepts)
				p.nextSlot = p.adu + 1
				p.acceptsOut.Init()
				p.phaseOneDone = true
				p.avoidPrePhaseOne = false
				for _, acc := range accepts {
					p.acceptsOut.PushBack(acc)
				}
				p.sendAccept()
			case cval := <-p.cvalIn:
				if p.id != p.leader {
					continue
				}
				p.requestsIn.PushBack(cval)
				if !p.phaseOneDone {
					continue
				}
				p.sendAccept()
			case <-p.incDcd:
				p.adu++
				if p.id != p.leader {
					continue
				}
				if !p.phaseOneDone {
					continue
				}
				p.sendAccept()
			case <-p.phaseOneProgressTicker.C:
				if p.id == p.leader && !p.phaseOneDone {
					p.startPhaseOne()
				}
			case leader := <-trustMsgs:
				//fmt.Printf("[Proposer]: Leader changed from (%d) to (%d)\n", p.leader, leader)
				p.leader = leader
				p.SrvLdrChan <- p.leader // Send leader value to server
				p.syncPrm = false
				if leader == p.id {
					p.startPhaseOne()
				}
			case <-p.stop:
				return
			}
		}
	}()
}

// Stop stops p's main run loop.
func (p *Proposer) Stop() {
	p.stop <- struct{}{}
}

// DeliverPromise delivers promise prm to proposer p.
func (p *Proposer) DeliverPromise(prm Promise) {
	p.promiseIn <- prm
}

// DeliverClientValue delivers client value cval from to proposer p.
func (p *Proposer) DeliverClientValue(cval Value) {
	p.cvalIn <- cval
}

// IncrementAllDecidedUpTo increments the Proposer's adu variable by one.
func (p *Proposer) IncrementAllDecidedUpTo() {
	p.incDcd <- struct{}{}
}

// Internal: handlePromise processes promise prm according to the Multi-Paxos
// algorithm. If handling the promise results in proposer p emitting a
// corresponding accept slice, then output will be true and accs contain the
// accept messages. If handlePromise returns false as output, then accs will be
// a nil slice. See the Lab 5 text for a more complete specification.
func (p *Proposer) handlePromise(prm Promise) (accs []Accept, output bool) {
	// TODO(student)
	if prm.Rnd == p.crnd && !p.syncPrm {
		prevPrm := p.promises[prm.From]
		if prevPrm != nil && prevPrm.Rnd < prm.Rnd {
			p.promises[prm.From] = &prm // New promise from an old acceptor
			p.updatePrmSlots(prm.Slots)
		} else if prevPrm == nil {
			p.promises[prm.From] = &prm // New promise from a new acceptor
			p.updatePrmSlots(prm.Slots)
			p.promiseCount++
		}

		// Assert majority reached and then generate accept if assertion is true
		if p.promiseCount >= p.quorum {
			p.syncPrm = true
			if len(p.prmSlots) > 0 {
				accepts := p.genAcceptMsg()
				return accepts, true
			}

			return []Accept{}, true
		}
	}

	return nil, false
}

// Internal: increaseCrnd increases proposer p's crnd field by the total number
// of Paxos nodes.
func (p *Proposer) increaseCrnd() {
	p.crnd = p.crnd + Round(p.n)
}

// Internal: startPhaseOne resets all Phase One data, increases the Proposer's
// crnd and sends a new Prepare with Slot as the current adu.
func (p *Proposer) startPhaseOne() {
	p.phaseOneDone = false
	p.promises = make([]*Promise, p.n)
	p.promiseCount = 0
	p.increaseCrnd()
	//fmt.Printf("[Proposer]: start PhaseOne with Round = (%d) Slot = (%d) \n", p.crnd, p.adu)
	p.prepareOut <- Prepare{From: p.id, Slot: p.adu, Crnd: p.crnd}
	p.phaseOneProgressTicker = time.NewTicker(time.Second) // Start timer
}

// Internal: sendAccept sends an accept from either the accept out queue
// (generated after Phase One) if not empty, or, it generates an accept using a
// value from the client request queue if not empty. It does not send an accept
// if the previous slot has not been decided yet.
func (p *Proposer) sendAccept() {
	const alpha = 1
	if !(p.nextSlot <= p.adu+alpha) {
		// We must wait for the next slot to be decided before we can
		// send an accept.
		//
		// For Lab 6: Alpha has a value of one here. If you later
		// implement pipelining then alpha should be extracted to a
		// proposer variable (alpha) and this function should have an
		// outer for loop.
		return
	}

	// Pri 1: If bounded by any accepts from Phase One -> send previously
	// generated accept and return.
	if p.acceptsOut.Len() > 0 {
		acc := p.acceptsOut.Front().Value.(Accept)
		p.acceptsOut.Remove(p.acceptsOut.Front())
		fmt.Printf("[Proposer]: send Accept got from Phase One. %v \n", acc.String())
		p.acceptOut <- acc
		p.nextSlot++
		return
	}

	// Pri 2: If any client request in queue -> generate and send
	// accept.
	if p.requestsIn.Len() > 0 {
		cval := p.requestsIn.Front().Value.(Value)
		p.requestsIn.Remove(p.requestsIn.Front())
		acc := Accept{
			From: p.id,
			Slot: p.nextSlot,
			Rnd:  p.crnd,
			Val:  cval,
		}
		p.nextSlot++
		p.acceptOut <- acc
		fmt.Printf("[Proposer]: send Accept with client value. %v \n", acc.String())
	}
}

// Update Promise slots state
func (p *Proposer) updatePrmSlots(prmSlots []PromiseSlot) {
	slot := PromiseSlot{}

	for _, slot = range prmSlots {
		prevSlot, ok := p.prmSlots[int(slot.ID)]
		if ok {
			if prevSlot.Vrnd < slot.Vrnd {
				p.prmSlots[int(slot.ID)] = slot
			}
		} else {
			if len(p.prmSlots) == 0 {
				p.minSeenSlotVal = int(slot.ID) // Register lowest seen slot value index
			}

			p.prmSlots[int(slot.ID)] = slot
		}

		if int(slot.ID) > p.maxSeenSlotVal {
			p.maxSeenSlotVal = int(slot.ID) // Register highest seen slot value index
		}
	}
}

// Generate Accept message(s)
func (p *Proposer) genAcceptMsg() []Accept {
	var accepts []Accept
	var val Value

	for slotID := p.minSeenSlotVal; slotID <= p.maxSeenSlotVal; slotID++ {
		if slotID > int(p.adu) {
			prm, ok := p.prmSlots[slotID]
			if !ok {
				val = Value{Noop: true}
			} else {
				val = prm.Vval
			}

			acc := Accept{From: p.id, Slot: SlotID(slotID), Rnd: p.crnd, Val: val}
			accepts = append(accepts, acc)
		}
	}

	return accepts
}
