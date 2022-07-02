using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ATMSimulator
{
    //Exception Class for user cancel event (when the user cancels the operation by pressing ENTER)
    public class OperationCancel : Exception
    {
        //Code for OperationCancel exception
    }

    //Class for Bank composed of a list of accounts. If accounts are not available, default accounts are created
    public class Bank : Account
    {
        //Define Constant Values
        private enum Constant
        {
            DEFAULT_ACCT_NO_START = 100
        }

        //Account List to load and store the accounts and its attributes
        public static List<Account> accountlist = new List<Account>();

        /* Method to load the account data for all the accounts. */
        public void LoadAccountData()
        {
            /* The account data files are stored in a directory named BankingData located in the current directory,
             * the directory used to run the application from */
            string[] paths = new string[] { Environment.CurrentDirectory, "BankingData" };
            string dataDirectory = Path.Combine(paths);

            if (Directory.Exists(dataDirectory))
            {
                //get the list of files in the directory
                string[] acctFileList = Directory.GetFiles(dataDirectory);

                //go through the list of files, create the appropriate accounts and load the file
                foreach (string acctFileName in acctFileList)
                {
                    string acctFile = Path.Combine(dataDirectory, acctFileName);

                    using (FileStream acctFileStream = new FileStream(acctFile, FileMode.Open, FileAccess.Read))
                    {
                        StreamReader sr = new StreamReader(acctFileStream);
                        try
                        {
                            //read the account type and create the correct account
                            string acctType = sr.ReadToEnd();
                            if (acctType == "Account")
                            {
                                Load(acctFile, accountlist);
                            }
                            else if (acctType == "Chequing")
                            {
                                Load(acctFile, accountlist);
                            }
                            else if (acctType == "Savings")
                            {
                                Load(acctFile, accountlist);
                            }
                            Console.WriteLine(accountlist);
                        }
                        finally
                        {
                            sr.Close();
                        }
                    }
                }
            }
            if (accountlist.Count == 0)
                CreateDefaultAccounts();

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
            for (int i = 0; i < 10; i++)
            {
                accountlist.Add(new Account
                {
                    acctType = "Account",
                    acctNumber = Convert.ToInt32(Constant.DEFAULT_ACCT_NO_START) + i,
                    acctHolderName = "DefaultAccount" + i,
                    acctBalance = 100,
                    annualIntrRate = 2.5
                });
            }
        }

        //Returns the account with the given account number or null if no account with that ID can be found
        public Account FindAccount(int acctNo)
        {
            /* Find Account Parameters: acctNo - The account number to be search
             *              Return: All account data (name, account balance, annual interest rate) for the given account number*/
            //foreach (List<Account> accounts in accountlist)
            for(int i=0; i<accountlist.Count; i++)
            {
                if (accountlist[i].acctNumber.Equals(acctNo))
                    return accountlist[i];
            }
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