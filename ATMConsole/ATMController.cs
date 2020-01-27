using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ATMConsole
{
    public class ATMController
    {
        private readonly ILogFile log;
        private readonly IAccountDTA dta;

        public ATMController(ILogFile log, IAccountDTA dta)
        {
            this.log = log;
            this.dta = dta;
        }

        public bool WithDraw(string username, double amount)
        {
            var selectedAccount = GetAccountByUsername(username);

            const int MinWithdrawAmount = 1;
            var isWithdrawRequestValid = selectedAccount != null 
                && selectedAccount.Balance >= amount 
                && amount >= MinWithdrawAmount;
            if (!isWithdrawRequestValid) return false;

            selectedAccount.Balance -= amount;
            log.WriteWithdraw(username, amount);
            return isWithdrawRequestValid;
        }

        public Account GetAccountByUsername(string username)
         => dta.GetAllAccounts().FirstOrDefault(o => o.Username == username);
            

    }
}
