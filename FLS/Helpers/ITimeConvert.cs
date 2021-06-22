using System;

namespace FLS.Helpers
{
    public interface ITimeConvert
    {
        TimeSpan StringToTimeSpan(string timeString);

        string TimeSpanToString(TimeSpan time);
    }
}