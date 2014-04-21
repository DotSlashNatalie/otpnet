using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OTPNet
{
    // Issue reported by larry.ellis
    // Patch provided by andrea.bertin
    // https://code.google.com/p/otpnet/issues/detail?id=1
    class Unixtime
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private readonly DateTime date;

        public Unixtime()
        {
            this.date = DateTime.UtcNow;
        }

        public Unixtime(int timestamp)
        {
            this.date = Epoch.AddSeconds(timestamp);
        }

        public DateTime toDateTime()
        {
            return this.date;
        }

        public long toTimeStamp()
        {
            return (long)this.date.Subtract(Epoch).TotalSeconds;
        }
    }
}
