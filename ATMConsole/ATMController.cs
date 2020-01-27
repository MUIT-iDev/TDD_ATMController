using System;
using System.Collections.Generic;
using System.Text;

namespace ATMConsole
{
    public class ATMController
    {
        public double Money { get; private set; } = 500;

        public bool WithDraw(string username, double amount)
        {
            const int MinWithdrawAmount = 1;
            var isWithdrawRequestValid = Money >= amount && amount >= MinWithdrawAmount;
            if (!isWithdrawRequestValid) return false;

            Money -= amount;
            return isWithdrawRequestValid;
        }

    }
}
