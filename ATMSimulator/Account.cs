using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ATMSimulator
{
    //Exception class used when an invalid trasaction is performed
    [Serializable]
    public class InvalidTransaction : Exception
    {
        public InvalidTransaction() { }

        public InvalidTransaction(string errormessage) : base(errormessage) 
        {
            Console.WriteLine(errormessage);
        }
    }

    //Exception class used when an invalid value is entered
    [Serializable]
    public class InvalidValue : Exception
    {
        public InvalidValue() { }

        public InvalidValue(string errormessage) : base(errormessage) 
        { 
            Console.WriteLine(errormessage);
        }
    }

    /* The Account class is used by the Bank moodule. It defines the bank account and its corresponding attributes
     * epresents an ATM machine. The class displays the main menu and the account menu */
    public class Account
    {
        /*Define a bank account and its associated attributes

        Attributes:
        acctNumber      : int      -- the account number, read-only attribute
        acctHolderName  : string   -- the name of the account holder, read-only attribute
        acctBalance     : double   -- the account balance that gets affected by withdrawls and deposits
        annualIntrRate  : double   -- the annual interest rate applicable on the balance
        */

        private string accttype;
        private int acctno;
        private string accountname;
        private double acctbal;
        private double intrate;

        public string acctType
        {
            get { return accttype; }
            set { this.accttype = value; }
        }
        public int acctNumber 
        { 
            get { return this.acctno; }
            set { this.acctno = value; }
        }
        public string acctHolderName 
        {
            get { return this.accountname; }
            set { this.accountname = value; }
        }
        public double acctBalance 
        {
            get { return this.acctbal; }
            set { this.acctbal = value; }
        }
        public double annualIntrRate 
        {
            get { return this.intrate; }
            set { this.intrate = value / 100; }
        }

        /* Constructor Class - initialize the account attributes
         * The account constructor requires the caller to supply an account number and the name of the account holder 
         * in order to create an account. 
         * The constructor assigns default values to each parameter allowing the code not to supply them (i.e. acct = Account()). 
         * If the calling code does not supply values for the two parameters they will receive these default values. This is used 
         * when the accounts are created from data files
         */

        public Account (string _accttype = "Account", int _acctNumber = -1, string _acctHolderName = " ")
        {
            this.accttype = _accttype;
            this.acctNumber = _acctNumber;
            this.acctHolderName = _acctHolderName;
            this.acctBalance = 0.0;
            this.annualIntrRate = 0.0;
        }

        /* Deposit the given amount in the account and return the new balance */
        /*public double Deposit(double amount)
        {
            /* Arguments: The amount to be deposited 
             
            if (amount < 0)
            {
                throw new InvalidTransaction("Invlaid amount provided. Cannot deposit a negative amount.");
            }

            return this.acctBalance + amount;
        }*/

        /* Withdraw the given amount from the account, reduce the balance and return the new balance */
        /*public double Withdraw(double amount)
        {
            /* Arguments: The amount to be withdrawn
            if (amount < 0)
                throw new InvalidTransaction("Invalid amount provided. Cannot withdraw a negative amount.");

            if (amount > this.acctBalance)
                throw new InvalidTransaction("Insufficient funds. Cannot withdraw the provided amount.");

            return this.acctBalance - amount;
        }*/

        /* Load the account information from the given file */

        public List<Account> Load(string accountFile, List<Account> list)
        {
            using (FileStream acctFileStream = new FileStream(accountFile, FileMode.Open, FileAccess.Read))
            {
                StreamReader sr = new StreamReader(acctFileStream);
                try 
                { 
                    list.Add(new Account{ acctType = sr.ReadLine(), acctNumber = Convert.ToInt32(sr.ReadLine()), acctHolderName = sr.ReadLine(),
                                            acctBalance = Convert.ToDouble(sr.ReadLine()), annualIntrRate = Convert.ToDouble(sr.ReadLine())
                    });
                }
                finally
                {
                    sr.Close();
                }
            }
            return list;
        }

        /* Save the account information in the given file */
        public void Save(string accountFile, Account account)
        {

            using (FileStream acctFileStream = File.Create(accountFile))
            {
                StreamWriter sr = new StreamWriter(acctFileStream);
                try
                {
                    sr.WriteLine(account.accttype);
                    sr.WriteLine(account.acctNumber);
                    sr.WriteLine(account.acctHolderName);
                    sr.WriteLine(account.acctBalance);
                    sr.WriteLine(account.annualIntrRate);
                }
                finally { sr.Close(); }
            }
            return;
        }
    }
}
