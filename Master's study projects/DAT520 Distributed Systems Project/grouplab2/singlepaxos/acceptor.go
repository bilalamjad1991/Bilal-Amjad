// +build !solution

package singlepaxos

// Acceptor represents an acceptor as defined by the single-decree Paxos
// algorithm.
type Acceptor struct {
	Vrnd   Round // Previous voted round
	Vval   Value // Previous voted value
	AccRnd Round // Accepted round so far

	id         int
	prepareIn  chan Prepare   
	promiseOut chan<- Promise
	acceptIn   chan Accept    
	learnOut   chan<- Learn   
	stop       chan bool      
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
		id:         id,
		Vrnd:       NoRound,
		Vval:       ZeroValue,
		AccRnd:     NoRound,
		prepareIn:  make(chan Prepare),
		acceptIn:   make(chan Accept),
		promiseOut: promiseOut,
		learnOut:   learnOut,
		stop:       make(chan bool),
	}
}

// Start starts a's main run loop as a separate goroutine. The main run loop
// handles incoming prepare and accept messages.
func (a *Acceptor) Start() {
	go func() {
		for {
			select {
			case prp := <-a.prepareIn:
				prm, out := a.handlePrepare(prp)
				if out {
					a.promiseOut <- prm
				}
			case acc := <-a.acceptIn:
				lrn, out := a.handleAccept(acc)
				if out {
					a.learnOut <- lrn
				}
			case <-a.stop:
				return
			}
		}
	}()
}

// Stop stops a's main run loop.
func (a *Acceptor) Stop() {
	a.stop <- true
}

// DeliverPrepare delivers prepare prp to acceptor a.
func (a *Acceptor) DeliverPrepare(prp Prepare) {
	a.prepareIn <- prp
}

// DeliverAccept delivers accept acc to acceptor a.
func (a *Acceptor) DeliverAccept(acc Accept) {
	a.acceptIn <- acc
}

// Internal: handlePrepare processes prepare prp according to the single-decree
// Paxos algorithm. If handling the prepare results in acceptor a emitting a
// corresponding promise, then output will be true and prm contain the promise.
// If handlePrepare returns false as output, then prm will be a zero-valued
// struct.
func (a *Acceptor) handlePrepare(prp Prepare) (prm Promise, output bool) {
	if prp.Crnd > a.AccRnd {
		a.AccRnd = prp.Crnd
		promise := Promise{prp.From, a.id, a.AccRnd, a.Vrnd, a.Vval}
		return promise, true
	} else {
		return Promise{}, false
	}
}

// Internal: handleAccept processes accept acc according to the single-decree
// Paxos algorithm. If handling the accept results in acceptor a emitting a
// corresponding learn, then output will be true and lrn contain the learn.  If
// handleAccept returns false as output, then lrn will be a zero-valued struct.
func (a *Acceptor) handleAccept(acc Accept) (lrn Learn, output bool) {
	if acc.Rnd >= a.AccRnd { 
		a.Vrnd = acc.Rnd
		a.Vval = acc.Val
		a.AccRnd = acc.Rnd

		learn := Learn{a.id, a.Vrnd, a.Vval}
		return learn, true
	} else {
		return Learn{}, false
	}
}

//TODO(student): Add any other unexported methods needed.
