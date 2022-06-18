﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSimulator
{
    /* A chequing account has an overdraft limit and a maximum interest rate*/
    class ChequingAccount
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
    }
}