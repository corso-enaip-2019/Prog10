using System;
using Test1_Miani.GUI;
using Test1_Miani.LoanCalculators;

namespace Test1_Miani
{
    internal class LoanApplication
    {
        private IGui gui;
        private ILoanCalculator loanType;

        public LoanApplication(IGui gui, ILoanCalculator loanType)
        {
            this.gui = gui;
            this.loanType = loanType;
        }

        internal void Run()
        {
            gui.WriteMessage($"Il cliente ha richiesto {loanType.InitialAmount.ToString("C")} con tasso {loanType.LoanType}");
            loanType.MakeCalculation();
            decimal stake = Math.Round(loanType.FinalAmount - loanType.InitialAmount, 2);

            decimal finalPrintValue = Math.Round(loanType.FinalAmount, 2);

            gui.WriteMessage($"Il totale finale del prestito sarà di {finalPrintValue.ToString("C")} ovvero un interesse di {stake.ToString("C")}");
            //if (loanType.IsClient)
            //{
                
            //    gui.WriteMessage($"Essendo nostro cliente si applica uno sconto del {ALoanCalculator.Discount} e dunque l'interesse finale sarà di {stake.ToString("C")}");
            //}
        }
    }
}