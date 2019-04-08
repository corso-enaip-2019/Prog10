using System;
using System.Collections.Generic;
using System.Text;

namespace Test1_Miani.LoanCalculators
{
    enum LoanType
    {
        Null = 0,
        Fixed = 1,
        Variable = 2,
    }

    interface ILoanCalculator
    {
        string LoanType { get; }
        decimal InitialAmount { get; set; }
        decimal FinalAmount { get; }
        bool IsClient { get; set; }
        void MakeCalculation();
    }
}
