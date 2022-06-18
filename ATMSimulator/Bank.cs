using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSimulator
{
    //Exception Class for user cancel event (when the user cancels the operation by pressing ENTER)
    public class OperationCancel : Exception
    {
        //Code for OperationCancel exception
    }

    //Class for Bank composed of a list of accounts. If accounts are not available, default accounts are created
    public class Bank
    {
        //Code for Bank class
        
        //Define Constant Values
        private enum Constant
        {
            DEFAULT_ACCT_NO_START = 100
        }

    }
}