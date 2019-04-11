using System;
using System.Collections.Generic;
using System.Text;

namespace DP_02_Strategy.PayDaySchedulers
{
    class DaylyPay_Scheduler : IPayDayScheduler
    {
        public (DateTime Start, DateTime End) GetPayInterval(DateTime date)
        {
            return (date, date.AddDays(1));
        }

        public bool IsPayDay(DateTime date)
        {
            return true;
        }
    }
}
