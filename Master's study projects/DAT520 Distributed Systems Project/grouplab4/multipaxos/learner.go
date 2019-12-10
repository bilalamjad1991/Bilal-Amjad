// +build !solution

package multipaxos

// Learner represents a learner as defined by the Multi-Paxos algorithm.
type Learner struct {
	// TODO(student)
	id     int // This node ID
	n      int // Number of nodes
	quorum int // Quorum value

	learnIn    chan Learn          // Channel to recv Learn message
	decidedOut chan<- DecidedValue // Channel to send decided value
	stop       chan struct{}       // Channel for signalling a stop request to the start run loop
	learns     map[string]Learn    // receiving learn holder
}

// NewLearner returns a new single-decree Paxos learner. It takes the
// following arguments:
//
// id: The id of the node running this instance of a Paxos learner.
//
// nrOfNodes: The total number of Paxos nodes.
//
// decidedOut: A send only channel used to send values that has been learned,
// i.e. decided by the Paxos nodes.
func NewLearner(id int, nrOfNodes int, decidedOut chan<- DecidedValue) *Learner {
	return &Learner{
		// TODO(student)
		id:     id,
		n:      nrOfNodes,
		quorum: (nrOfNodes / 2) + 1,

		learnIn:    make(chan Learn),
		decidedOut: decidedOut,
		stop:       make(chan struct{}),
		learns:     make(map[string]Learn),
	}
}

// Start starts l's main run loop as a separate goroutine. The main run loop
// handles incoming learn messages.
func (l *Learner) Start() {
	go func() {
		for {
			// TODO(student)
			select {
			case lrn := <-l.learnIn:
				val, slotID, output := l.handleLearn(lrn)
				if output {
					l.decidedOut <- DecidedValue{SlotID: slotID, Value: val}
				}
			case <-l.stop:
				return
			}
		}
	}()
}

// Stop stops l's main run loop.
func (l *Learner) Stop() {
	// TODO(student)
	l.stop <- struct{}{}
}

// DeliverLearn delivers learn lrn to learner l.
func (l *Learner) DeliverLearn(lrn Learn) {
	// TODO(student)
	l.learnIn <- lrn
}

// Internal: handleLearn processes learn lrn according to the Multi-Paxos
// algorithm. If handling the learn results in learner l emitting a
// corresponding decided value, then output will be true, sid the id for the
// slot that was decided and val contain the decided value. If handleLearn
// returns false as output, then val and sid will have their zero value.
func (l *Learner) handleLearn(learn Learn) (val Value, sid SlotID, output bool) {
	keyFromSlotID := genLearnKey(learn)

	prevLrn, ok := l.learns[keyFromSlotID]
	if (ok && learn.Rnd > prevLrn.Rnd) || !ok {
		l.learns[keyFromSlotID] = learn
	}

	return l.getChosenValue()
}

func genLearnKey(learn Learn) string {
	return string(learn.From) + "_" + string(learn.Slot)
}

func (l *Learner) getChosenValue() (Value, SlotID, bool) {
	rndCount := make(map[int]int)
	rndSlot := make(map[int][]SlotID)
	slotCount := make(map[int]int)
	rndSltVal := make(map[string]Value)

	for _, lrn := range l.learns {
		rndCount[int(lrn.Rnd)]++
		slotCount[int(lrn.Slot)]++
		key := string(lrn.Rnd) + "_" + string(lrn.Slot)
		rndSltVal[key] = lrn.Val

		rslt, ok := rndSlot[int(lrn.Rnd)]
		if ok {
			rndSlot[int(lrn.Rnd)] = append(rslt, lrn.Slot)
		} else {
			rndSlot[int(lrn.Rnd)] = []SlotID{lrn.Slot}
		}
	}

	for rnd, cnt := range rndCount {
		if cnt >= l.quorum {
			for slt, count := range slotCount {
				if count >= l.quorum {
					ok := l.isFromMajRnd(rndSlot[rnd], slt)
					if ok {
						// delete learn from the learns map if the value is learned
						// if does not delete, will give unexpected results as these learns
						// will always form a quorum of learns
						l.deleteLearnFor(Round(rnd), SlotID(slt))

						key := string(rnd) + "_" + string(slt)
						return rndSltVal[key], SlotID(slt), true
					}
				}
			}
		}
	}
	return Value{}, 0, false

}

func (l *Learner) isFromMajRnd(rndSlot []SlotID, slt int) bool {
	count := 0
	for _, sl := range rndSlot {
		if int(sl) == slt {
			count++
		}
		if count >= l.quorum {
			return true
		}
	}
	return false
}

func (l *Learner) deleteLearnFor(rnd Round, slt SlotID) {
	for k, lrn := range l.learns {
		if lrn.Rnd == rnd && lrn.Slot == slt {
			delete(l.learns, k)
		}
	}
}
