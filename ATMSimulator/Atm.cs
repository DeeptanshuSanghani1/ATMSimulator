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
                        int acctNo = SelectAccount();
                        if (acctNo != 0 || !String.IsNullOrEmpty(Convert.ToString(acctNo)))
                        {
                            ManageAccount(acctNo);
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
                Console.WriteLine("\nMain Menu\n\n1: Select Account\n2: Create Account\n3: Exit\n\nEnter a choice: ");
                int val = Convert.ToInt32(Console.ReadLine());
                if(val == Convert.ToInt32(Options.SELECT_ACCOUNT_OPTION) || val == Convert.ToInt32(Options.CREATE_ACCOUNT_OPTION) || val == Convert.ToInt32(Options.EXIT_ATM_APPLICATION_OPTION))
                {
                    return val;
                }
                else
                {
                    Console.WriteLine("Please enter a valid menu option.");
                }
            }          
        }

        /* Display the Account Menu and ensure the user picks an option.*/
        public int ShowAccountMenu()
        {
            while (true)
            {
                Console.WriteLine("\nAccount Menu\n\n1: Check Balance\n2: Withdraw\n3: Deposit\n4: Exit\n\nEnter a choice: ");
                int acctMenuVal = Convert.ToInt32(Console.ReadLine());
                if (acctMenuVal == Convert.ToInt32(Options.CHECK_BALANCE_OPTION) || acctMenuVal == Convert.ToInt32(Options.WITHDRAW_OPTION) ||
                    acctMenuVal == Convert.ToInt32(Options.DEPOSIT_OPTION) || acctMenuVal == Convert.ToInt32(Options.EXIT_ACCOUNT_OPTION))
                    return acctMenuVal;
                else
                    Console.WriteLine("Please enter a valid menu option for account menu");
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

        /* Select an account by prompting the user for an account number. */
        public int SelectAccount()
        {
            while (true)
            {
                Console.WriteLine("Please enter your account ID or press [ENTER] to cancel: ");
                String acctNoInput = Console.ReadLine();

                if (acctNoInput.Length == 0)
                {
                    return -1;
                }

                int acctNo = Convert.ToInt32(acctNoInput);

                /*List<Account> acct = FindAccount(acctNo);
                if (acct == null)
                {
                    Console.WriteLine("The account was not found. Please select another account.");
                }
                else
                {*/
                    return 100;
                //}
            }
        }

        /*Manage the account by allowing user to perform operations on the given account*/
        public void ManageAccount(int account)
        {
            while (true)
            {
                int selAcctMenuOpt = ShowAccountMenu();

                switch (selAcctMenuOpt)
                {
                    case (int)Options.CHECK_BALANCE_OPTION:
                        //OnCheckBalance(account);
                        break;
                    case (int)(Options.WITHDRAW_OPTION):
                        //OnWithdrawal(account);
                        break;
                    case (int)(Options.DEPOSIT_OPTION):
                        //OnDeposit(account);
                        break;
                    case (int)(Options.EXIT_ACCOUNT_OPTION):
                        return;
                    default:
                        Console.WriteLine("Please enter a valid menu option");
                        break;
                }
            }
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
        public void OnCheckBalance(List<Account> account)
        { 
            /* Arguments: Account List for which balance needs to be printed
             * 
             * Output to Console "The balance in account" + acctNumber + " is " + account.getAccountBalance()
             * 
             */
        
        }

        /* Prompts the user to enter amount for deposit. Validates data for invalid value and incorrect amount */
        public void OnDeposit(List<Account> account)
        {
            /* While the user enters correct value
             * 
             * create double variable inputAmount
             * Output to Console "Please enter an amount to deposit or type [ENTER] to exit: "
             * Read input from user and store in inputAmount
             * 
             * if length of inputAmount is greater than 0
             *      execute method Account.Deposit with inputAmount as parameter
             *      
             * return
             * 
             * throw ValueError if user entered a non-numeric value
             * 
             * throw InvalidTransaction error if the amount cannot be deposited to the account
             */
        }

        /* Prompts the user to enter amount for withdrawal. Validates data for invalid value and incorrect amount */
        public void OnWithdrawal(List<Account> account)
        {
            /* While the user enters correct value
             * 
             * create double variable inputAmount
             * Output to Console "Please enter an amount to withdraw or type [ENTER] to exit: "
             * Read input from user and store in inputAmount
             * 
             * if length of inputAmount is greater than 0
             *      execute method Account.withdraw with inputAmount as parameter
             *      
             * return
             * 
             * throw ValueError if user entered a non-numeric value
             * 
             * throw InvalidTransaction error if the amount cannot be deposited to the account
             */
        }
    }
}