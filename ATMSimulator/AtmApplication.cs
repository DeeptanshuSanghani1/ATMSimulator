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
            try
            {
                //Create a Bank for a real-life like implementation
                Bank bank = new Bank();

            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred with the following message: ", e);
            }
        }
    }
}