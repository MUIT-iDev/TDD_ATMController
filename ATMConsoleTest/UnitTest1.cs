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
            Assert.Equal(0, atm.Money);
        }

        [Fact(DisplayName = "ผู้ใช้กดเงินออกจากตู้ แต่เงินในบัญชีไม่พอ ระบบทำการแจ้งเตือน")]
        public void Test2()
        {
            var atm = new ATMConsole.ATMController();
            var result = atm.WithDraw("john", 1000);
            Assert.False(result);
            Assert.Equal(500, atm.Money);
        }
    }
}
