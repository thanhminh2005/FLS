using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FLS.Helpers
{
    public interface ITimeConvert
    {
        TimeSpan StringToTimeSpan(string timeString);
        string TimeSpanToString(TimeSpan time);
    }
}
