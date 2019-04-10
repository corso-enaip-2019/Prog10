using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPattern_01.Entities.Employees
{
    class CommissionPaid_Employee : AEmployee
    {
        public CommissionPaid_Employee()
        {
            _SoldCommissions = new List<SoldCommision>();
        }

        public IEnumerable<SoldCommision> SoldCommissions 
        {
            get { return _SoldCommissions; }
        }
        private readonly List<SoldCommision> _SoldCommissions;

        public void Add_Sale(SoldCommision sale)
        {
            _SoldCommissions.Add(sale);
        }

        /// <summary>
        /// Every day
        /// </summary>
        public override bool IsPayDay(DateTime date)
        {
            return true;
        }

        public override decimal CalculatePay(DateTime date)
        {
            var daylySales = SoldCommissions
                .Where(s => s.Date.Date == date);

            return daylySales.Sum(s => s.Amount) * Rate;
        }

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
}
