using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace ATMSimulator
{
    //Exception Class for user cancel event (when the user cancels the operation by pressing ENTER)
    [Serializable]
    public class OperationCancel : Exception
    {
        public OperationCancel() { }

        public OperationCancel(string errormessage) : base(errormessage)
        {
            Console.WriteLine(errormessage);
        }
    }

    //Class for Bank composed of a list of accounts. If accounts are not available, default accounts are created
    public class Bank : Account, iTransaction
    {
        //Define Constant Values
        private enum Constant
        {
            DEFAULT_ACCT_NO_START = 100
        }

        //Account List to load and store the accounts and its attributes
        public static List<Account> accountlist = new List<Account>();

        //A list is used to record and store transactions instead of a database table
        public static List<Transaction> _listOfTransactions = new List<Transaction>();


        /* Method to load the account data for all the accounts. */
        public void LoadAccountData()
        {
            /* The account data files are stored in a directory named BankingData located in the current directory,
             * the directory used to run the application from */
            string[] paths = new string[] { Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "ATM", "BankingData" };
            string dataDirectory = Path.Combine(paths);

            //Check if Directory exists
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
                        }
                        finally
                        {
                            sr.Close();
                        }
                    }
                }
            }
            //Create default accounts if no account files are found
            if (accountlist.Count == 0)
                CreateDefaultAccounts();
        }


        /* Method to save the data for all accounts in the data directory of the application. Each account is
         * saved in a separate file which contains all the account information.The account data files are stored in a
         * directory named BankingData located in the current directory, the directory used to run the application from */
        public void SaveAccountData()
        {
            /* The account data files are stored in a directory named BankingData located in the current directory,
             * the directory used to run the application from */

            string[] paths = new string[] { Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "ATM", "BankingData" };
            string dataDirectory = Path.Combine(paths);

            //If the Directory does not exist create the directory
            if(!Directory.Exists(dataDirectory))
                Directory.CreateDirectory(dataDirectory);

            //Execute a for loop for all accounts in the list 
            for(int i=0; i<accountlist.Count; i++)
            {
                //Get account type for file name
                string prefix = null;
                if (accountlist[i].acctType == "ChequingAccount")
                    prefix = "chqacct";
                else if (accountlist[i].acctType == "SavingsAccount")
                    prefix = "savacct";
                else
                    prefix = "acct";

                string acctFileName = Path.Combine(dataDirectory, prefix + accountlist[i].acctNumber + ".dat");

                Save(acctFileName, accountlist[i]);
            }
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
            while (true)
            {
                Console.WriteLine("Please enter the account number [100 - 1000] or press [ENTER] to cancel: ");
                string _acctno = Console.ReadLine();

                //Check if the client pressed Enter without entering a value
                if (string.IsNullOrEmpty(_acctno))
                    throw new OperationCancel("The user has cancelled the Operation");

                int acctno;

                //Check if non-numeric value is entered
                bool success = int.TryParse(_acctno, out acctno);
                if (!success)
                    throw new InvalidValue("Invalid entry. Please enter a number for your account number.");

                //Check if user input is within the range
                if(! Enumerable.Range(100,1000).Contains(acctno))
                    throw new InvalidValue("Invalid entry. Please enter a number for your account number.");

                for (int i=0; i<accountlist.Count; i++)
                {
                    if (acctno == accountlist[i].acctNumber)
                    {
                        Console.WriteLine("The account number you have entered already exists. Please enter a different account number");
                        break;
                    }
                }
                return acctno;
            }
        }

        //Create and store an account object with the required attributes
        public void OpenAccount(String _clientName, string _acctType, double _initialDepAmt, double _initialIntRate)
        {
            int acctNo = DetermineAccountNumber();

            accountlist.Add(new Account
            {
                acctType = _acctType,
                acctNumber = acctNo,
                acctHolderName = _clientName,
                acctBalance = _initialDepAmt,
                annualIntrRate = _initialIntRate
                });
            //Add transaction record - Start
            Transaction tr = new Transaction()
            {
                TransactionAcctNo = acctNumber,
                TransactionDate = DateTime.Now,
                transactiontype = TransactionType.NewAccountCreated,
                Description = "New account created"
            };
            InsertTransaction(tr);
            //Add transaction record - End
            Console.WriteLine(tr.Description);

        }

        public void InsertTransaction(Transaction transaction)
        {
            _listOfTransactions.Add(transaction);
        }

        public void ViewTransaction()
        {

            if (_listOfTransactions.Count <= 0)
                Console.WriteLine("There are no transaction yet.");
            else
            {
                int tablewidth = 70;
                Console.WriteLine(new string('-', tablewidth));
                //DataTable table = new DataTable();
                Console.WriteLine(String.Format("{0,10 },{1,10 }, {2, 10}, {3, 10}", "Account No", "Date", "Type", "Descriptions"));

                foreach (var tran in _listOfTransactions)
                {
                    Console.WriteLine(String.Format("{0,10 },{1,10 }, {2, 10}, {3, 10}", tran.TransactionAcctNo.ToString(),tran.TransactionDate.ToString("MM/dd/yyyy HH:mm"),
                                                    tran.transactiontype,tran.Description));
                }
                Console.WriteLine("You have performed " + _listOfTransactions.Count + " transactions.");
            }
        }

    }
}