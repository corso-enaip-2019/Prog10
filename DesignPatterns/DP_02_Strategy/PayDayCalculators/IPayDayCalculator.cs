using System;
using System.Collections.Generic;
using System.Text;

namespace DP_02_Strategy.PayDayCalculators
{
    interface IPayDayCalculator
    {
        bool IsPayDay(DateTime date);
    }
}
