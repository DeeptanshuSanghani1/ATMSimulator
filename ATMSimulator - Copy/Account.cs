using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ATMSimulator
{
    public class Account
    {
        /*Define the bank account and other attributes for
        
         Attributes:
        _acctnumber     : int   -- the account number, read-only attribute
        _acctname       : str   -- the name of the account holder, read-only attribute
        _acctbalance    : double -- the account balance that changes with deposits and withdrawls
        _annualintrate  : double -- the annual interest rate applicable on the balance
         */

        private string _acctname;
        private int _acctnumber;
        private double _acctbalance;
        private double _annualintrate;

        public Account(int accountnumber, string name)
        {
            _acctnumber = accountnumber;
            _acctname = name;
        }

        public enum AccountTypeValues
        {
            DEFAULT_ACCT_NO_START = 100,
            ACCOUNT_TYPE_CHEQUING = 1,
            ACCOUNT_TYPE_SAVINGS = 2
        }

        //Define Getters and Setter for Account Attributes
        public string GetAccountName()
        {
            return _acctname;
        }
        public int GetAccountNumber()
        {
            return _acctnumber;
        }
        public double GetAccountBalance()
        {
            return _acctbalance;
        }
        public double GetRate()
        {
            return _annualintrate;
        }
        public void SetAccountName(string p_name)
        {
            _acctname = p_name;
        }
        public void SetAccountNumber(int p_acctno)
        {
            _acctnumber = p_acctno;
        }
        public void SetAccountBalance(double p_acctbal)
        {
            _acctbalance = p_acctbal;
        }
        public void SetAnnualIntRate(double p_intratepercentage)
        {
            _annualintrate = p_intratepercentage / 100;
        }

        public double Deposit(double deposit_amount)
        {
            /*Deposit the given amount in the account and return the new balance
            Parameters: deposit_amount - the amount to be deposited
            Returns: the new account balance AFTER the amount was deposited to avoid a call to getAccountBalance()
            */
            try
            {
                //check that the amount to be deposited is more than 0
                if (deposit_amount < 0)
                {
                    throw new Exception("Invalid amount provided. Cannot deposit a negative amount.");
                }
                //#change the balance
                _acctbalance += deposit_amount;                
            }
            catch(Exception message)
            {
                Console.WriteLine(message);
            }
            //provide the new balance to the caller to avoid a getBalance() call
            return _acctbalance;
        }

        public double Withdraw(double withdrawal) {
            /* Withdraw the given amount from the account and return the new account balance
            Arguments: withdrawal - the amount to be withdrawn, cannot be negative or greater than available balance
            Returns: the new account balance AFTER the amount was withdrawn*/

            try
            {
                if (withdrawal < 0)
                {
                    throw new Exception("Invalid amount for withdrawal. Cannot withdraw a negative amount.");
                }

                if (withdrawal > GetAccountBalance())
                {
                    throw new Exception("Insufficient funds. Cannot withdraw the provided amount.");
                }

                //change the balance
                _acctbalance -= withdrawal;
            }
            catch(Exception message)
            {
                Console.WriteLine(message);
            }
            //provide the new balance to the caller to avoid a getBalance() call
            return _acctbalance;
        }

        public Array Load(string accountfile)
        {
            /*Load the account information from the given file.The file is assumed opened
            Arguments: file - the file containing the account information

            #read the account properties in the same order they were saved*/

            string[] acctData = new string[] { };
            StreamReader inputFile = new StreamReader(accountfile);

            inputFile.ReadLine();
            _acctnumber = int.Parse(inputFile.ReadLine());
            _acctname = inputFile.ReadLine();
            _acctbalance = double.Parse(inputFile.ReadLine());
            _annualintrate = double.Parse(inputFile.ReadLine());

            acctData = acctData.Append(Convert.ToString(_acctnumber)).ToArray();
            acctData = acctData.Append(_acctname).ToArray();
            acctData = acctData.Append(Convert.ToString(_acctbalance)).ToArray();
            acctData = acctData.Append(Convert.ToString(_annualintrate)).ToArray();

            return acctData;
        }

        public void Save(string accountfile)
        {
            /*This method saves the account information in the given file.The file is assumed opened
            The name of the file alongwith the complete path is passed as the parameter*/

            //write the account properties, one per line
            using (StreamWriter writer = new StreamWriter(accountfile))
            {
                writer.WriteLine(Convert.ToString(_acctnumber));
                writer.WriteLine(_acctname);
                writer.WriteLine(Convert.ToString(_acctbalance));
                writer.WriteLine(Convert.ToString(_annualintrate));
            }
        }
    }
}
