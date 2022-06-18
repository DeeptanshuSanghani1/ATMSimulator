using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSimulator
{
    //Exception class used when an invalid trasaction is performed
    public class InvalidTransaction : Exception
    {
        //Code for InvalidTransaction exception
    }

    //Exception class used when an invalid value is entered
    public class InvalidValue : Exception
    {
        //Code for InvalidValue exception
    }

    /* The Account class is used by the Bank moodule. It defines the bank account and its corresponding attributes
     * epresents an ATM machine. The class displays the main menu and the account menu */
    public class Account
    {
        //Code for Account class
        private enum Constants
        {
            ACCOUNT_TYPE_CHEQUING = 1,
            ACCOUNT_TYPE_SAVINGS = 2
        }

        /*Define a bank account and its associated attributes

        Attributes:
        acctNumber      : int      -- the account number, read-only attribute
        acctHolderName  : string   -- the name of the account holder, read-only attribute
        acctBalance     : double   -- the account balance that gets affected by withdrawls and deposits
        annualIntrRate  : double   -- the annual interest rate applicable on the balance
        */

        public int acctNumber 
        { 
            get { return this.acctNumber; }
            set { this.acctNumber = value; }
        }
        public string acctHolderName 
        {
            get { return this.acctHolderName; }
            set { this.acctHolderName = value; }
        }
        public double acctBalance 
        {
            get { return this.acctBalance; }
            set { this.acctBalance = value; }
        }
        public double annualIntrRate 
        {
            get { return this.annualIntrRate; }
            set { this.annualIntrRate = value / 100; }
        }

        /* Constructor Class - initialize the account attributes
         * The account constructor requires the caller to supply an account number and the name of the account holder 
         * in order to create an account. 
         * The constructor assigns default values to each parameter allowing the code not to supply them (i.e. acct = Account()). 
         * If the calling code does not supply values for the two parameters they will receive these default values. This is used 
         * when the accounts are created from data files
         */

        public Account (int _acctNumber = -1, string _acctHolderName = " ")
        {
            this.acctNumber = _acctNumber;
            this.acctHolderName = _acctHolderName;
            this.acctBalance = 0.0;
            this.annualIntrRate = 0.0;
        }

        /* Deposit the given amount in the account and return the new balance */
        public double Deposit(double amount)
        {
            return 0.0;
        }

        /* Withdraw the given amount from the account, reduce the balance and return the new balance */
        public double Withdraw(double amount)
        {
            return 0.0;
        }

        /* Load the account information from the given file */
        public void Load(string accountFile)
        {

        }

        /* Save the account information in the given file */
        public void Save(string accountFile)
        {

        }
    }
}
