using System;
using System.Collections.Generic;
using System.Text;

namespace DP_03_Template
{
    public struct SoldCommision
    {
        /// <summary>
        /// Aggiunge un record ad una data precisa
        /// </summary>
        /// <param name="date">Giorno di lavoro</param>
        /// <param name="amount">Quantità venduta</param>
        public SoldCommision(DateTime date, decimal amount)
        {
            Amount = amount;
            Date = date;
        }

        /// <summary>
        /// Aggiunge un record a oggi.
        /// </summary>
        /// <param name="amount">Quantità venduta</param>
        public SoldCommision(decimal amount) : this(DateTime.Now, amount)
        {

        }

        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
