using System;
using System.Collections.Generic;
using System.Text;
using Test1_Miani.LoanCalculators;

namespace Test1_Miani.GUI
{
    interface IGui
    {
        bool AskForExit();
        LoanType AskForLoanType(string message);
        void WriteMessage(string message, ConsoleColor color = ConsoleColor.Gray, bool newLine = true);
        void ClearScreen();

        //T AskForValue<T>(string requestMessage);
        decimal AskForDecimal(string requestMessage);
        bool AskForBool(string requestMessage);
    }
}
