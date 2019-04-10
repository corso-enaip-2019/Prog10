using DP_02_Strategy.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace DP_02_Strategy.PayCalculators
{
    interface IPayCalculator
    {
        decimal CalculatePay(Employee employee, DateTime startDate, DateTime endDate);
    }
}
