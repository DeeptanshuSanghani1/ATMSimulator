using System;

namespace ATMSimulator
{
    public class ATMApplication
    {
        static Bank bank = new Bank();
        public static void AccountData()
        {
            //use exception handling to ensure the application does not crash
            try
            {
                //create a bank for a more real-life like implementation
                bank.LoadAccountData();

                //create ATM and link it with the bank
                atm = new Atm(bank);

                //start the ATM machine
                atm.Start();
            }
            catch(Exception e)
            {
                Console.WriteLine("An error occurred with the following message: ", e);
            }
        }
    }
}
