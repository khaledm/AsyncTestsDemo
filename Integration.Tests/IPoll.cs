using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Integration.Tests
{
    public interface IPoller
    {
        void Check(IProbe probe);
    }

    public class Poller : IPoller
    {
        public Poller(int timeoutInMilliSeconds, int pollDelayInMilliSeconds)
        {
            timeoutMillis = timeoutInMilliSeconds;
            pollDelayMillis = pollDelayInMilliSeconds;
        }

        public int pollDelayMillis { get; private set; }
        public int timeoutMillis { get; private set; }

        public void Check(IProbe probe)
        {
            var timeout = new Timeout(timeoutMillis);
            while (!probe.IsSatisfied())
            {
                if (timeout.HasTimedOut())
                {
                    throw new NUnit.Framework.AssertionException("Failure to complete the assertion (acceptance ctr + error message)");
                }

                Task.Delay(pollDelayMillis).Wait();

                probe.Sample();
            }
        }

        public static void AssertEventually(IProbe probe, int timeout = 1000, int pollDelay = 100)
        {
            new Poller(timeout, pollDelay).Check(probe);
        }
    }
}
