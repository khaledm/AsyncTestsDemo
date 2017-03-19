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
            endtime = DateTime.Now.AddMilliseconds(totalDuration);
        }

        public DateTime endtime { get; private set; }

        public bool HasTimedOut()
        {
            return TimeRemaining() <= 0;
        }

        private double TimeRemaining()
        {
            return (endtime - DateTime.Now).TotalMilliseconds;
        }
    }
}
