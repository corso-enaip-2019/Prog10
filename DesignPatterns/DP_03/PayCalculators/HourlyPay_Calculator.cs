using DP_03_Template.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP_03_Template.PayCalculators
{
    class HourlyPay_Calculator : BasePayCalculator
    {
        protected override decimal CalculateAmout(Employee employee, DateTime startDate, DateTime endDate)
        {
            var weekDays = employee.WorkedHours
                .Where(wd => startDate <= wd.Date && wd.Date < endDate)
                .Sum(h => h.Hours);

            return weekDays * employee.HourlyRate;
        }
    }
}
