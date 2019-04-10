using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPattern_01.Entities.Employees
{
    class HourlyPaid_Employee : AEmployee
    {
        public HourlyPaid_Employee()
        {
            _WorkedHours = new List<WorkedTime>();
        }

        public IEnumerable<WorkedTime> WorkedHours 
        {
            get { return _WorkedHours.ToList(); }
        }
        private readonly List<WorkedTime> _WorkedHours;

        /// <summary>
        /// Every saturday
        /// </summary>
        public override bool IsPayDay(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday;
        }

        public override decimal CalculatePay(DateTime date)
        {            
            var now = date.AddDays(1); //domenica 00:00:00 (oggi)
            var start = now.AddDays(-7); //domenica 00:00:00 (settimana precedente)

            var weekDays = WorkedHours.Where(wd => start < wd.Date && wd.Date < now);
            var weeklyWorkedHours = weekDays.Sum(h => h.Hours);
            return weeklyWorkedHours * Rate;
        }

        public void Add_DaylyWorkedHours(int hours)
        {
            _WorkedHours.Add(new WorkedTime(hours));
        }

        public void Add_DaylyWorkedHours(DateTime date, int hours)
        {
            _WorkedHours.Add(new WorkedTime(date, hours));
        }

        public struct WorkedTime
        {
            /// <summary>
            /// Aggiunge un record ad una data precisa
            /// </summary>
            /// <param name="date">Giorno di lavoro</param>
            /// <param name="hours">Ore lavorate</param>
            public WorkedTime(DateTime date, int hours)
            {
                Hours = hours;
                this.Date = date;
            }

            /// <summary>
            /// Aggiunge un record a oggi.
            /// </summary>
            /// <param name="hours">Ore lavorate</param>
            public WorkedTime(int hours) : this(DateTime.Now, hours)
            {

            }

            public int Hours { get; }
            public DateTime Date { get; }
        }
    }
}
