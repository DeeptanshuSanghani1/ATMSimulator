using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSimulator
{
    /* A chequing account has an overdraft limit and a maximum interest rate*/
    class ChequingAccount : Account
    {
        //Code for chequing account class

        private struct ChqAcctConstants
        {
            /*The amount of overdraft constant.Defined as a struct class variable and accessible
             * through the name of the class along with the DOT notation*/
            public const int OVERDRAFT_LIMIT = 500;

            /* The maximum interest rate for chequing accounts. Defined as a struct class variable and accessible
             * through the name of the class along with the DOT notation*/
            public const double MAX_INTEREST_RATE = 1.0;
        }

        //initialize the account object in the constructor class. Call the base class method to initialize the values
        public ChequingAccount(int acctNumber = -1, string acctHolderName = " ") : base(acctNumber, acctHolderName)
        {

        }

        /* Change the Annual interest Rate for the Chequing Account. Validate that the rate is valid for a chequing account */
        public void SetAnnualIntrRate(double newAnnualIntrRatePerc)
        {
            /* If newAnnualIntrRatePerc > Max Interest Rate (constant value from enum above)
             *      throw InvalidValue error "A chequing account cannot have an interest rate greater than " + Max Interest Rate
             *      
             * execute method setAnnualIntrRate from Account class by passing newAnnualIntrRatePerc
             * 
             */
        }

        /* Withdraw the given amount from the account keeping the overdraft limit in mind and return the new balance */
        public double withdraw(double amount)
        {
            /* Arguments: the amount to be withdrawn
             * 
             * If amount is less than 0
             *      throw InvalidTransaction exception with message "Invalid amount provided. Cannot withdraw a negative amount."
             * 
             * if amount is greater than sum of acctBalance + overdraft limit (constant value from enum above)
             *      throw InvalidTransaction exception with message "Insufficient funds. Cannot withdraw the provided amount.
             *      
             * Substract amount from acctBalance 
             * 
             * return acctBalance 
             */
            return 0.0;
        }
    }
}