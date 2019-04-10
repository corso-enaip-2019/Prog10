using DP_02_Strategy.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP_02_Strategy.PayCalculators
{
    class HourlyPay_Calculator : IPayCalculator
    {
        public HourlyPay_Calculator()
        {
        }


        public decimal CalculatePay(Employee employee, DateTime startDate, DateTime endDate)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            if (endDate < startDate)
                throw new ArgumentException($"{nameof(endDate)} < {nameof(startDate)}: {endDate} < {startDate}");

            var weekDays = employee.WorkedHours
                .Where(wd => startDate < wd.Date && wd.Date < endDate)
                .Sum(h => h.Hours);

            return weekDays * employee.HourlyRate;
        }
    }
}
