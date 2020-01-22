using System;
using System.Collections.Generic;
using System.Text;

namespace ATMConsole
{
    public class ATMController
    {
        public double Money { get; set; } = 500;

        public bool WithDraw(string username, double amount)
        {
            if (Money >= amount)
            {
                Money -= amount;
                return true;
            }

            return false;
        }

    }
}
