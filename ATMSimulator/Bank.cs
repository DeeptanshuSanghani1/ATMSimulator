using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSimulator
{
    //Exception Class for user cancel event (when the user cancels the operation by pressing ENTER)
    public class OperationCancel : Exception
    {
        //Code for OperationCancel exception
    }

    //Class for Bank composed of a list of accounts. If accounts are not available, default accounts are created
    public class Bank
    {
        //Define Constant Values
        private enum Constant
        {
            DEFAULT_ACCT_NO_START = 100
        }

        //Account List to load and store the accounts and its attributes
        public List<Account> accountlist;

        //Constructor class or Bank - initialize accountlist
        public Bank()
        {
            accountlist = new List<Account>();
        }

        /* Method to load the account data for all the accounts. */
        public void LoadAccountData()
        {
            /* The account data files are stored in a directory named BankingData located in the current directory,
             * the directory used to run the application from 
             * 
             * Create a string variable dataDirectory
             * Get current working directory + "BankingData" in dataDirectory variable
             * 
             * If dataDirectory exists
             *      fetch the list of all files from the directory
             *      for each file 
             *          open the file
             *          read the file line by line
             *          Load the data into an account object 
             *          Add the file contents to accountList
             * finally 
             *      Close all files
             *      
             * If accountList is empty
             *      CreateDefaultAccounts()
             */
        }

        /* Method to save the data for all accounts in the data directory of the application. Each account is
         * saved in a separate file which contains all the account information.The account data files are stored in a
         * directory named BankingData located in the current directory, the directory used to run the application from */
            public void SaveAccountData()
        {
            /* The account data files are stored in a directory named BankingData located in the current directory,
             * the directory used to run the application from 
             * 
             * Create a string variable dataDirectory
             * Get current working directory + "BankingData" in dataDirectory variable
             * 
             * If ! dataDirectory exists
             *      create dataDirectory
             *      
             * For each account in accountList
             *      get acctype from accountList
             *      create a string variable prefix
             *      
             *      if acctype = Account then prefix = acct
             *      else if acctype = Chequing then prefix = chqacct
             *      else if acctype = Savings then prefix = savacct
             *      acctFileName = prefix + getAccountNumber() + ".dat"
             *      
             *      Open acctFileName
             *      using StreamReader Write acctype to acctFileName
             *      Close acctFileName
             */

        }

        /* Create 10 default accounts with predefined IDs and balances. The default accounts are created only if no account information
         * is availabble */
        public void CreateDefaultAccounts()
        {
            /* Initialize an array newDefAccount
             * 
             * For Account in 1 to 10
             *      For j in 1 to 3 //Elements in each array
             *          newDefAccount[Account][j] = DefaultAccountNotoStart + Account //Account Number
             * 
             *          newDefAccount[Account][j] = Deposit(100) //Deposit method from Account class to calculate account Balance
             *          newDefAccount[Account][j] = setAnnualIntrRate(2.5)
             *      End Loop
             *      
             *      Add the newDefAccount to the accountList
             * End Loop
             */
        }

        //Returns the account with the given account number or null if no account with that ID can be found
        public Array FindAccount(int acctNo)
        {
            /* Find Account Parameters: acctNo - The account number to be search
             *              Return: All account data (name, account balance, annual interest rate) for the given account number
             * For Accounts in accountList
             *      if acctNo == Accounts.getAccountNumber();
             *          return Accounts
             *          
             * otherwise return a null array
             */
            return null;
        }

        //Validate the correct Account number and prompt user until the correct information is entered
        public int DetermineAccountNumber()
        {
            /* This method will prompt the user to enter the account number and determine if the user input is correct
             * 
             * The method will cancel if no value is entered and user clicks on ENTER
             * 
             * while the user does not enter a correct value
             *      Print Please enter the account number [100 - 1000] or press [ENTER] to cancel: 
             *      Read and store the user input to acctNoInput variable (of type int)
             * 
             *      If length of account number is 0 and user clicked on ENTER, throw an OperationCancel error 
             * 
             *      If the account number is not between 100 and 1000 throw an InvalidValue error
             * 
             *      for loop on the accountList
             *          if acctNoInput = accountList.getAccountNumber()
             *              Throw an InvlaidVlaue error with appropriate message 
             *      return acctNpInput
             * 
             * Catch all exceptions thrown
             * 
             */
            return 0;
        }

        //Create and store an account object with the required attributes
        public int OpenAccount(String _clientName, int _acctType)
        {
            /* int acctNo = DetermineAccountNumber()
 
             * If _acctType = Chequing
             *      newAccount = Create Chequing Account object with acctNo and _clientName
             * else if _acctType = Savings 
             *      newAccount = Create Savings Account object with acctNo and _clientName
             * else
             *      newAccount = Create Account object with acctNo and _clientName
             
             * accountList = Add(newAccount)
             * 
             * return newAccount
             */
            return -1;
        }
    }
}