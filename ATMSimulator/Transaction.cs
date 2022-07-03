using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSimulator
{
	//Interface defined so that it can be inherited in the Bank and ATM classes
    public interface iTransaction
	{
		public void InsertTransaction(Transaction transaction);
	}

	//Variables for values to be stored while recording a transaction
	public class Transaction
	{
		public int TransactionAcctNo { get; set; }
		public DateTime TransactionDate { get; set; }
		public TransactionType transactiontype { get; set; }
		public string Description { get; set; }
    }

	//Enumerations for various transaction types
	public enum TransactionType
	{
		None,
		Deposit,
		Withdrawal,
		AccountCreated,
		Datasaved,
		CheckBalance,
		NewAccountCreated
	}
}
