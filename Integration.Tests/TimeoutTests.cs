namespace Integration.Tests
{
    using System.Threading.Tasks;
    using NUnit.Framework;

    [TestFixture]
    public class TimeoutTests
    {
        [Test]
        public void ReportsIfTimedOut()
        {
            Timeout timeout = new Timeout(100);
            Assert.IsTrue(!timeout.HasTimedOut(), "should not have timed out");
            Task.Delay(100).Wait();
            Assert.IsTrue(timeout.HasTimedOut(), "should have timed out definitely");
        }
    }
}
