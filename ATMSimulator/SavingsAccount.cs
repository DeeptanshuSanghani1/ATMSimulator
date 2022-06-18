using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSimulator
{
    /* A savings account is a special type of account and has specific business logic.
     * It has a minimum interest rate and an additional deposit business rule 
     * The bank will credit the account with 50% additional amount for every dollar deposited by the account holder
     * Additionally A minimum interest rate is payable on the deposits held in a Savings Account*/

    public class SavingsAccount
    {
        //Code for Savings Account
        private struct ChqAcctConstants
        {
            /*The matching deposit ratio. For every dollar deposit this account will automatically be credited with 0.5 dollars. 
             * Defined as a struct class variable and accessible through the name of the class along with the DOT notation*/
            public const double MATCHING_DEPOSIT_RATIO = 0.5;

            /* The minimmum interest rate for savings accounts. Defined as a struct class variable and accessible
             * through the name of the class along with the DOT notation*/
            public const double MIN_INTEREST_RATE = 3.0;
        }

    }
}
