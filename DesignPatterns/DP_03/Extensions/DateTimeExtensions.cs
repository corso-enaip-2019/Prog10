using System;
using System.Collections.Generic;
using System.Text;

namespace DP_03_Template.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool IsLastDayOfMonth(this DateTime time)
        {
            return DateTime.DaysInMonth(time.Year, time.Month) == time.Day;
        }

    }
}
