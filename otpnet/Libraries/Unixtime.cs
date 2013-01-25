using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OTPNet
{
    class Unixtime
    {
        private DateTime date;

        public Unixtime()
        {
            this.date = DateTime.Now;
        }

        public Unixtime(int timestamp)
        {
            DateTime converted = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            DateTime newDateTime = converted.AddSeconds(timestamp);
            this.date = newDateTime.ToLocalTime();
        }

        public DateTime toDateTime()
        {
            return this.date;
        }

        public long toTimeStamp()
        {
            TimeSpan span = (this.date - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).ToLocalTime());
            return Convert.ToInt64(span.TotalSeconds);
        }
    }
}
