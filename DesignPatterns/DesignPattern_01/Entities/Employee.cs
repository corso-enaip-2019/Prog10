using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern_01.Entities
{
    interface IEmployee
    {
        int ID { get; set; }
        string Name { get; set; }

        bool IsPayDay { get; }
        decimal CalculatePay();
    }

    abstract class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public abstract bool IsPayDay { get; }

        private decimal _Salary;
        protected virtual decimal Salary {
            get { return _Salary; }
            set { _Salary = value; }
        }


        public abstract decimal CalculatePay();
    }

    class FixedSalary : Employee
    {
        public FixedSalary()
        {
            // Monthly salary
            Salary = 1600m;
        }
        /// <summary>
        /// Last day of the month
        /// </summary>
        public override bool IsPayDay => DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) == DateTime.Now.Day;
        
        public override decimal CalculatePay()
        {
            return Salary;
        }
    }

    class HourlySalary : Employee
    {
        public HourlySalary()
        {
            // Hour salary
            Salary = 30m;
        }

        /// <summary>
        /// Every saturday
        /// </summary>
        public override bool IsPayDay => DateTime.Now.DayOfWeek == DayOfWeek.Saturday;
        
        public override decimal CalculatePay()
        {
            return _weeklyWorkedHours.Sum(h => h.WorkedHours) * Salary;
        }

        List<WorkedHour> _weeklyWorkedHours = new List<WorkedHour>();
        public void Add_DaylyWorkedHours(int hours)
        {
            _weeklyWorkedHours.Add(new WorkedHour(hours));
        }

        class WorkedHour
        {
            public WorkedHour(int workedHours)
            {
                WorkedHours = workedHours;
                WorkDay = DateTime.Now;
            }

            public int WorkedHours { get; }
            public DateTime WorkDay { get; }
        }
    }

    class CommissionPaid : Employee
    {
        public CommissionPaid()
        {

        }

        private decimal _commission = 0.15m;

        List<Sale> sales = new List<Sale>();
        public void Add_Sale(Sale sale)
        {
            sales.Add(sale);
        }
        
        /// <summary>
        /// Every day
        /// </summary>
        public override bool IsPayDay => true;

        /// <summary>
        /// Dayly salary
        /// </summary>
        protected override decimal Salary {
            get { return base.Salary; }
            set {

                var daylySales = sales.Where(s => s.Date == DateTime.Now.Date);

                //base.Salary = 
            }
        }
        
        public override decimal CalculatePay()
        {
            throw new NotImplementedException();
        }
    }

}
