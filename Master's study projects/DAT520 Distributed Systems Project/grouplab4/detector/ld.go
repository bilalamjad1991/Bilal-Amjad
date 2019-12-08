// +build !solution

package detector

import "time"

// A MonLeaderDetector represents a Monarchical Eventual Leader Detector as
// described at page 53 in:
// Christian Cachin, Rachid Guerraoui, and Luís Rodrigues: "Introduction to
// Reliable and Secure Distributed Programming" Springer, 2nd edition, 2011.
type MonLeaderDetector struct {
	currLeader  int          // current leader
	nodeIDs     []int        // node ids for every node in cluster
	suspected   map[int]bool // map of node ids  considered suspected
	subscribers []chan int   // subscribers for leader trust publication
}

// NewMonLeaderDetector returns a new Monarchical Eventual Leader Detector
// given a list of node ids.
func NewMonLeaderDetector(nodeIDs []int) *MonLeaderDetector {

	m := &MonLeaderDetector{
		currLeader: UnknownID,
		nodeIDs:    nodeIDs,
		suspected:  make(map[int]bool),
	}
	go m.ForceSubscribe()
	return m
}

func (m *MonLeaderDetector) ForceSubscribe()  {
	time.Sleep(200*time.Millisecond)
	currLdr := m.currLeader
	newLdr := m.computeNewLeader()
	if currLdr != newLdr {
		for _, subscriber := range m.subscribers {
			subscriber <- newLdr
		}
	}
	return
}
// Leader returns the current leader. Leader will return UnknownID if all nodes
// are suspected.
func (m *MonLeaderDetector) Leader() int {
	if len(m.suspected) < len(m.nodeIDs) {
		return m.computeNewLeader()
	}

	return UnknownID
}


// Suspect instructs m to consider the node with matching id as suspected. If
// the suspect indication result in a leader change the leader detector should
// this publish this change its subscribers.
func (m *MonLeaderDetector) Suspect(id int) {
	currLdr := m.currLeader
	m.suspected[id] = true
	newLdr := m.computeNewLeader()

	if currLdr != newLdr {
		for _, subscriber := range m.subscribers {
			subscriber <- newLdr
		}
	}
}

// Restore instructs m to consider the node with matching id as restored. If
// the restore indication result in a leader change the leader detector should
// this publish this change its subscribers.
func (m *MonLeaderDetector) Restore(id int) {
	currLdr := m.currLeader
	delete(m.suspected, id)
	newLdr := m.computeNewLeader()

	if currLdr != newLdr {
		for _, subscriber := range m.subscribers {
			subscriber <- newLdr
		}
	}
}

// Subscribe returns a buffered channel that m on leader change will use to
// publish the id of the highest ranking node. The leader detector will publish
// UnknownID if all nodes become suspected. Subscribe will drop publications to
// slow subscribers. Note: Subscribe returns a unique channel to every
// subscriber; it is not meant to be shared.
func (m *MonLeaderDetector) Subscribe() <-chan int {
	subscriber := make(chan int, 1)

	m.subscribers = append(m.subscribers, subscriber)

	return subscriber
}

// Compute new leader
func (m *MonLeaderDetector) computeNewLeader() int {
	highestNodeID := UnknownID

	// Exclude suspected nodes and compute leader rank
	for _, nodeID := range m.nodeIDs {
		if !m.suspected[nodeID] && highestNodeID < nodeID {
			highestNodeID = nodeID
		}
	}

	if m.currLeader != highestNodeID {
		m.currLeader = highestNodeID
	}

	return m.currLeader
}
