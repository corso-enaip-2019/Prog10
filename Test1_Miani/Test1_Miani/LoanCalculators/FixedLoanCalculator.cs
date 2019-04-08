using System;
using System.Collections.Generic;
using System.Text;

namespace Test1_Miani.LoanCalculators
{
    class FixedLoanCalculator : ALoanCalculator
    {
        private decimal _rate = 3.5m;

        public override string LoanType => "Fisso"; 

        public override void MakeCalculation()
        {
            FinalAmount = InitialAmount;
            for (int i = 0; i < years; i++)
            {
                FinalAmount += AnnualStake(_rate);
                //Console.WriteLine(FinalAmount.ToString("C"));
            }

            if (IsClient)
            {
                ApplyDiscount();
            }
        }
    }
}
