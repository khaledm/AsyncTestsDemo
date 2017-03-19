using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Integration.Tests
{
    [TestFixture]
    public class TimeoutTests
    {
        [Test]
        
        public void ReportsIfTimedOut()
        {
            Timeout timeout = new Timeout(100);
            Assert.IsTrue(!timeout.HasTimedOut(), "should not have timed out");
            Thread.Sleep(100);
            Assert.IsTrue(timeout.HasTimedOut(), "should have timed out definitely");
        }
    }
}
