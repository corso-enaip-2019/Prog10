﻿using DP_02_Strategy.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP_02_Strategy.PayCalculators
{
    class CommisionPay_Calculator : IPayCalculator
    {
        public CommisionPay_Calculator()
        {

        }

        public decimal CalculatePay(Employee employee, DateTime startDate, DateTime endDate)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            if (endDate < startDate)
                throw new ArgumentException($"{nameof(endDate)}({endDate}) < {nameof(startDate)}({startDate})");

            var daylySales = employee.SoldCommissions
                .Where(s => startDate <= s.Date && s.Date < endDate)
                //.Where(s => s.Date.Date == startDate)
                .Sum(s => s.Amount);

            return daylySales * employee.CommisionPercentage / 100;
        }
    }
}
