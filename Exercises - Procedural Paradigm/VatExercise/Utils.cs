using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VatExercise
{
    internal class Utils
    {
        internal static decimal Sum(List<decimal> list)
        {
            decimal total = 0M;

            foreach (decimal item in list)
                total += item;

            return total;
        }
    }
}
