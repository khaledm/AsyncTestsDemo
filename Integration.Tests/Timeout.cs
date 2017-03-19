using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integration.Tests
{
    public class Timeout
    {
        public Timeout(long totalDuration)
        {
            endtime = DateTime.Now.Millisecond + totalDuration;
        }

        public long endtime { get; private set; }

        public bool HasTimedOut()
        {
            return TimeRemaining() <= 0;
        }

        private long TimeRemaining()
        {
            return endtime - DateTime.Now.Millisecond;
        }
    }
}
