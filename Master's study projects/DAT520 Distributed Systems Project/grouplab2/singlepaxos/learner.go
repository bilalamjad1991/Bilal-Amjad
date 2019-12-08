// +build !solution

package singlepaxos

// Learner represents a learner as defined by the single-decree Paxos
// algorithm.
type Learner struct {
	id          int           
	total_nodes int           
	quorum      int           
	chosenVal   Value         
	learned     map[int]Learn 
	learnIn     chan Learn   
	valOut      chan<- Value  
	stop        chan bool     
}

// NewLearner returns a new single-decree Paxos learner. It takes the
// following arguments:
//
// id: The id of the node running this instance of a Paxos learner.
//
// nrOfNodes: The total number of Paxos nodes.
//
// valueOut: A send only channel used to send values that has been learned,
// i.e. decided by the Paxos nodes.
func NewLearner(id int, nrOfNodes int, valueOut chan<- Value) *Learner {
	return &Learner{
		id:          id,
		total_nodes: nrOfNodes,
		quorum:      (nrOfNodes / 2) + 1,
		chosenVal:   ZeroValue,
		learned:     make(map[int]Learn, nrOfNodes),
		learnIn:     make(chan Learn),
		valOut:      valueOut,
		stop:        make(chan bool),
	}
}

// Start starts l's main run loop as a separate goroutine. The main run loop
// handles incoming learn messages.
func (l *Learner) Start() {
	go func() {
		for {
			select {
			case lrn := <-l.learnIn:
				val, out := l.handleLearn(lrn)
				if out {
					l.valOut <- val
					l.learned = map[int]Learn{}
				}
			case <-l.stop:
				return
			}
		}
	}()
}

// Stop stops l's main run loop.
func (l *Learner) Stop() {
	l.stop <- true
}

// DeliverLearn delivers learn lrn to learner l.
func (l *Learner) DeliverLearn(lrn Learn) {
	l.learnIn <- lrn
}

// Internal: handleLearn processes learn lrn according to the single-decree
// Paxos algorithm. If handling the learn results in learner l emitting a
// corresponding decided value, then output will be true and val contain the
// decided value. If handleLearn returns false as output, then val will have
// its zero value.
func (l *Learner) handleLearn(learn Learn) (val Value, output bool) {
	prevLearn, ok := l.learned[learn.From]
	if !ok || learn.Rnd > prevLearn.Rnd {
		l.learned[learn.From] = learn
	}

	chosenVal, out := l.chosenValue()
	return chosenVal, out
}

func (l *Learner) chosenValue() (Value, bool) {
	lrnCount := make(map[int]int)
	lrnVal := make(map[int]Value)

	for _, lrn := range l.learned {
		lrnCount[int(lrn.Rnd)]++
		lrnVal[int(lrn.Rnd)] = lrn.Val
	}

	for chosenRnd, chosenVal := range lrnVal {
		if lrnCount[int(chosenRnd)] >= l.quorum {
			return chosenVal, true
		}
	}
	return ZeroValue, false
}
