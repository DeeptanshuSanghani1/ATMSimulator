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
        }
    }
}