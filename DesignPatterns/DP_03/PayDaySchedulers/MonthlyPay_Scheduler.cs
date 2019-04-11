﻿using DP_03_Template.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DP_03_Template.PayDaySchedulers
{
    class MonthlyPay_Scheduler : IPayDayScheduler
    {
        public (DateTime Start, DateTime End) GetPayInterval(DateTime date)
        {
            var start = new DateTime(date.Year, date.Month, 1);
            return (start, start.AddMonths(1));
        }

        public bool IsPayDay(DateTime date)
        {
            return date.IsLastDayOfMonth();
        }
    }
}