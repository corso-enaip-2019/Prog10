using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VatExercise.Entities
{
    class VAT_Normal : AVAT
    {
        public List<decimal> Expenses;
        const decimal IVA_PERCENTAGE = 22M;
        const decimal IRPEF_PERCENTAGE = 23M;

        public VAT_Normal(): base()
        {
            Expenses = new List<decimal>();
        }

        internal override void AddBill(decimal bill)
        {
            Bills.Add(bill);
        }

        internal override void AddExpense(decimal expence)
        {
            Expenses.Add(expence);
        }

        internal override string CalculateAndPrint()
        {
            decimal profit = Utils.Sum(Bills) - Utils.Sum(Expenses);

            if (profit > 0)
            {
                decimal iva = profit * IVA_PERCENTAGE / 100;
                decimal profitWithoutIva = profit - iva;
                decimal irpef = profitWithoutIva * IRPEF_PERCENTAGE / 100;
                decimal net = profitWithoutIva - irpef;
                decimal taxTotal = iva + irpef;

                return ($"Total net gain: {net}; total taxes: {taxTotal}");
            }
            else
            {
                return ($"Profit: {profit}; total taxes: 0");
            }
        }
    }
}
