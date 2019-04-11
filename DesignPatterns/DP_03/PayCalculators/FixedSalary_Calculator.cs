using DP_03_Template.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace DP_03_Template.PayCalculators
{
    class FixedSalary_Calculator : BasePayCalculator
    {
        protected override decimal CalculateAmout(Employee employee, DateTime startDate, DateTime endDate)
        {
            return employee.FixedSalary;
        }
    }
}
