using System;
using Xunit;

namespace ATMConsoleTest
{
    public class UnitTest1
    {
        [Fact(DisplayName = "ผู้ใช้กดเงินออกจากตู้ ข้อมูลถูกต้อง ระบบทำการหักเงินแล้วนำเงินออกมา")]
        public void Test1()
        {
            var atm = new ATMConsole.ATMController();
            var result = atm.WithDraw("john", 500);
            Assert.True(result);
        }
    }
}
