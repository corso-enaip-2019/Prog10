using System;
using System.Collections.Generic;
using System.Text;

namespace Test1_Miani.LoanCalculators
{
    class FixedLoanCalculator : ALoanCalculator
    {
        private decimal _rate = 0.035m;

        public override string LoanType => "Fisso"; 
        
        protected override decimal CalculateAnnualStake(int year)
        {
            return FinalAmount * _rate;
        }
    }
}
