using System;
using System.Collections.Generic;
using System.Text;

namespace DP_02_Strategy.PayDayCalculators
{
    class DaylyPay_Calculator : IPayDayCalculator
    {
        public bool IsPayDay(DateTime date)
        {
            return true;
        }
    }
}
