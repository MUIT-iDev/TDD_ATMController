using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;

namespace ATMConsoleTest
{
    public class DemoMoq
    {
        [Fact]
        public void DemoMoq01()
        {
            //create mock object
            var mock = new Moq.MockRepository(Moq.MockBehavior.Default);
            var logMocking = mock.Create<ATMConsole.ILogFile>();

            //set action in moq method
            var expectedDate = DateTime.Now;
            logMocking.Setup(o => o.GetCurrentDate(1))
                .Returns(expectedDate);
            logMocking.Setup(o => o.GetCurrentDate(2))
                .Returns(expectedDate.AddDays(1));

            //get object from interface
            var log = logMocking.Object;
            log.WriteWithdraw("sakul", 999);

            //test mocking
            logMocking.Verify(o => 
                o.WriteWithdraw(
                    It.Is<string>(acul => acul == "sakul"), 
                    It.Is<double>(acul => acul == 999)));

            var currentTime = log.GetCurrentDate(1);
            Assert.Equal(expectedDate, currentTime);

            currentTime = log.GetCurrentDate(2);
            Assert.Equal(expectedDate.AddDays(1), currentTime);
        }
    }
}
