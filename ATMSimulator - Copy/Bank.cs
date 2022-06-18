using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSimulator
{
    public class Bank : Account
    {
        /*Represents a bank composed of a list of accounts.
        Attributes: _accountList : list -- the list of accounts managed by the bank*/

        List<Account> accountList = new List<Account>();

        Account acct = new Account();
        public Bank()
        {
            //Initialize the field variables of the bank object, the account of the bank
            List<string> accountList = new List<string>();
        }
        public void LoadAccountData()
        {
            /*Load the account data for all the accounts. The account data files are stored in a directory
            named BankingData located in the current directory, the directory used to run the application from*/
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
                                Account acct = new Account();
                                //load the data into the account object
                                accountList.Add((string[])acct.Load(acctFile));
                            }
                            else if (acctType == "ChequingAccount")
                            {
                                ChequingAccount acct = new ChequingAccount();
                                //load the data into the account object
                                acct.Load(acctFile);
                                accountList.Add((string[])acct.Load(acctFile));
                            }
                            else if (acctType == "SavingsAccount")
                            {
                                SavingsAccount acct = new SavingsAccount();
                                //load the data into the account object
                                acct.Load(acctFile);
                                accountList.Add((string[])acct.Load(acctFile));
                            }
                        }
                        finally
                        {
                            /*#close the file regardless of whether an exception occurrs or not the finally block will execute
                            #ensuring the file is closed.*/
                            sr.Close();
                            acctFileStream.Close();
                        }
                    }
                }

                //if at this point the list of accounts is empty add the defaults accounts so the application is usable
                if (accountList.Count == 0) {
                    CreateDefaultAccounts(accountList);
                }
            }
        }

        public void SaveAccountData()
        {
            /*Saves the data for all accounts in the data directory of the application.Each account is
              saved in a separate file which contains all the account information.The account data files are stored in a
              directory named BankingData located in the current directory, the directory used to run the application from*/
/*            string[] paths = new string[] { Environment.CurrentDirectory, "BankingData" };
            string dataDirectory = Path.Combine(paths);

            //make the directory if it does not exist
            if (Directory.Exists(dataDirectory))
            {
                Directory.CreateDirectory(dataDirectory);
            }

           //go through each account in the list of accounts and ask it to save itself into a corresponding file
            for acct in self._accountList:
            acctType = type(acct).__name__
            prefix = 'acct' if acctType == 'Account' else 'chqacct' if acctType == 'ChecquingAccount' else 'savacct'
            acctFileName = '{0}{1}.dat'.format(prefix, acct.getAccountNumber())
            
            #by using context manager for the file that will automatically close the file at the end of the with eblock
            with open(os.path.join(dataDirectory, acctFileName), 'w') as acctFile:
                acctFile.write(acctType + '\n')
                acct.save(acctFile)
*/
        }

        public void CreateDefaultAccounts(List<string[]> accountList)
        {
            //Create 10 accounts with predefined IDs and balances. The default accounts are created only if no account data files exist

            string[] newDefAcct = new string[4];
            for (int iAccount = 0; iAccount < 10; iAccount++)
            {
                //create the account with required properties
                newDefAcct[iAccount] = Convert.ToString(AccountTypeValues.DEFAULT_ACCT_NO_START + iAccount)
                    "DefaultAccount" + Convert.ToString(iAccount);

                base.Deposit(100);
            newDefAcct.setAnnualIntrRate(2.5)

            #add the account to the list
            self._accountList.append(newDefAcct)
 */
        }


        public int FindAccount(int acctNo)
        {
/*            """
        Returns the account with the given account number or null if no account with that ID can be found
        Parameters:
            acctNo - the account number of the account to return
        Return:
            the account object with the given ID
        """
        #go through all the accounts until one is found with the given account number
        for acct in self._accountList:
            if acct.getAccountNumber() == acctNo:
                return acct

        #if the program got here it means there was no account with the given account number
        return None
*/
        }


        public void determineAccountNumber()
        {
            /*
                    """Determine the account number prompting the user until they enter the correct information

                       The method will raise an AssertError if the user chooses to terminate.
                    """
            # pylint: disable=no-self-use
                    while True:
                        try:
            # ask the user for input
                            acctNoInput = input('Please enter the account number [100 - 1000] or press [ENTER] to cancel: ')

                            if len(acctNoInput) == 0:
                                raise OperationCancel('User has selected to terminate the program after invalid input')

            # check the input to ensure correctness and deal with incorrect input
                            acctNo = int(acctNoInput)
                            if acctNo < 100 or acctNo > 1000: 
                                raise InvalidValue('The account number you have entered is not valid. Please enter a valid account number')

            # check that the account number is not in use
                            for account in self._accountList:
                                if acctNo == account.getAccountNumber():
                                    raise InvalidValue('The account number you have entered already exists. Please enter a different account number')

            # the account number has been generated successfully
                            return acctNo

                        except (ValueError, InvalidValue) as err:
                            print(err, '\n') 


             */
        }
        public void openAccount(string _clientName, int _acctType)
        {
            /*Create and store an account objec with the required attributes*/
            //# prompt the user for an account number
            int acctnumber = this.determineAccountNumber()

            //create and store an account object with the required attributes
            if (_acctType == Account.AccountTypeValues.ACCOUNT_TYPE_CHEQUING)
            {
                newAccount = ChecquingAccount(acctNo, clientName)
                    elif acctType == Account.ACCOUNT_TYPE_SAVINGS:
                        newAccount = SavingsAccount(acctNo, clientName)

            # add the new account to the list of the accounts
                    self._accountList.append(newAccount)

            # return the account to the caller so other properties can be set
                    return newAccount
             * 
             */
        }

    }
}
