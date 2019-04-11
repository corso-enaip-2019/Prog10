using DP_02_Strategy.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace DP_02_Strategy.PayCalculators
{
    class FixedSalary_Calculator : IPayCalculator
    {
        public decimal CalculatePay(Employee employee, DateTime startDate, DateTime endDate)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            if (endDate < startDate)
                throw new ArgumentException($"{nameof(endDate)}({endDate}) < {nameof(startDate)}({startDate})");

            return employee.FixedSalary;
        }
    }
}
