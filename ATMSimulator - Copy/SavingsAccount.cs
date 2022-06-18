    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSimulator
{
    public class SavingsAccount : Account
    {
        //A saving account has specific business logic. It has a minimum interest rate and an additional deposit business rule

        private double _MatchingDepositRatio;
        private double _MinimumIntRate;
        public SavingsAccount()
        {
            /*The matching deposit ratio. For every dollar deposit this account will automatically be credited with 0.5 dollars.
            The account is defined as a class variable and accessible through the name of the class along with the DOT notation*/
            _MatchingDepositRatio = 0.5;

            /*The minimmum interest rate for savings accounts. Defined as a class variable and accessible
            through the name of the class along with the DOT notation*/
            _MinimumIntRate = 3.0;
        }
        public void setAnnualIntrRate(float newAnnualIntrRatePercentage)
        {
            /* Change the annual interest rate on the account. Verify the annual interest rate is valid for a savings account
            Parameters:newAnnualIntrRatePercentage: float -- the annual interest as a percentage (e.g. 3%)*/

            try
            {
                //check to ensure the annual interest rate is valid for a saving account
                if (newAnnualIntrRatePercentage < _MatchingDepositRatio)
                {
                    throw new Exception("A savings account cannot have an interest rate less than " + _MinimumIntRate);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            //use the base class to set the annual interest rate
            setAnnualIntRate(newAnnualIntrRatePercentage);
        }

        public void deposit(double amount)
        {
            /*Deposit the given amount in the account and return the new balance.For every dollar deposited the
              account will be credited with 0.5 dollars with an automatic deposit*/
            Deposit(amount + amount * _MatchingDepositRatio);
        }
    }
}
