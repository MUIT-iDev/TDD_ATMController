using System;
using Xunit;

namespace ATMConsoleTest
{
    public class UnitTest1
    {
        [Fact(DisplayName = "ผู้ใช้กดเงินออกจากตู้ ข้อมูลถูกต้อง ระบบทำการหักเงินแล้วนำเงินออกมา")]
        public void Test1()
        {
            //sut = System Under Test
            var sut = new ATMConsole.ATMController();
            var actual = sut.WithDraw("john", 500);
            Assert.True(actual);

            var expectedMoney = 0;
            Assert.Equal(expectedMoney, sut.Money);
        }

        [Fact(DisplayName = "ผู้ใช้กดเงินออกจากตู้ แต่เงินในบัญชีไม่พอ ระบบทำการแจ้งเตือน")]
        public void Test2()
        {
            var sut = new ATMConsole.ATMController();
            var actual = sut.WithDraw("john", 1000);
            Assert.False(actual);

            var expectedMoney = 500;
            Assert.Equal(expectedMoney, sut.Money);
        }
    }
}
