using System;

namespace DesignPattern_01.Entities.Employees
{
    abstract class AEmployee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Base rate to calculate the final Pay
        /// </summary>
        public virtual decimal Rate { get; set; }

        public abstract bool IsPayDay(DateTime date);
        public abstract decimal CalculatePay(DateTime date);
    }
}
