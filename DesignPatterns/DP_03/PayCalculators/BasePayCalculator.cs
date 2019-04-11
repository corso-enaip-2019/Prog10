using System;
using System.Collections.Generic;
using System.Text;
using DP_03_Template.Employees;

namespace DP_03_Template.PayCalculators
{
    abstract class BasePayCalculator : IPayCalculator
    {
        public decimal CalculatePay(Employee employee, DateTime startDate, DateTime endDate)
        {
            CheckParameters(employee, startDate, endDate);

            decimal amount = CalculateAmout(employee, startDate, endDate);

            return amount;
        }

        private void CheckParameters(Employee employee, DateTime startDate, DateTime endDate)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            if (endDate < startDate)
                throw new ArgumentException($"{nameof(endDate)}({endDate}) < {nameof(startDate)}({startDate})");
        }

        protected abstract decimal CalculateAmout(Employee employee, DateTime startDate, DateTime endDate);
    }
}
