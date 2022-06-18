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

        /* Method to load the account data for all the accounts. The account data files are stored in a directory
         * named BankingData located in the current directory, the directory used to run the application from */
        public void LoadAccountData()
        {

        }

        /* Method to save the data for all accounts in the data directory of the application. Each account is
         * saved in a separate file which contains all the account information.The account data files are stored in a
         * directory named BankingData located in the current directory, the directory used to run the application from */
        public void SaveAccountData()
        {

        }

        /* Create 110 default accounts with predefined IDs and balances. The default accounts are created only if no account information
         * is availabble */
        public void CreateDefaultAccounts()
        {

        }

        //Returns the account with the given account number or null if no account with that ID can be found
        public int FindAccount(int acctNo)
        {
            return 0;
        }

        //Validate the correct Account number and prompt user until the correct information is entered
        public void DetermineAccountNumber()
        {

        }

        //Create and store an account object with the required attributes
        public void OpenAccount(String _clientName, int _acctType)
        {

        }
    }
}