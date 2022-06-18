using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSimulator
{
    /*The Atm class represents an ATM machine. The class displays the main menu and the account menu 
     * and performs the account management functions on a bank account: checking balance, withdrawal and depositing amount*/
    class ATM
    {
        //Code for ATM class

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
    }
}