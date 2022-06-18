using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSimulator
{
    class Atm : Account
    {
        Bank _bank = new Bank();
        /*The Atm class represents an ATM machine. The class displays and performs the the account management functions
           on a given bank account: checking balance, withdrawing and depositing money*/
        private enum DefaultValues
        {
            // create the MAIN MENU options
            SELECTACCOUNTOPTION = 1,
            CREATEACCOUNTOPTION = 2,
            EXITATMAPPLICATION = 3,
            //create ACCOUNT MENU option
            CHECKBALANCEOPTION = 1,
            WITHDRAWOPTION = 2,
            DEPOSITOPTION = 3,
            EXITACCOUNTOPTION = 4
        }
        public void Start()
        {
            /*Starts the ATM program by displaying the required user options. 
            User navigates the menus managing their accounts*/

            //keep displaying the menu until the user chooses to exit the application
            while (true)
            {
                //#display the main menu and perform the main actions depending on the user's choice
                int selectedOption = ShowMainMenu();

                switch (selectedOption)
                {
                    case (int)DefaultValues.SELECTACCOUNTOPTION: //Select Account
                        int acct = SelectAccount();
                        if (acct != 0)
                        {
                            ManageAccount(acct);
                        }
                        break;

                    case (int)DefaultValues.CREATEACCOUNTOPTION: //Create Account
                        OnCreateAccount();
                        break;

                    case (int)DefaultValues.EXITATMAPPLICATION: //Exit Application
                        //the application is shutting down, save all account information
                        _bank.SaveAccountData();
                        return;

                    default:
                        Console.WriteLine("Please enter a valid menu option", "\n");
                        break;
                }
            }
        }


        public int ShowMainMenu()
        {
            /*Displays the main ATM menu and ensure the user picks an option. Handles invalid input but doesn't check
            that the menu option is one of the displayed ones.
            Returns: the option selected by the user*/
            while (true)
            {
                try
                {
                    Console.WriteLine("Main Menu \n\n1: Select Account\n 2: Create Account\n 3: Exit \n\n Enter a choice: ");
                    string mm_input = (Console.ReadLine());
                    int mm_option = 0;
                    if (!Int32.TryParse(mm_input, out mm_option))
                    {
                        //throw Exception if the input is not a number
                        throw new Exception("Please enter a valid menu option. \n");
                    }
                    else
                    {
                        mm_option = Convert.ToInt32(mm_input);
                    }
                    return mm_option;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            } 
        }

        public int ShowAccountMenu()
        {
            /*Displays the ACCOUNT menu that allows the user to perform account operations. Handles invalid input but doesn't check
              that the menu option is one of the displayed ones.
              Returns: the option selected by the user*/
            while (true)
            {
                try
                {
                    Console.WriteLine("Account Menu \n\n1: Check Balance\n 2: Withdraw\n 3: Deposit \n4: Exit\n\n Enter a choice: ");
                    string am_input = (Console.ReadLine());
                    if (!Int32.TryParse(am_input, out int am_option))
                    {
                        //throw Exception if the input is not a number
                        throw new Exception("Please enter a valid menu option. \n");
                    }
                    else
                    {
                        am_option = Convert.ToInt32(am_input);
                    }
                    return am_option;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public void OnCreateAccount()
        {
            /*Create and open an account. The user is prompted for all account information including the type of account to open.
              Create the account object and add it to the bank*/
            while (true)
            {
                try
                {
                    //get the name of the account holder from the user
                    string clientName = PromptForClientName();

                    //get the initial deposit from the user
                    double initialDepositAmount = PromptForDepositAmount();

                    //get the annual interest rate from the user
                    double annIntrRate = PromptForAnnualIntrRate();

                    //get the account type from the user
                    int acctType = PromptForAccountType();

                    //open the account
                    _bank.openAccount(clientName, acctType);

                    //set the other account propertites
                    newAccount.deposit(initDepositAmount);
                    newAccount.setAnnualIntrRate(annIntrRate);

                    //now the the account has been successfully created and added to the bank the method is done
                    return;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public int SelectAccount()
        {
            //Select an account by prompting the user for an account number and remembering which account was selected.
            //Prompt the user for performing account information such deposit and withdrawals
            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter your account ID or press [ENTER] to cancel: ");
                    String acctNoInput = Console.ReadLine();
                    //check to see if the user gave up and is canceling the operation                
                    if (String.IsNullOrEmpty(acctNoInput))
                    {
                        return null;
                    }
                    if (!Int32.TryParse(acctNoInput, out int acctNo))
                    {
                        //throw Exception if the input is not a number
                        throw new Exception("Please enter a valid account number. \n");
                    }
                    else
                    {
                        //the user entered an account number get the actual number
                        acctNo = Convert.ToInt32(acctNoInput);

                        //obtain the account required by the user from the bank
                        int acct = _bank.findAccount(acctNo);
                        if (acct != 0)
                        {
                            return acct;
                        }
                        else
                        {
                            Console.WriteLine("The account was not found. Please select another account.");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public void ManageAccount(int account)
        {
            //Manage the account by allowing the user to execute operation on the given account

            while (true)
            {
                int selAcctMenuOpt = ShowAccountMenu();

                switch (selAcctMenuOpt)
                {
                    case 1:
                        OnCheckBalance(account);
                        break;

                    case 2:
                        OnWithdraw(account);
                        break;

                    case 3:
                        OnDeposit(account);
                        break;

                    case 4:
                        return;

                    default:
                        Console.WriteLine("Please enter a valid menu option");
                        break;

                }
            }
        }

        public string PromptForClientName()
        {
            string clientName = null;
            //Prompts the user to enter the name of the client and allows the user to cancel by pressing ENTER
            try
            {
                Console.WriteLine("Please enter the client name or press [ENTER] to cancel: ");
                clientName = Console.ReadLine();

                if (clientName.Length == 0)
                {
                    throw new Exception("The user has selected to cancel the current operation");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return clientName;
        }

        public double PromptForDepositAmount()
        {
            //Prompts the user to enter an account balance and performs basic error checking
            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter your initial account balance: ");
                    string s_initAmount = Console.ReadLine();
                    if (!Double.TryParse(s_initAmount, out double initAmount))
                    {
                        throw new Exception("Invalid entry. Please enter a number for your amount.");
                    }
                    else
                    {
                        initAmount = Convert.ToDouble(s_initAmount);
                        if (initAmount >= 0)
                        {
                            return initAmount;
                        }
                        else
                        {
                            Console.WriteLine("Cannot create an account with a negative initial balance. Please enter a valid amount");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public double PromptForAnnualIntrRate()
        {
            //Prompts the user to enter the annual interest rate for an account
            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter the interest rate for this account: ");
                    string s_intrRate = Console.ReadLine();
                    if (!Double.TryParse(s_intrRate, out double intrRate))
                    {
                        throw new Exception("Invalid entry. Please enter a number for your Interest Rate.");
                    }
                    else
                    {
                        //# perform basic sanity checking of the input.
                        intrRate = Convert.ToDouble(s_intrRate);
                        if (intrRate >= 0)
                        {
                            return intrRate;
                        }
                        else
                        {
                            Console.WriteLine("Cannot create an account with negative interest rate.");
                        }

                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public int PromptForAccountType()
        {
            //Prompts the user to enter an account type
            while (true)
            {
                Console.WriteLine("Please enter the account type [c/s: chequing / savings]: ");
                string inputAcctType = Console.ReadLine().ToUpper();
                if (inputAcctType == "C" || inputAcctType == "CHEQUING" || inputAcctType == "CHECKING")
                {
                    //return Account.ACCOUNT_TYPE_CHECQUING;
                    return 1;
                }
                else if (inputAcctType == "S" || inputAcctType == "SAVINGS" || inputAcctType == "SAVING")
                {
                    //return Account.ACCOUNT_TYPE_SAVINGS
                    return 2;
                }
                else
                {
                    Console.WriteLine("Answer not supported. Please enter one of the supported answers.");
                }
            }
        }
        
        public void OnCheckBalance(int account)
        {
            //Prints the balance in the given account
            //Arguments: account - the account for which the balance is printed  
            Console.WriteLine("The balance is " + account.getAccountBalance());

        }

        public void onDeposit(account)
        {
            //Prompts the user for an amount and performs the deposit. Handles any errors related to incorrect amounts
            //Arguments: account - the account in which the amount is to be deposited
            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter an amount to deposit or type [ENTER] to exit: ");
                    string s_inputAmount = Console.ReadLine();
                    //test for empty input in case the user pressed [ENTER] because they wanted to give up on depositing money
                    if (double.TryParse(s_inputAmount, out double inputAmount))
                    {
                        Console.WriteLine("Invalid entry. Please enter a number for your amount.");
                    }
                    else
                    {
                        //the account itself is responsible for checking the amount and raising any errors if the deposit
                        //is not possible like negative amounts 
                        Account.Deposit(inputAmount);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

        }
            
        public void OnWithdraw( double account)
        {
            /*Prompts the user for an amount and performs the withdrawal. Handles any errors related to incorrect amounts
            Arguments: account - the account in which the amount is to be withdrawn*/
            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter an amount to withdraw or type [ENTER] to exit: ");
                    string s_inputAmount = Console.ReadLine();
                    //# test for empty input in case the user pressed [ENTER] because they wanted to give up on withdrawing money
                    if (double.TryParse(s_inputAmount, out double inputAmount))
                    {
                        Console.WriteLine("Invalid entry. Please enter a number for your amount.");
                    }
                    else
                    {
                        //# the account must have refused to withdraw the entered amount. The reason is in the exception object
                        Account.Withdraw(inputAmount);
                        return;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            }
        }

    }
}
