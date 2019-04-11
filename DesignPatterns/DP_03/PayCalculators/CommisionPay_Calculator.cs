using DP_03_Template.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP_03_Template.PayCalculators
{
    class CommisionPay_Calculator : BasePayCalculator
    {
        protected override decimal CalculateAmout(Employee employee, DateTime startDate, DateTime endDate)
        {
            var daylySales = employee.SoldCommissions
                .Where(s => startDate <= s.Date && s.Date < endDate)
                //.Where(s => s.Date.Date == startDate)
                .Sum(s => s.Amount);

            return daylySales * employee.CommisionPercentage / 100;
        }
    }
}
