// +build !solution

package singlepaxos

import (
	dtr "github.com/uis-dat520-s18/glabs/grouplab1/detector"
	"time"
)

// Proposer represents a proposer as defined by the single-decree Paxos
// algorithm.
type Proposer struct {
	crnd        Round
	clientValue Value

	id            int             
	total_nodes   int             
	quorum        int             
	promises      map[int]Promise 
	prepareOut    chan<- Prepare  
	promiseIn     chan Promise    
	acceptOut     chan<- Accept   
	clientValIn   chan Value      
	syncProposer  bool
	ld            dtr.LeaderDetector 
	currLdr       int                
	ldrSubcr      <-chan int         
	delay         time.Duration      
	timeoutSignal *time.Ticker       
	stop          chan bool          
}

// NewProposer returns a new single-decree Paxos proposer.
// It takes the following arguments:
//
// id: The id of the node running this instance of a Paxos proposer.
//
// nrOfNodes: The total number of Paxos nodes.
//
// ld: A leader detector implementing the detector.LeaderDetector interface.
//
// prepareOut: A send only channel used to send prepares to other nodes.
//
// The proposer's internal crnd field should initially be set to the value of
// its id.
func NewProposer(id int, nrOfNodes int, ld dtr.LeaderDetector, prepareOut chan<- Prepare, acceptOut chan<- Accept) *Proposer {
	return &Proposer{
		crnd:          Round(id),
		id:            id,
		total_nodes:   nrOfNodes,
		quorum:        (nrOfNodes / 2) + 1,
		promises:      make(map[int]Promise, nrOfNodes),
		prepareOut:    prepareOut,
		promiseIn:     make(chan Promise),
		acceptOut:     acceptOut,
		clientValIn:   make(chan Value),
		ld:            ld,
		currLdr:       id,
		ldrSubcr:      make(chan int),
		delay:         2 * time.Second,
		timeoutSignal: time.NewTicker(2 * time.Second),
		stop:          make(chan bool),
	}
}

// Start starts p's main run loop as a separate goroutine. The main run loop
// handles incoming promise messages and leader detector trust messages.
func (p *Proposer) Start() {
	go func() {
		p.ldrSubcr = p.ld.Subscribe()

		for {
			select {
			case gotLeader := <-p.ldrSubcr:
				p.currLdr = gotLeader
			case prm := <-p.promiseIn:
				accept, out := p.handlePromise(prm)
				if out && !p.syncProposer {
					p.acceptOut <- accept
					p.syncProposer = true
				}
			case clVal := <-p.clientValIn:
				if p.currLdr == p.id {
					p.clientValue = clVal
					p.sendPrepare()
					p.syncProposer = false
				}
			case <-p.timeoutSignal.C:
				if !p.majorityReached() && !p.syncProposer {
					p.sendPrepare()
				}
			case <-p.stop:
				return
			}
		}
	}()
}

// Stop stops p's main run loop.
func (p *Proposer) Stop() {
	p.stop <- true
}

// DeliverPromise delivers promise prm to proposer p.
func (p *Proposer) DeliverPromise(prm Promise) {
	p.promiseIn <- prm
}

// DeliverClientValue delivers client value val from to proposer p.
func (p *Proposer) DeliverClientValue(val Value) {
	p.clientValIn <- val
}

// Internal: handlePromise processes promise prm according to the single-decree
// Paxos algorithm. If handling the promise results in proposer p emitting a
// corresponding accept, then output will be true and acc contain the promise.
// If handlePromise returns false as output, then prm will be a zero-valued
// struct.
func (p *Proposer) handlePromise(prm Promise) (acc Accept, output bool) {
	if prm.Rnd == p.crnd {
		prevPromise, ok := p.promises[prm.From]
		if !ok {
			p.promises[prm.From] = prm
			if prm.Vrnd != NoRound && prm.Vval != ZeroValue {
				if !p.valueWithHighRndExist(prm) {
					p.clientValue = prm.Vval
				}
			}
		} else {
			if prevPromise.Rnd < prm.Rnd {
				p.promises[prm.From] = prm
				if prevPromise.Vrnd < prm.Vrnd {
					p.clientValue = prm.Vval
				}
			} else if prevPromise.Vrnd < prm.Vrnd {
				p.clientValue = prm.Vval
			}
		}
		//accept if majority accept
		if p.majorityReached() {
			accept := Accept{p.id, p.crnd, p.clientValue}
			return accept, true
		} else {
			return Accept{}, false
		}
	}
	return Accept{}, false
}

// Internal: increaseCrnd increases proposer p's crnd field by the total number
// of Paxos nodes.
func (p *Proposer) increaseCrnd() {
	p.crnd += Round(p.total_nodes)
}


func (p *Proposer) majorityReached() bool {
	recvCount := 0

	for _, prm := range p.promises {
		if prm.Rnd == p.crnd {
			recvCount++
		}
	}

	if recvCount >= p.quorum {
		return true
	}

	return false
}

func (p *Proposer) valueWithHighRndExist(promise Promise) bool {
	for _, pm := range p.promises {
		if pm.Vrnd > promise.Vrnd {
			return true
		}
	}

	return false
}

func (p *Proposer) sendPrepare() {
	if len(string(p.clientValue)) > 0 {
		p.increaseCrnd()
		prepare := Prepare{p.id, p.crnd}
		p.prepareOut <- prepare
		p.timeoutSignal = time.NewTicker(p.delay)
	}
}
