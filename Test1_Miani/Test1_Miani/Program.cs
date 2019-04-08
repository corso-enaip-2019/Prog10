using System;
using Test1_Miani.GUI;
using Test1_Miani.LoanCalculators;

namespace Test1_Miani
{
    class Program
    {
        static void Main(string[] args)
        {
            IGui gui = new ConsoleGui();
            bool exit = false;

            while (!exit)
            {
                gui.ClearScreen();
                ILoanCalculator calculator = AskForLoanCalculator(gui);

                LoanApplication loanApp = new LoanApplication(gui, calculator);
                loanApp.Run();


                exit = gui.AskForExit();
            }

            Console.ReadKey();
        }

        static ILoanCalculator AskForLoanCalculator(IGui gui)
        {
            LoanType loanType = gui.AskForLoanType("Quale tipo di mutuo desideri?");
            ILoanCalculator calculator = null;

            decimal initialAmount = gui.AskForDecimal("Quanti soldi si desidera richiedere?");
            bool isClient = gui.AskForBool("Sei già cliente della banca?");

            switch (loanType)
            {
                case LoanType.Fixed:
                    calculator = new FixedLoanCalculator();
                    break;
                case LoanType.Variable:
                    calculator = new VariableLoanCalculator();
                    break;
            }

            calculator.InitialAmount = initialAmount;
            calculator.IsClient = isClient;

            return calculator;
        }
    }
}
