using DP_02_Strategy.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DP_02_Strategy.PayDayCalculators
{
    class MonthlyPay_Calculator : IPayDayCalculator
    {
        public bool IsPayDay(DateTime date)
        {
            return date.IsLastDayOfMonth();
        }
    }
}
