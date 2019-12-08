//package main
package bankApp

import (
	"encoding/json"
	"fmt"
	"github.com/gorilla/websocket"
	bank "github.com/uis-dat520-s18/glabs/grouplab4/bank"
	dtr "github.com/uis-dat520-s18/glabs/grouplab4/detector"
	mlpx "github.com/uis-dat520-s18/glabs/grouplab4/multipaxos"
	"log"
)

func (ws *WS_Server) handleExternalClientMessage(conn *websocket.Conn, ipaddr string) {
	var ext_cl_msg ExtClientMessage
	for {
		if err := conn.ReadJSON(&ext_cl_msg); err != nil {
			if websocket.IsCloseError(err, websocket.CloseNoStatusReceived,
				websocket.CloseNormalClosure, websocket.CloseAbnormalClosure,
				websocket.CloseInternalServerErr, websocket.CloseMessage, websocket.CloseGoingAway) {
				// connection closed, so delete from Clients array
				delete(ws.ExtClientConns, ipaddr)
				fmt.Printf("Socket Connection closed : %v\n", err)
				conn.Close()
				return
			}
			fmt.Printf("JSON read err: %v\n", err)
			msg := ResponseData{
				ErrorString: err.Error(),
			}
			resp := ExtClientMessage{
				Type: Error,
				Data: msg,
			}

			if err := conn.WriteJSON(resp); err != nil {
				log.Println(err)
			}

		} else {
			switch ext_cl_msg.Type {
			case Signup:
				var new_acc NewAccount
				b, err := json.Marshal(ext_cl_msg.Data)
				if err != nil {
					fmt.Printf("Marshal error: %v", err)
				}
				if err := json.Unmarshal(b, &new_acc); err != nil {
					fmt.Printf("Unmarshal error: %v", err)
				}

				new_acc.AccountNum = ws.NextAccountNumber

				buff_acc := bank.Account{
					FirstName: new_acc.FirstName,
					LastName:  new_acc.LastName,
					Password:  new_acc.Password,
					Number:    new_acc.AccountNum,
					Balance:   new_acc.Balance,
				}
				// invoke proposer
				b_txn := bank.Transaction{
					Op:            NEW_ACC,
					Amount:        new_acc.Balance,
					BufferAccount: buff_acc,
				}
				value := mlpx.Value{
					ClientID:   ipaddr, //new_acc.ClientID,
					ClientSeq:  new_acc.ClientSeq,
					AccountNum: new_acc.AccountNum,
					Noop:       false,
					Txn:        b_txn,
				}

				log.Printf("Signup request accept: %v", new_acc)
				ws.ClValInList.PushBack(value)
				ws.Proposer.DeliverClientValue(value)
			case Signin:
				var lg Login
				b, err := json.Marshal(ext_cl_msg.Data)
				if err != nil {
					fmt.Printf("Marshal error: %v", err)
				}
				if err := json.Unmarshal(b, &lg); err != nil {
					fmt.Printf("Unmarshal error: %v", err)
				}
				lg.ClientID = ipaddr
				_, ok := ws.FindAccount(lg.AccountNum)
				if !ok {
					ws.AccountDoesNotExistError(conn, lg.ClientID, lg.ClientSeq)
					break
				}
				log.Printf("Sigin request accept: %v", lg)
				go ws.handleLogin(ipaddr, lg)
			case Txn:
				var value mlpx.Value
				b, err := json.Marshal(ext_cl_msg.Data)
				if err != nil {
					fmt.Printf("Marshal error: %v", err)
				}
				if err := json.Unmarshal(b, &value); err != nil {
					fmt.Printf("Unmarshal error: %v", err)
				}
				value.ClientID = ipaddr
				// source account check
				_, ok := ws.FindAccount(value.AccountNum)
				if !ok {
					ws.AccountDoesNotExistError(conn, value.ClientID, value.ClientSeq)
					break
				}
				if value.Txn.Op == bank.Transfer {
					_, ok := ws.FindAccount(value.Txn.ToAccountNum)
					if !ok {
						ws.AccountDoesNotExistError(conn, value.ClientID, value.ClientSeq)
						break
					}
				}

				//if value.Txn.Op == bank.Transfer {
				//	// destination account check
				//	desti, ok := ws.FindAccount(value.Txn.ToAccountNum)
				//	if !ok {
				//		ws.AccountDoesNotExistError(conn, value.ClientID, value.ClientSeq)
				//		break
				//	}
				//	value.Txn.TransferTo = *desti // might cause error.. need to debug
				//}
				ws.ClValInList.PushBack(value)
				ws.Proposer.DeliverClientValue(value)
			default:
				log.Printf("Unknown data type, %v", ext_cl_msg)
			}
		}
	}
}

func (ws *WS_Server) handleInternalClientMessage(conn *websocket.Conn, ipaddr string) {
	// handle paxos related message coming from other nodes here
	var msg MsgData
	for {
		if err := conn.ReadJSON(&msg); err != nil {
			if websocket.IsCloseError(err, websocket.CloseNoStatusReceived,
				websocket.CloseNormalClosure, websocket.CloseAbnormalClosure,
				websocket.CloseInternalServerErr, websocket.CloseMessage, websocket.CloseGoingAway) {
				// connection closed, so delete from Clients array
				delete(ws.InternalClient.Conns, ipaddr)
				delete(ws.InternalClientConns, ipaddr)
				fmt.Printf("Internal Socket Connection closed : %v\n", err)
				conn.Close()
				return
			}
			//fmt.Printf("Socket Connection closed : %v\n", err)
			//delete(ws.InternalClientConns, ipaddr)
			fmt.Printf("JSON read err: %v\n", err)
			msg := ResponseData{
				ErrorString: err.Error(),
			}
			resp := ExtClientMessage{
				Type: Error,
				Data: msg,
			}

			if err := conn.WriteJSON(resp); err != nil {
				log.Println(err)
			}
		} else {
			switch msg.Type {
			case HB:
				var hb dtr.Heartbeat
				b, err := json.Marshal(msg.Data)
				if err != nil {
					fmt.Printf("Marshal error: %v", err)
				}
				if err := json.Unmarshal(b, &hb); err != nil {
					fmt.Printf("Unmarshal error: %v", err)
				}

				//log.Printf("[processor]: heartbeat received from peer node: %s \n", hb.String())
				ws.Fd.DeliverHeartbeat(hb)
			case PREPARE:
				var prepare mlpx.Prepare
				b, err := json.Marshal(msg.Data)
				if err != nil {
					fmt.Printf("Marshal error: %v", err)
				}
				if err := json.Unmarshal(b, &prepare); err != nil {
					fmt.Printf("Unmarshal error: %v", err)
				}

				log.Printf("[processor]: prepare received from peer node: %s \n", prepare.String())
				ws.Acceptor.DeliverPrepare(prepare)
			case ACCEPT:

				var accept mlpx.Accept
				b, err := json.Marshal(msg.Data)
				if err != nil {
					fmt.Printf("Marshal error: %v", err)
				}
				if err := json.Unmarshal(b, &accept); err != nil {
					fmt.Printf("Unmarshal error: %v", err)
				}

				log.Printf("[processor]: accept received from peer node: %s \n", accept.String())
				ws.Acceptor.DeliverAccept(accept)
			case PROMISE:
				var promise mlpx.Promise
				b, err := json.Marshal(msg.Data)
				if err != nil {
					fmt.Printf("Marshal error: %v", err)
				}
				if err := json.Unmarshal(b, &promise); err != nil {
					fmt.Printf("Unmarshal error: %v", err)
				}

				log.Printf("[processor]: promise received from peer node: %s \n", promise.String())
				ws.Proposer.DeliverPromise(promise)
			case LEARN:
				var learn mlpx.Learn
				b, err := json.Marshal(msg.Data)
				if err != nil {
					fmt.Printf("Marshal error: %v", err)
				}
				if err := json.Unmarshal(b, &learn); err != nil {
					fmt.Printf("Unmarshal error: %v", err)
				}

				log.Printf("[processor]: learn received from peer node: %s \n", learn.String())
				ws.Learner.DeliverLearn(learn)
			default:
				log.Printf("Unknown message Type received, %v", msg)
			}
		}
	}
}

func (ws *WS_Server) handleLogin(ipaddr string, lg Login) {
	acc, ok := ws.FindAccount(lg.AccountNum)
	log.Printf("FindAccount = %v", acc)
	resp_data := ResponseData{}
	t := "Signin"
	if !ok || acc.Password != lg.Password {
		resp_data.ClientID = lg.ClientID
		resp_data.ClientSeq = lg.ClientSeq
		resp_data.ErrorString = "Incorrect credentials. Try again."
		t = "Error"
	} else {
		resp_data.ClientID = lg.ClientID
		resp_data.ClientSeq = lg.ClientSeq
		resp_data.FirstName = acc.FirstName
		resp_data.LastName = acc.LastName
		resp_data.AccountNum = acc.Number
		resp_data.Balance = acc.Balance
		resp_data.TransactionHistory = ws.TransactionHistory[acc.Number]
	}
	resp := ExtClientMessage{
		Type: t,
		Data: resp_data,
	}
	conn, ok := ws.ExtClientConns[ipaddr]
	if ok {
		if err := conn.WriteJSON(resp); err != nil {
			log.Println(err)
		}
	}
	return
}

func (ws *WS_Server) FindAccount(acc_num int) (*bank.Account, bool) {
	acc, ok := ws.BankAccounts[acc_num]
	if !ok {
		return &bank.Account{}, false
	}
	return acc, true
}

func (ws *WS_Server) CreateNewAccount(acc bank.Account) *bank.Account {
	new_acc := bank.NewAccount()
	new_acc.FirstName = acc.FirstName
	new_acc.LastName = acc.LastName
	new_acc.Password = acc.Password
	new_acc.Number = ws.NextAccountNumber
	new_acc.Balance = acc.Balance
	ws.NextAccountNumber += 1
	return new_acc
}

func (ws *WS_Server) processChosenValue(chosen_val mlpx.DecidedValue) {
	conn := ws.ExtClientConns[chosen_val.Value.ClientID]
	acc_num := chosen_val.Value.AccountNum
	txn_type := chosen_val.Value.Txn.Op
	log.Printf("Chosen value Trasaction type = %d", txn_type)
	if txn_type == bank.Create {
		acc_buff := chosen_val.Value.Txn.BufferAccount
		new_acc := ws.CreateNewAccount(acc_buff)
		ws.BankAccounts[new_acc.Number] = new_acc

		s_data := ResponseData{
			ClientID:   chosen_val.Value.ClientID,
			ClientSeq:  chosen_val.Value.ClientSeq,
			FirstName:  new_acc.FirstName,
			LastName:   new_acc.LastName,
			AccountNum: new_acc.Number,
			Balance:    new_acc.Balance,
		}
		resp_data := ExtClientMessage{
			Type: Signup,
			Data: s_data,
		}

		txn_log := TransactionLog{
			Txn: resp_data,
		}
		ws.TransactionHistory[new_acc.Number] = append(ws.TransactionHistory[new_acc.Number], txn_log)

		if ws.CurrentLeader == ws.ID && conn != nil {
			if err := conn.WriteJSON(resp_data); err != nil {
				log.Println(err)
			}
		}

	} else {
		acc, _ := ws.FindAccount(acc_num)
		if txn_type == bank.Transfer {
			desti, _ := ws.FindAccount(chosen_val.Value.Txn.ToAccountNum)
			chosen_val.Value.Txn.TransferTo = desti
		}
		txnResult := acc.Process(chosen_val.Value.Txn) // Send transaction to bank for processing
		log.Printf("Transaction Error = %s", txnResult.ErrorString)
		if txnResult.ErrorString != "" {
			msg := ResponseData{
				ClientID:    chosen_val.Value.ClientID,
				ClientSeq:   chosen_val.Value.ClientSeq,
				ErrorString: txnResult.ErrorString,
			}
			resp := ExtClientMessage{
				Type: Error,
				Data: msg,
			}
			if ws.CurrentLeader == ws.ID && conn != nil {
				if err := conn.WriteJSON(resp); err != nil {
					log.Println(err)
				}
			}
		} else {
			//if txn_type == bank.Transfer {
			//	ws.BankAccounts[txnResult.ToAccountNum] = txnResult.ToAccount
			//	fmt.Printf("Account [%d] Balance [%d]\n", txnResult.ToAccount.Number, txnResult.ToAccount.Balance)
			//}

			op_type := GetTransactionType(txn_type)
			resp_data := ResponseData{
				ClientID:   chosen_val.Value.ClientID,
				ClientSeq:  chosen_val.Value.ClientSeq,
				AccountNum: acc.Number,
				Balance:    acc.Balance,
			}
			if op_type == Deposit || op_type == Withdraw || op_type == Transfer {
				resp_data.Amount = chosen_val.Value.Txn.Amount
			}
			if op_type == Transfer {
				resp_data.ToAccountNumber = txnResult.ToAccountNum
				resp_data.Amount = txnResult.TransferAmount
			}
			resp := ExtClientMessage{
				Type: op_type,
				Data: resp_data,
			}

			txn_log := TransactionLog{
				Txn: resp,
			}
			ws.TransactionHistory[acc.Number] = append(ws.TransactionHistory[acc.Number], txn_log)

			if ws.CurrentLeader == ws.ID && conn != nil {
				//log.Printf("[processor] Processing transaction: %v \n", chosen_val)
				if err := conn.WriteJSON(resp); err != nil {
					log.Println(err)
				}
			}
		}
	}
}

func (ws *WS_Server) AccountDoesNotExistError(conn *websocket.Conn, cid string, seq int) {
	msg := ResponseData{
		ClientID:    cid,
		ClientSeq:   seq,
		ErrorString: "Account does not exist. Check and try again",
	}
	resp := ExtClientMessage{
		Type: Error,
		Data: msg,
	}
	if ws.CurrentLeader == ws.ID && conn != nil {
		if err := conn.WriteJSON(resp); err != nil {
			log.Println(err)
		}
	}
}

func (ws *WS_Server) LeaderRedirect(conn *websocket.Conn, cid string, seq int) {
	msg := ResponseData{
		ClientID:  cid,
		ClientSeq: seq,
		LeaderUrl: IDToAddrMap[ws.CurrentLeader],
	}
	resp := ExtClientMessage{
		Type: Redirect,
		Data: msg,
	}
	if err := conn.WriteJSON(resp); err != nil {
		log.Println(err)
	}
	conn.Close()
}
