using System;
using System.Collections.Generic;
using System.Text;

namespace ATMConsole
{
    public interface IAccountDTA
    {
        IEnumerable<Account> GetAllAccounts();
    }
}
