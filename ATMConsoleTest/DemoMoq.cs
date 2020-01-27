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

            //get object from interface
            var log = logMocking.Object;
            log.WriteWithdraw("sakul", 123);

            //test mocking
            logMocking.Verify(o => 
                o.WriteWithdraw(
                    It.Is<string>(acul => acul == "sakul"), 
                    It.Is<double>(acul => acul == 999)));

        }
    }
}
