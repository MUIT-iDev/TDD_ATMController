using System;
using System.Collections.Generic;
using System.Text;

namespace ATMConsole
{
    public interface ILogFile
    {
        void WriteWithdraw(string username, double amount);
    }
}
