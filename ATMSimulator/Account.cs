using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSimulator
{
    //Exception class used when an invalid trasaction is performed
    public class InvalidTransaction : Exception
    {
        //Code for InvalidTransaction exception
    }

    //Exception class used when an invalid value is entered
    public class InvalidValue : Exception
    {
        //Code for InvalidValue exception
    }

    /* The Account class is used by the Bank moodule. It defines the bank account and its corresponding attributes
     * epresents an ATM machine. The class displays the main menu and the account menu */
    public class Account
    {
        //Code for Account class
        private enum Constants
        {
            ACCOUNT_TYPE_CHEQUING = 1,
            ACCOUNT_TYPE_SAVINGS = 2
        }
    }
}
