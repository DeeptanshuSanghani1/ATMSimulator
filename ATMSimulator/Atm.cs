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
        public void ExecuteATM()
        {

        }

        /* Display the Main Menu and ensure the user picks an option. The method handles non-numeric invalid input but does not 
         * check if the user input is the one displayed */
        public void ShowMainMenu()
        {
            
        }

        /* Display the Account Menu and ensure the user picks an option. The method handles non-numeric invalid input but does not 
         * check if the user input is the one displayed */
        public void ShowAccountMenu()
        {

        }

        /* Create and Open an account. The user is asked for all information to open the account. Create the account object 
         * and add it to the bank*/
        public void OnCreateAccount()
        {

        }

        /* Select an account by prompting the user for an account number. Once account is validated, prompt the user to
         * perform account operations like deposit and withdrawal */
        public void SelectAccount()
        {

        }

        /*Manage the account by allowing user to perform operations on the given account*/
        public void ManageAccount()
        {

        }

        /* Prompt the user to enter Client Name for creating a new account. Allows the user to cancel operation by pressing Enter*/
        public string PromptForClientName()
        {
            return null;
        }

        /* Prompt the user to enter Deposit Amount for creating a new account. Performs basic error checking*/
        public double PromptForDepositAmount()
        {
            return 0.0;
        }

        /* Prompts the user to enter Annual Interest Rate for creating the account. */
        public double PromptForAnnualIntrRate()
        {
            return 0.0;
        }

        /* Prompts the user to enter Account Type for creating the account. */
        public int PromptForAccountType()
        {
            return 0;
        }

        /* Print the Balance on the given account to the console */
        public void OnCheckBalance()
        { 
        
        }

        /* Prompts the user to enter amount for deposit. Validates data for invalid value and incorrect amount */
        public void OnDeposit()
        {

        }

        /* Prompts the user to enter amount for withdrawal. Validates data for invalid value and incorrect amount */
        public void OnWithdrawal()
        {

        }
    }
}