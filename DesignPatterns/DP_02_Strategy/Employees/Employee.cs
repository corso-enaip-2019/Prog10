using DP_02_Strategy.PayDaySchedulers;
using DP_02_Strategy.PayCalculators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DP_02_Strategy.Employees
{
    class Employee
    {
        public readonly IPayDayScheduler DayScheduler;
        public readonly IPayCalculator PayCalculator;

        public int ID { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Base rate to calculate the final Pay
        /// </summary>
        public decimal FixedSalary { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal CommisionPercentage { get; set; }

        public IEnumerable<WorkedTime> WorkedHours 
        {
            get { return _WorkedHours; }
        }
        private readonly List<WorkedTime> _WorkedHours;
        
        public IEnumerable<SoldCommision> SoldCommissions {
            get { return _SoldCommissions; }
        }
        private readonly List<SoldCommision> _SoldCommissions;

        public Employee(IPayDayScheduler dayScheduler, IPayCalculator payCalculator)
        {
            DayScheduler = dayScheduler;
            PayCalculator = payCalculator;

            _WorkedHours = new List<WorkedTime>();
            _SoldCommissions = new List<SoldCommision>();
        }
               
        public void Add_DaylyWorkedHours(int hours)
        {
            _WorkedHours.Add(new WorkedTime(hours));
        }

        public void Add_DaylyWorkedHours(DateTime date, int hours)
        {
            _WorkedHours.Add(new WorkedTime(date, hours));
        }
        
        public void Add_Sale(SoldCommision sale)
        {
            _SoldCommissions.Add(sale);
        }

        public bool IsPayDay(DateTime date)
        {
            return DayScheduler.IsPayDay(date);
        }

        public decimal CalculatePay(DateTime date)
        {
            var (Start, End) = DayScheduler.GetPayInterval(date);
            return PayCalculator.CalculatePay(this, Start, End);
        }
    }
}
