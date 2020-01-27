﻿using System;
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
                new ATMConsole.Account { Username = "doe", Balance = 50 },
            };
        }


        [Theory(DisplayName = "ผู้ใช้กดเงินออกจากตู้ ข้อมูลถูกต้อง ระบบทำการหักเงินแล้วนำเงินออกมา")]
        [InlineData("john", 500, 0)]
        [InlineData("john", 450, 50)]
        [InlineData("john", 1, 499)]
        public void WithdrawWithAllDataCorrectSystemAcceptTheResult(string username, double withdrawAmount, double expectedMoney)
        {            
            var actual = sut.WithDraw(username, withdrawAmount);
            Assert.True(actual);

            var selectedAccount = sut.GetAccountByUsername(username);
            Assert.Equal(expectedMoney, selectedAccount.Balance);
        }

        [Theory(DisplayName = "ผู้ใช้กดเงินออกจากตู้ ข้อมูลไม่ถูกต้อง ระบบทำการแจ้งเตือน")]
        [InlineData("john", 0, 500)]
        [InlineData("john", -1, 500)]
        public void WithdrawWithSomeDataIncorrectSystemMustNotAcceptTheResult(string username, double withdrawAmount, double expectedMoney)
        {
            var actual = sut.WithDraw(username, withdrawAmount);
            Assert.False(actual);

            var selectedAccount = sut.GetAccountByUsername(username);
            Assert.Equal(expectedMoney, selectedAccount.Balance);
        }

        [Theory(DisplayName = "ผู้ใช้ที่ไม่มีอยู่ในระบบทำการถอนเงิน ระบบไม่ยอมให้ถอนเงิน")]
        [InlineData("unknow", 100, 0)]
        [InlineData("", 100, 0)]
        [InlineData(null, 100, 0)]
        public void InvalidUserTryWithdrawThenSystemMustNotAcceptTheResult(string username, double withdrawAmount, double expectedMoney)
        {
            var actual = sut.WithDraw(username, withdrawAmount);
            Assert.False(actual);

            var selectedAccount = sut.GetAccountByUsername(username);
            Assert.Null(selectedAccount);
        }

        [Theory(DisplayName = "ผู้ใช้กดเงินออกจากตู้ แต่เงินในบัญชีไม่พอ ระบบทำการแจ้งเตือน")]
        [InlineData("doe", 100, 50)]
        public void WithdrawWhenBalanceNotEnoughtThenSystemMustNotAcceptTheResult(string username, double withdrawAmount, double expectedMoney)
        {
            var actual = sut.WithDraw(username, withdrawAmount);
            Assert.False(actual);

            var selectedAccount = sut.GetAccountByUsername(username);
            Assert.Equal(expectedMoney, selectedAccount.Balance);
        }
    }
}
