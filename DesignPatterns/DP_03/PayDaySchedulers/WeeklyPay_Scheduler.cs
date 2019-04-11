using System;
using System.Collections.Generic;
using System.Text;

namespace DP_03_Template.PayDaySchedulers
{
    class WeeklyPay_Scheduler : IPayDayScheduler
    {
        private DayOfWeek _payDay = DayOfWeek.Saturday;
        public DayOfWeek PayDay { get => _payDay; set => _payDay = value; }

        public (DateTime Start, DateTime End) GetPayInterval(DateTime date)
        {
            var shift = ((int)PayDay) - ((int)date.DayOfWeek) + 1;
            var end = date.Date.AddDays(shift);
            var start = end.AddDays(-7);

            return (start, end);
        }

        public bool IsPayDay(DateTime date)
        {
            return date.DayOfWeek == PayDay;
        }
    }
}
