using System;
using System.Collections.Generic;
using System.Text;

namespace Test1_Miani.LoanCalculators
{
    abstract class ALoanCalculator: ILoanCalculator
    {
        protected const int years = 10;
        public const decimal Discount = 0.20m;

        public abstract string LoanType { get; }

        public decimal InitialAmount { get; set; }

        public decimal FinalAmount { get; protected set; }

        public bool IsClient { get; set; }

        public void MakeCalculation()
        {
            FinalAmount = InitialAmount;
            for (int i = 0; i < years; i++)
            {
                FinalAmount += CalculateAnnualStake(i);
            }

            if (IsClient)
            {
                ApplyDiscount();
            }
        }

        protected void ApplyDiscount()
        {
            decimal stake = FinalAmount - InitialAmount;
            decimal discountedStake = stake - (stake * Discount);

            FinalAmount = InitialAmount + discountedStake;
        }

        protected abstract decimal CalculateAnnualStake(int year);
    }
}
