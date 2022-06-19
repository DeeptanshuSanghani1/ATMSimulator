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
            /* Starts the ATM program by displaying the main menu options
             * 
             * While the user does not select option to Exit
             *      Create int variable selectedOption
             * 
             *      Accept value in selectedOption from ShowMainMenu()
             * 
             *      If selectedOption = Select Account Option
             *          execute SelectAccount() method and store value in acctNo
             *          if acctNo is available
             *              execute ManageAccount() method
             *      else if selectedOption = Create Account Option
             *          execute OnCreateAccount() method
             *      else if selectedOption = Exit ATM Application Option
             *          execute SaveAccountData() method from bank
             *          return
             */

        }

        /* Display the Main Menu and ensure the user picks an option. */
        public int ShowMainMenu()
        {
            /* The method handles non-numeric invalid input but does not check if the user input is the one displayed
             * While the user does not select an option
             * 
             * Output Main Menu
             * Leave 2 lines
             * Output 1. Select Account
             * Leave 1 line
             * Output 2. Create Account
             * Leave 1 line
             * Output 3. Exit
             * Leave 2 lines
             * Output Enter a choice: 
             * 
             * throw ValueError if the user enters a non-numeric value
             * Message for ValueError "Please enter a valid menu option."
             */
            return 0;
        }

        /* Display the Account Menu and ensure the user picks an option.*/
        public int ShowAccountMenu()
        {
            /* The method handles non-numeric invalid input but does not check if the user input is the one displayed 
             * While the user does not select an option
             * 
             * Output Account Menu
             * Leave 2 lines
             * Output 1. Check Balance
             * Leave 1 line
             * Output 2. Withdraw
             * Leave 1 line
             * Output 3. Deposit
             * Leave 1 line
             * Output 4. Exit
             * Leave 2 lines
             * Output Enter a choice: 
             * 
             * throw ValueError if the user enters a non-numeric value
             * Message for ValueError "Please enter a valid menu option."
             */
            return -1;
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
            /* Once account is validated, prompt the user to perform account operations like deposit and withdrawal
             * 
             * While the user does not select an account
             * 
             * create an int variable acctNoInput
             * Output "Please enter your account ID or press [ENTER] to cancel:"
             * Read user input
             * 
             * If length of acctNoInput is 0 
             *      return -1
             * 
             * Create an object acct
             * execute findAccount method from Bank class and store the return object in acct
             * 
             * if object is not null
             *   return acct object
             * else
             *   Output to Console "The account was not found. Please select another account."
             * 
             * throw ValueError with message "Please enter a valid account number (e.g. 100)"
             */

            return -1;
        }

        /*Manage the account by allowing user to perform operations on the given account*/
        public void ManageAccount(List<Account> account)
        {
            /* While the user does not select option to Exit
             * 
             * create int variable selAcctMenuOpt
             * execute method ShowAccountMenu and store the return value in selAcctMenuOpt
             * 
             * if selAcctMenuOpt = Check Balance Option
             *      execute method OnCheckBalance with account as parameter
             * else if selAcctMenuOpt = Withdraw Option
             *      execute method OnWithdraw with account as parameter
             * else if selAcctMenuOpt = Deposit Option
             *      execute method OnDeposit with account as parameter
             * else if selAcctMenuOpt = Exit
             *      return
             * else
             *      Output to Console "Please enter a valid menu option"
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