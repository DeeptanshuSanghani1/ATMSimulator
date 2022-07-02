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
                        break;
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
            /*
             * The user is asked for all information to open the account. Create the account object and add it to the bank
             * 
             * While the user does not enter all information
             * 
             * create a string variable clientName
             * execute PromptForClientName method and store value in clientName 
             * 
             * create a int variable initDepositAmount
             * execute PromptForDepositAmount method and store value in initDepositAmount
             * 
             * create a double variable annIntrRate
             * execute PromptForAnnualIntrRate method and store value in annIntrRate
             * 
             * create int variable acctType
             * execute PromptForAccountType method and store value in acctType
             * 
             * create array newAccount
             * execute OpenAccount method from Bank class and store value in newAccount
             * 
             * execute Deposit method from Account class and by passing initDepositAmount as parameter
             * Set Annual Interest Rate in newAccount by calling setAnnualIntrRate method
             * 
             * throw InvalidValue exception if invalid value is entered
             * throw OperationCancel exception if user clicks on ENTER without entering a value
             * 
             * return once all values are available
             */
        }
        /* Prompt the user to enter Client Name for creating a new account. Allows the user to cancel operation by pressing Enter*/
        public string PromptForClientName()
        {
            /* Create a string variable clientName
             * 
             * Output to Console "Please enter the client name or press [ENTER] to cancel: "
             * Read user input and store value in clientName variable
             * 
             * If clientName is null
             *      throw OperationCancel error
             * 
             * return clientName
             */
            return null;
        }

        /* Prompt the user to enter Deposit Amount for creating a new account. Performs basic error checking*/
        public double PromptForDepositAmount()
        {
            /* While the user enters a valid value
             * 
             * create a private int variable initAmount
             * Output to console "Please enter your initial account balance: "
             * Read user input and store value in initAmount
             * 
             * If initAmount is greater than or equal to 0
             *      return initAmount value
             * else
             *      Output to Console "Cannot create an account with a negative initial balance. Please enter a valid amount"
             * 
             * throw ValueError if a non-numeric value is entered by the user
             * 
             */
            return 0.0;
        }

        /* Prompts the user to enter Annual Interest Rate for creating the account. */
        public double PromptForAnnualIntrRate()
        {
            /* While the user enters a valid value
             * 
             * create a private int variable intrRate
             * Output to console "Please enter the interest rate for this account: "
             * Read user input and store value in intrRate
             * 
             * If intrRate is greater than or equal to 0
             *      return initAmount value
             * else
             *      Output to Console "Cannot create an account with a negative interest rate."
             * 
             * throw ValueError if a non-numeric value is entered by the user
             * 
             */
            return 0.0;
        }

        /* Prompts the user to enter Account Type for creating the account. */
        public int PromptForAccountType()
        {
            /* While the user enters a valid value
             * 
             * create a private int variable acctTypeInput 
             * Output to console "Please enter the account type [c/s: chequing / savings]: "
             * Read user input and store value in acctTypeInput 
             * 
             * if acctTypeInput is in 'C' or 'CHEQUING' or 'CHECKING' 
             *      return account type chequing constant (From enum in Account class)
             * else if acctTypeInput is in 'S' or 'SAVINGS' or 'SAVING'
             *      return account type savings constant (From enum in Account class)
             * else
             *      Output to Console "Answer not supported. Please enter one of the supported answers."
             */
            return 0;
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

                    if (amountToDeposit < 0)
                    {
                        throw new InvalidTransaction("Invlaid amount provided. Cannot deposit a negative amount.");
                    }

                    //Check if Numeric value is entered, Otherwise throw error
                    if (!success)
                        throw new InvalidValue("Invalid entry. Please enter a number for your amount.");

                    //If Amount is greater than 0, deposit the amount
                    account.acctBalance += amountToDeposit;

                    return;
                }
                catch (InvalidTransaction ex) { }
                
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