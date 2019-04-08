using System;
using System.Collections.Generic;
using System.Text;

namespace Test1_Miani.LoanCalculators
{
    class VariableLoanCalculator : ALoanCalculator
    {
        List<decimal> _inflationRates = initInflationRates();
        decimal _rate = 0.0175m;

        public override string LoanType => "Variabile";

        protected override decimal CalculateAnnualStake(int year)
        {
            decimal annualRate = _rate + _inflationRates[year];
            decimal annualStake = FinalAmount * annualRate;

            return annualStake;
        }

        static List<decimal> initInflationRates()
        {
            List<decimal> _inflationRates = new List<decimal>()
            {
                0.02m,
                0.025m,
                0.0175m,
                0.03m,
                0.005m,
                0.013m,
                0.035m,
                0.0075m,
                0.018m,
                0.022m,
            };

            return _inflationRates;
        }
    }
}
