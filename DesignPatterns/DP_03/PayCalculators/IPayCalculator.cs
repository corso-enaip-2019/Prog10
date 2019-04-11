using DP_03_Template.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace DP_03_Template.PayCalculators
{
    interface IPayCalculator
    {
        decimal CalculatePay(Employee employee, DateTime startDate, DateTime endDate);
    }
}
