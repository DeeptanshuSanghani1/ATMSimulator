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

    public class SavingsAccount : Account
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
        //initialize the account object in the constructor class. Call the base class method to initialize the values
        public SavingsAccount(int acctNumber = -1, string acctHolderName = " ", int id = 0) : base(acctNumber, acctHolderName)
        {

        }

        /* Change the Annual interest Rate for the Savings Account. Validate that the rate is valid for a savings account */
        public void SetAnnualIntrRate(double newAnnualIntrRatePerc)
        {

        }

        /* Deposit the given amount + 0.5 dollars for every dollar in the account and return the new balance */
        public new double Deposit(double amount)
        {
            return 0.0;
        }
    }
}
