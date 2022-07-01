using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSimulator
{
    //ATM Simulator creates the link between the bank and the ATM and executes the ATM code
    public class ATMApplication
    {
        public static void AccountData()
        {
            Bank bank = new Bank();

            bank.LoadAccountData();

            ATM atm = new ATM();
            atm.StartATM();

            /* Create a Bank - object for the Bank
             * Load all Accounts from the Bank. Call the method for loading account data.
             * Then create the ATM object within the bank and start the ATM 
             * Catch exceptions using the try catch method
             */
        }
    }
}