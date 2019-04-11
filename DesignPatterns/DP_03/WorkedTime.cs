using System;
using System.Collections.Generic;
using System.Text;

namespace DP_03_Template
{
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
