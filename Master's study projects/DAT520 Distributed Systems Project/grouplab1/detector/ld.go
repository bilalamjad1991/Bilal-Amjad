// +build !solution

package detector

// A MonLeaderDetector represents a Monarchical Eventual Leader Detector as
// described at page 53 in:
// Christian Cachin, Rachid Guerraoui, and Luís Rodrigues: "Introductituon to
// Reliable and Secure Distributed Programming" Springer, 2nd edition, 2011.
type MonLeaderDetector struct {
	nodes       []int
	leader      int // map of node ids considered alive
	suspected   map[int]bool
	subscribers []chan<- int
}

// NewMonLeaderDetector returns a new Monarchical Eventual Leader Detector
//// given a list of node ids.
func NewMonLeaderDetector(nodeIDs []int) *MonLeaderDetector {
	m := &MonLeaderDetector{}
	m.suspected = make(map[int]bool)
	m.nodes = nodeIDs
	m.getLeader()
	return m
}

// Leader returns the current leader. Leader will return UnknownID if all nodes
// are suspected.
func (m *MonLeaderDetector) Leader() int {
	return m.leader
}

// Suspect instructs m to consider the node with matching id as suspected. If
// the suspect indication result in a leader change the leader detector should
// this publish this change its subscribers.
func (m *MonLeaderDetector) Suspect(id int) {
	m.suspected[id] = true
	oldLeader := m.leader
	m.getLeader()
	if oldLeader != m.leader {
		m.sendToSubscribe()
	}
}

// Restore instructs m to consider the node with matching id as restored. If
// the restore indication result in a leader change the leader detector should
// this publish this change its subscribers.
func (m *MonLeaderDetector) Restore(id int) {
	delete(m.suspected, id)
	oldLeader := m.leader
	m.getLeader()
	if oldLeader != m.leader {
		m.sendToSubscribe()
	}

}

// Subscribe returns a buffered channel that m on leader change will use to
// publish the id of the highest ranking node. The leader detector will publish
// UnknownID if all nodes become suspected. Subscribe will drop publications to
// slow subscribers. Note: Subscribe returns a unique channel to every
// subscriber; it is not meant to be shared.
func (m *MonLeaderDetector) Subscribe() <-chan int {
	buffer := make(chan int, 1)
	m.subscribers = append(m.subscribers, buffer)
	return buffer
}

// TODO(student): Add other unexported functions or methods if needed.
func (m *MonLeaderDetector) getLeader() int {
	lead := UnknownID
	for _, id := range m.nodes {
		if id > lead && !m.suspected[id] {
			lead = id
		}
	}
	m.leader = lead
	//m.sendToSubscribe()
	return lead
}

func (m *MonLeaderDetector) sendToSubscribe() {
	for _, ch := range m.subscribers {
		ch <- m.leader
	}

}
