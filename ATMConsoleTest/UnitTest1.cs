using System;
using System.Collections.Generic;
using Xunit;

namespace ATMConsoleTest
{
    public class UnitTest1
    {
        private ATMConsole.ATMController sut;

        public UnitTest1()
        {
            //sut = System Under Test
            sut = new ATMConsole.ATMController();
            sut.Accounts = new List<ATMConsole.Account>
            {
                new ATMConsole.Account { Username = "john", Balance = 500 },
                new ATMConsole.Account { Username = "doe", Balance = 500 },
            };
        }


        [Theory(DisplayName = "ผู้ใช้กดเงินออกจากตู้ ข้อมูลถูกต้อง ระบบทำการหักเงินแล้วนำเงินออกมา")]
        [InlineData("john", 500, 0)]
        [InlineData("john", 450, 50)]
        [InlineData("john", 1, 499)]
        public void Test1(string username, double withdrawAmount, double expectedMoney)
        {            
            var actual = sut.WithDraw(username, withdrawAmount);
            Assert.True(actual);

            var selectedAccount = sut.GetAccountByUsername(username);
            Assert.Equal(expectedMoney, selectedAccount.Balance);
        }

        [Theory(DisplayName = "ผู้ใช้กดเงินออกจากตู้ ข้อมูลไม่ถูกต้อง ระบบทำการแจ้งเตือน")]
        [InlineData("john", 0, 500)]
        [InlineData("john", -1, 500)]
        [InlineData("unknow", 100, 0)]
        public void Test3(string username, double withdrawAmount, double expectedMoney)
        {
            var actual = sut.WithDraw(username, withdrawAmount);
            Assert.False(actual);

            var selectedAccount = sut.GetAccountByUsername(username);
            Assert.Equal(expectedMoney, selectedAccount.Balance);
        }

        [Fact(DisplayName = "ผู้ใช้กดเงินออกจากตู้ แต่เงินในบัญชีไม่พอ ระบบทำการแจ้งเตือน")]
        public void Test2()
        {
            //var sut = new ATMConsole.ATMController();
            //var actual = sut.WithDraw("john", 1000);
            //Assert.False(actual);

            //var expectedMoney = 500;
            //Assert.Equal(expectedMoney, sut.Money);
        }
    }
}
