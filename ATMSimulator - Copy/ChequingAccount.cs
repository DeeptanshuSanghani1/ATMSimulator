using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSimulator
{
    public class ChequingAccount : Account
    {
        //Represents a chequing account that has an overdraft limit and a maximum interest rate"""

        private double _overDraftLimit;
        private double _maxInterestRate;

        public ChequingAccount()
        {
            /*The amount of overdraft is constant. Defined as a class variable and accessible through the name of the class
            along with the DOT notation*/
            _overDraftLimit = 500.0;

            /*The maximum interest rate for checquing accounts.Defined as a class variable and accessible
            through the name of the class along with the DOT notation*/
            _maxInterestRate = 1.0;
        }
        public void setAnnualIntrRate(double newAnnualIntrRatePercentage)
        {
            //Change the annual interest rate on the account.Verify the annual interest rate is valid for a checquing account
            try
            {
                //check to ensure the annual interest rate is valid for a checquing account
                if (newAnnualIntrRatePercentage > _maxInterestRate)
                {
                    throw new Exception("A chequing account cannot have an interest rate greater than " + _maxInterestRate);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            //use the base class to set the annual interest rate
            setAnnualIntrRate(newAnnualIntrRatePercentage);
        }

        public double withdraw(double amount)
        {
            double currentBalance = getAccountBalance();
            double balanceAfterWithdrawal = 0.0;
            //Withdraw the given amount from the account and return the new balance
            try
            {
                if (amount < 0)
                {
                    throw new Exception("Invalid amount provided. Cannot withdraw a negative amount.");
                }

                //check the overdraft on top of the actual balance
                if (amount > currentBalance + _overDraftLimit)
                {
                    throw new Exception("Insufficient funds. Cannot withdraw the provided amount.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            //change the balance
            balanceAfterWithdrawal = currentBalance - amount;

            //provide the new balance to the caller to avoid a getBalance() call
            return balanceAfterWithdrawal;
        }
    }
}
