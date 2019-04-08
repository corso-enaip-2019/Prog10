using System;
using System.Collections.Generic;
using System.Text;

namespace Test1_Miani.LoanCalculators
{
    abstract class ALoanCalculator: ILoanCalculator
    {
        protected const int years = 10;
        public const decimal Discount = 20m;

        public abstract string LoanType { get; }

        public decimal InitialAmount { get; set; }

        public decimal FinalAmount { get; protected set; }

        public bool IsClient { get; set; }

        public abstract void MakeCalculation();

        protected void ApplyDiscount()
        {
            decimal stake = FinalAmount - InitialAmount;
            decimal discountedStake = stake - (stake * Discount / 100);

            FinalAmount = InitialAmount + discountedStake;
        }

        protected decimal AnnualStake(decimal rate)
        {
            decimal annualStake = FinalAmount * rate / 100;

            return annualStake;
        }
    }
}
