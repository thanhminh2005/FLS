using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FLS.Helpers
{
    public class TimeConvert : ITimeConvert
    {
        public TimeSpan StringToTimeSpan(string timeString)
        {
            TimeSpan time;
            if (!TimeSpan.TryParse(timeString, out time))
            {
                Console.WriteLine("fail" + time.ToString());
            }
            return time;
        }

        public string TimeSpanToString(TimeSpan time)
        {
            var timeString = new DateTime(time.Ticks).ToString("HH:mm");
            return timeString;
        }
    }
}
