using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VatExercise.Entities
{
    public abstract class AVAT
    {
        public int VatNumber;
        public List<decimal> Bills;

        public AVAT()
        {
            Bills = new List<decimal>();
        }

        internal abstract void AddBill(decimal bill);

        internal abstract void AddExpense(decimal expence);

        internal abstract string CalculateAndPrint();
    }
}
