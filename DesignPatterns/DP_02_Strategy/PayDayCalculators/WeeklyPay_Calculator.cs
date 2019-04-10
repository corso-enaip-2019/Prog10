using System;
using System.Collections.Generic;
using System.Text;

namespace DP_02_Strategy.PayDayCalculators
{
    class WeeklyPay_Calculator : IPayDayCalculator
    {
        public bool IsPayDay(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday;
        }
    }
}
