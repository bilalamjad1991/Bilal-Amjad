package bank

import (
	"fmt"
	"log"
)

// Operation represents a transaction type.
type Operation int

const (
	Balance    Operation = iota // 0
	Deposit                     // 1
	Withdrawal                  // 2
	Transfer                    // 3
	Create                      // 4
)

var ops = [...]string{
	"Balance",
	"Deposit",
	"Withdrawal",
	"Transfer",
	"Create",
}

// String returns a string representation of Operation o.
func (o Operation) String() string {
	if o < 0 || o > 4 {
		return fmt.Sprintf("Unknow operation (%d)", o)
	}
	return ops[o]
}

// Transaction represents a bank transaction with an operation type and amount.
// If Op == Balance then the Amount field should be ignored.
// if Op == Transfer then need to transfer amount to ToAccNum
type Transaction struct {
	Op            Operation `json:"op"`
	Amount        int       `json:"amount,omitempty"`
	BufferAccount Account   `json:"buffer_account,omitempty"`
	ToAccountNum  int       `json:"to_account_num,omitempty"`
	TransferTo    *Account  `json:"transfer_to,omitempty"` // to transfer amount to
}

// String returns a string representation of Transaction t.
func (t Transaction) String() string {
	switch t.Op {
	case Balance:
		return "Balance transaction"
	case Deposit, Withdrawal:
		return fmt.Sprintf("%s transaction with amount %d NOK", t.Op, t.Amount)
	case Transfer:
		return fmt.Sprintf("%s transfer with amount %d NOK to %d", t.Op, t.Amount, t.TransferTo)
	case Create:
		return fmt.Sprintf("%s create new account  with initial amount %d NOK", t.Op, t.Amount)
	default:
		return fmt.Sprintf("Unknown transaction type (%d)", t.Op)
	}
}

// TransactionResult represents a result of processing a Transaction for an
// account with AcccountNum. Any error processing the transaction is reported
// in the ErrorString field. If an error is reported then the Balance field
// should be ignored.
type TransactionResult struct {
	AccountNum     int      `json:"account_num,omitempty"`
	Balance        int      `json:"balance,omitempty"`
	ToAccountNum   int      `json:"to_account_num,omitempty"`
	ToAccount      *Account `json:"to_account,omitempty"`      // account to transfer amount to
	TransferAmount int      `json:"transfer_amount,omitempty"` // amount to transfer
	ErrorString    string   `json:"error_string,omitempty"`
}

// String returns a string representation of TransactionResult tr.
func (tr TransactionResult) String() string {
	if tr.ErrorString == "" {
		return fmt.Sprintf("Transaction OK. Account: %d. Balance: %d NOK", tr.AccountNum, tr.Balance)
	}
	return fmt.Sprintf("Transaction error for account %d. Error: %s", tr.AccountNum, tr.ErrorString)
}

// Account represents a bank account with an account number an balance.
type Account struct {
	FirstName string `json:"first_name"`
	LastName  string `json:"last_name"`
	Password  string `json:"password"`
	Number    int    `json:"number"`
	Balance   int    `json:"balance"`
}

// create a new account
func NewAccount() *Account {
	return &Account{}
}

// Process applies transaction txn to Account a and returns a corresponding
// TransactionResult.
func (a *Account) Process(txn Transaction) TransactionResult {
	var err string
	switch txn.Op {
	case Balance:
	case Deposit:
		err = a.Deposit(txn.Amount)

	case Withdrawal:
		err = a.Withdraw(txn.Amount)

	case Transfer:
		w_err := a.Withdraw(txn.Amount)
		if w_err != "" {
			log.Printf("Transfer cannot proceed. Withdrwal failed\n")
			err = w_err
			break
		}
		log.Printf("Transfer continue. Withdrwal passed. current balance = %d\n", a.Balance)

		d_err := txn.TransferTo.Deposit(txn.Amount)
		log.Printf("Transfer Done. Current balance of account [%d] = %d\n", txn.TransferTo.Number, txn.TransferTo.Balance)
		if d_err != "" {
			log.Printf("Transfer cannot proceed. deposit to destination failed\n")
			d_err = a.Deposit(txn.Amount)
			err = fmt.Sprintf("Transfer to %d failed, Try again.", txn.TransferTo.Number)
		}

	default:
		err = fmt.Sprintf("%v", txn)
	}

	txnResult := TransactionResult{
		AccountNum: a.Number,
		Balance:    a.Balance,
	}
	if txn.Op == Transfer {
		log.Printf("==== account [%d] = %d\n", txn.TransferTo.Number, txn.TransferTo.Balance)
		txnResult.ToAccount = txn.TransferTo
		txnResult.TransferAmount = txn.Amount
	}
	if err != "" {
		txnResult.ErrorString = err
	}
	return txnResult
}

// String returns a string representation of Account a.
func (a Account) String() string {
	return fmt.Sprintf("Account %d: %d NOK", a.Number, a.Balance)
}

func (a *Account) Withdraw(amount int) string {
	if a.Balance-amount >= 0 {
		a.Balance -= amount
		return ""
	}
	err := fmt.Sprintf("Not enough funds for withdrawal. Balance: %d NOK - Requested %d NOK",
		a.Balance, amount)
	return err

}

func (a *Account) Deposit(amount int) string {
	if amount < 0 {
		err := fmt.Sprintf("Can't deposit negative amount (%d NOK)", amount)
		return err
	}
	a.Balance += amount
	return ""
}
