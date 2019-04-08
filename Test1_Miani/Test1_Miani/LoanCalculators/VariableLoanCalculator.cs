using System;
using System.Collections.Generic;
using System.Text;

namespace Test1_Miani.LoanCalculators
{
    class VariableLoanCalculator : ALoanCalculator
    {
        List<decimal> _inflationRates = initInflationRates();
        decimal _rate = 1.75m;

        public override string LoanType => "Variabile";

        public override void MakeCalculation()
        {
            FinalAmount = InitialAmount;
            for(int i = 0; i < years; i++)
            {
                decimal annualRate = _rate + _inflationRates[i];
                //decimal annualStake = FinalAmount * annualRate / 100;

                FinalAmount += AnnualStake(annualRate);
                //Console.WriteLine(FinalAmount.ToString("C"));
            }

            if (IsClient)
            {
                ApplyDiscount();
            }
        }

        static List<decimal> initInflationRates()
        {
            List<decimal> _inflationRates = new List<decimal>()
            {
                2m,
                2.5m,
                1.75m,
                3m,
                0.5m,
                1.3m,
                3.5m,
                0.75m,
                1.8m,
                2.2m,
            };

            return _inflationRates;
        }
    }
}
