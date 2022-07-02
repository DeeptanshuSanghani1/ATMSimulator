using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSimulator
{
    /*The Atm class represents an ATM machine. The class displays the main menu and the account menu 
     * and performs the account management functions on a bank account: checking balance, withdrawal and depositing amount*/
    class ATM : Bank
    {
        private enum Options
        {
            //MAIN MENU options
            SELECT_ACCOUNT_OPTION = 1,
            CREATE_ACCOUNT_OPTION = 2,
            EXIT_ATM_APPLICATION_OPTION = 3,

            //ACCOUNT MENU options
            CHECK_BALANCE_OPTION = 1,
            WITHDRAW_OPTION = 2,
            DEPOSIT_OPTION = 3,
            EXIT_ACCOUNT_OPTION = 4
        }

        //Start the ATM program by displaying the user options
        public void StartATM()
        {
            while (true)
            {
                int selectedOption = ShowMainMenu();
                switch (selectedOption)
                {
                    case (int)Options.SELECT_ACCOUNT_OPTION:
                        Account acct = SelectAccount();
                        if (!String.IsNullOrEmpty(Convert.ToString(acct)))
                        {
                            ManageAccount(acct);
                        }
                        break;
                    case (int)Options.CREATE_ACCOUNT_OPTION:
                        OnCreateAccount();
                        break;
                    case ((int)Options.EXIT_ATM_APPLICATION_OPTION):
                        SaveAccountData();
                        return;
                }
            }
        }

        /* Display the Main Menu and ensure the user picks an option. */
        public int ShowMainMenu()
        {
            while (true)
            {
                Console.WriteLine("Main Menu");
                Console.WriteLine();
                Console.WriteLine("1: Select Account");
                Console.WriteLine("2: Create Account");
                Console.WriteLine("3: Exit");
                Console.WriteLine();
                Console.WriteLine("Enter a choice: ");
                int val = Convert.ToInt32(Console.ReadLine());
                if (val == Convert.ToInt32(Options.SELECT_ACCOUNT_OPTION) || val == Convert.ToInt32(Options.CREATE_ACCOUNT_OPTION) || val == Convert.ToInt32(Options.EXIT_ATM_APPLICATION_OPTION))
                {
                    return val;
                }
                else
                   throw new InvalidValue("Please enter a valid menu option.");
            }          
        }

        /* Display the Account Menu and ensure the user picks an option.*/
        public int ShowAccountMenu()
        {
            while (true)
            {
                Console.WriteLine("Account Menu");
                Console.WriteLine();
                Console.WriteLine("1: Check Balance");
                Console.WriteLine("2: Withdraw");
                Console.WriteLine("3: Deposit");
                Console.WriteLine("4: Exit");
                Console.WriteLine();
                Console.WriteLine("Enter a choice: ");

                int acctMenuVal = Convert.ToInt32(Console.ReadLine());
                if (acctMenuVal == Convert.ToInt32(Options.CHECK_BALANCE_OPTION) || acctMenuVal == Convert.ToInt32(Options.WITHDRAW_OPTION) ||
                    acctMenuVal == Convert.ToInt32(Options.DEPOSIT_OPTION) || acctMenuVal == Convert.ToInt32(Options.EXIT_ACCOUNT_OPTION))
                    return acctMenuVal;
                else
                    throw new InvalidValue("Please enter a valid menu option for account menu");
            }
        }
        
        /* Select an account by prompting the user for an account number. */
        public Account SelectAccount()
        {
            while (true)
            {
                int acctNo = 0;

                Console.WriteLine("Please enter your account ID or press [ENTER] to cancel: ");
                String acctNoInput = Console.ReadLine();

                if (acctNoInput.Length == 0)
                {
                    return null;
                }
                else
                {
                    bool success = int.TryParse(acctNoInput, out acctNo);
                    if (!success)
                        throw new InvalidValue("Please enter a valid account number (e.g.100)");
                }

                Account acct = FindAccount(acctNo);
                if (acct == null)
                {
                    Console.WriteLine("The account was not found. Please select another account.");
                }
                else
                {
                    return acct;
                }
            }
        }

        /*Manage the account by allowing user to perform operations on the given account*/
        public void ManageAccount(Account account)
        {
            while (true)
            {
                int selAcctMenuOpt = ShowAccountMenu();

                switch (selAcctMenuOpt)
                {
                    case (int)Options.CHECK_BALANCE_OPTION:
                        OnCheckBalance(account);
                        break;
                    case (int)(Options.WITHDRAW_OPTION):
                        OnWithdrawal(account);
                        break;
                    case (int)(Options.DEPOSIT_OPTION):
                        OnDeposit(account);
                        break;
                    case (int)(Options.EXIT_ACCOUNT_OPTION):
                        return;
                    default:
                        Console.WriteLine("Please enter a valid menu option");
                        break;
                }
            }
        }

         /* Create and Open an account. */
        public void OnCreateAccount()
        {
            //The user is asked for all information to open the account.
            //Create the account object and add it to the bank

            //Get the name of the account holder
            string clientName = PromptForClientName();

            //Get the initial deposit amount from user
            double initialDepositAmount = PromptForDepositAmount();

            //Get the Annual Interest Rate from the user
            double initialIntRate = PromptForAnnualIntrRate();

            //Get user input for account type
            string acctType = PromptForAccountType();

            OpenAccount(clientName, acctType, initialDepositAmount, initialIntRate);
            return;
        }

        /* Prompt the user to enter Client Name for creating a new account. Allows the user to cancel operation by pressing Enter*/
        public string PromptForClientName()
        {
            Console.WriteLine("Please enter the client name or press [ENTER] to cancel: ");
            string _clientName = Console.ReadLine();

            //Check if the client pressed Enter without entering a value
            if (string.IsNullOrEmpty(_clientName))
                throw new OperationCancel("The user has cancelled the Operation");

            return _clientName;
        }

        /* Prompt the user to enter Deposit Amount for creating a new account. Performs basic error checking*/
        public double PromptForDepositAmount()
        {
            while (true)
            {
                string _initamt;

                Console.WriteLine("Please enter your initial account balance: ");
                
                //Read and store the user input
                _initamt = Console.ReadLine();
                
                //Check if the client pressed Enter without entering a value
                if (string.IsNullOrEmpty(_initamt))
                    throw new OperationCancel("The user has cancelled the Operation");

                double initamt;

                //Check if non-numeric value is entered
                bool success = double.TryParse(_initamt, out initamt);
                if (!success)
                    throw new InvalidValue("Invalid entry. Please enter a number for your amount.");

                //Check if numeric value entered is less than 0
                if (initamt < 0)
                    Console.WriteLine("Cannot create an account with a negative initial balance. Please enter a valid amount");
                else
                    return initamt;
            }
        }

        /* Prompts the user to enter Annual Interest Rate for creating the account. */
        public double PromptForAnnualIntrRate()
        {
            while (true)
            {
                //Get user input for interest rate
                Console.WriteLine("Please enter the interest rate for this account: ");
                string _intrate = Console.ReadLine();

                //Check if the client pressed Enter without entering a value
                if (string.IsNullOrEmpty(_intrate))
                    throw new OperationCancel("The user has cancelled the Operation");

                double intrate;

                //Check if non-numeric value is entered
                bool success = double.TryParse(_intrate, out intrate);
                if (!success)
                    throw new InvalidValue("Invalid entry. Please enter a number for your amount.");

                //Check if numeric value entered is less than 0
                if (intrate < 0)
                    Console.WriteLine("Cannot create an account with a negative interest rate.");
                else
                    return intrate;
            }
        }

        /* Prompts the user to enter Account Type for creating the account. */
        public string PromptForAccountType()
        {
            while (true)
            {
                Console.WriteLine("Please enter the account type [c/s: chequing / savings]: ");
                string acctTypeVal = Console.ReadLine().ToUpper();

                //Check Account Type Input and return Chequing or Savings
                if (acctTypeVal == "C" || acctTypeVal == "CHEQUING" || acctTypeVal == "CHECKING")
                    return "ChequingAccount";
                else if (acctTypeVal == "S" || acctTypeVal == "SAVINGS" || acctTypeVal == "SAVING")
                    return "SavingsAccount";
                else
                    Console.WriteLine("Answer not supported. Please enter one of the supported answers.");
            }
        }

        /* Print the Balance on the given account to the console */
        public void OnCheckBalance(Account account)
        { 
            /* Arguments: Account List for which balance needs to be printed*/
            Console.WriteLine("The balance in account " + account.acctNumber + " is " + account.acctBalance);
        }

        /* Prompts the user to enter amount for deposit. Validates data for invalid value and incorrect amount */
        public void OnDeposit(Account account)
        {
            string inputAmount = null;
            double amountToDeposit = 0.0;

            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter an amount to deposit or type [ENTER] to exit: ");
                    inputAmount = Console.ReadLine();

                    bool success = double.TryParse(inputAmount, out amountToDeposit);

                    //Raise error if deposit amount is negative
                    if (amountToDeposit < 0)
                        throw new InvalidTransaction("Invlaid amount provided. Cannot deposit a negative amount.");

                    //Check if Numeric value is entered, Otherwise throw error
                    if (!success)
                        throw new InvalidValue("Invalid entry. Please enter a number for your amount.");

                    //If Amount is greater than 0, deposit the amount
                    account.acctBalance += amountToDeposit;

                    return;
                }
                catch (InvalidTransaction e) { }
                
            }
        }

        /* Prompts the user to enter amount for withdrawal. Validates data for invalid value and incorrect amount */
        public void OnWithdrawal(Account account)
        {
            string inputAmount = null;
            double amountToWithdraw = 0.0;
            while (true)
            {
                Console.WriteLine("Please enter an amount to withdraw or type [ENTER] to exit: ");
                inputAmount = Console.ReadLine();

                bool success = double.TryParse(inputAmount, out amountToWithdraw);
                if (!success)
                    throw new InvalidValue("Invalid entry. Please enter a number for your amount.");

                //Display an error if amount to be withdrawan is less than 0
                if (amountToWithdraw < 0)
                    throw new InvalidTransaction("Invalid amount provided. Cannot withdraw a negative amount.");

                //Amount for withdrawal cannot be more than the account balance
                if (amountToWithdraw > account.acctBalance)
                    throw new InvalidTransaction("Insufficient funds. Cannot withdraw the provided amount.");

                //Withdraw amount if no errors found
                if (amountToWithdraw >= 0)
                    account.acctBalance -= amountToWithdraw;

                //the withdrawal was done or user entered nothing so break from the infinite loop
                return;
            }
        }
    }
}