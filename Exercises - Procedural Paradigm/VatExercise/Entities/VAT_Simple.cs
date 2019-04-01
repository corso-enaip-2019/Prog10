using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VatExercise.Entities
{
    class VAT_Simple: AVAT
    {
        ///Eredita tutto da AVAT

        const decimal SIMPLE_TAXABLE_PERCENTAGE = 78M;
        const decimal SIMPLE_TAX_PERCENTAGE = 15M;

        internal override void AddBill(decimal bill)
        {
            Bills.Add(bill);
        }

        internal override void AddExpense(decimal expence)
        {
            throw new NotImplementedException();
        }

        internal override string CalculateAndPrint()
        {
            decimal billTotal = Utils.Sum(Bills);

            decimal profit = billTotal;

            if (profit > 0)
            {
                decimal taxable = profit * SIMPLE_TAXABLE_PERCENTAGE / 100;
                decimal taxes = taxable * SIMPLE_TAX_PERCENTAGE / 100;
                decimal net = profit - taxes;

                return ($"Net gain: {net}; total taxation: {taxes}");
            }
            else
            {
                return ($"Profit: {profit}");
            }
        }
    }
}
