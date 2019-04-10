using DesignPattern_01.Extensions;
using System;

namespace DesignPattern_01.Entities.Employees
{
    class FixedSalary_Employee : AEmployee
    {
        public FixedSalary_Employee()
        {

        }

        /// <summary>
        /// Last day of the month
        /// </summary>
        public override bool IsPayDay(DateTime date)
        {
            return date.IsLastDayOfMonth();
        }            

        public override decimal CalculatePay(DateTime date)
        {
            return Rate;
        }
    }
}
