using System;
using System.Collections.Generic;
using System.Text;
using Test1_Miani.LoanCalculators;

namespace Test1_Miani.GUI
{
    class ConsoleGui : IGui
    {
        static ConsoleGui()
        {
            Console.OutputEncoding = Encoding.Default;
        }

        public bool AskForExit()
        {
            bool exit = false;
            while (!exit)
            {
                WriteMessage("Vuoi uscire dal programma? (s/n)");
                var keyOut = Console.ReadKey();

                if (keyOut.Key == ConsoleKey.S)
                {
                    return true;
                }
                else if (keyOut.Key == ConsoleKey.N)
                {
                    return false;
                }
                else
                {
                    WriteMessage("L'opzione scelta non è valida!", ConsoleColor.Red);
                }
            }

            return false;
        }

        public LoanType AskForLoanType(string message)
        {
            LoanType type = LoanType.Null;
            while (type == LoanType.Null)
            {
                //foreach (LoanType tipe in Enum.GetValues(typeof(LoanType)))
                //{
                //    if (tipe != LoanType.Null)
                //        WriteMessage(tipe.ToString());
                //}
                WriteMessage("1) Tasso fisso", ConsoleColor.Yellow);
                WriteMessage("2) Tasso variabile", ConsoleColor.Yellow);

                WriteMessage($"{message}", ConsoleColor.Gray, false);
                string strType = Console.ReadLine();

                int selection = 0;

                if (!int.TryParse(strType, out selection))
                {
                    WriteMessage("Il valore selezionato non è valido", ConsoleColor.Red);
                }
                else
                {
                    if (selection == 1) return LoanType.Fixed;
                    if (selection == 2) return LoanType.Variable;
                }
            }

            return type;
        }

        public decimal AskForDecimal(string requestMessage)
        {
            decimal outValue = 0;

            while (outValue == 0)
            {
                WriteMessage(requestMessage, ConsoleColor.Gray, false);
                string strOut = Console.ReadLine();

                if(!decimal.TryParse(strOut, out outValue))
                {
                    WriteMessage("Il valore selezionato non è valido!", ConsoleColor.Red);
                }
            }

            return outValue;
        }

        public bool AskForBool(string requestMessage)
        {
            bool outValue = false;
            bool validConversion = false;
            while (!validConversion)
            {
                WriteMessage($"{requestMessage} (s/n)", ConsoleColor.Gray, false);
                string strOut = Console.ReadLine();

                if (strOut.ToLower() == "s") return true;
                if (strOut.ToLower() == "n") return false;
            }

            return outValue;
        }

        //public T AskForValue<T>(string requestMessage)
        //{
        //    bool exit = false;
        //    T outValue = default(T);

        //    while (!exit)
        //    {
        //        WriteMessage(requestMessage, ConsoleColor.Gray, false);
        //        string strOut = Console.ReadLine();

        //        if (TryChangeType(strOut, out outValue))
        //        {
        //            exit = true;
        //        }
        //        else
        //        {
        //            WriteMessage("Il valore selezionato non è valido!", ConsoleColor.Red);
        //        }
        //    }

        //    return outValue;
        //}

        //public static bool TryChangeType<T, TR>(T input, out TR output) where T : IConvertible
        //{
        //    bool result = false;
        //    try
        //    {
        //        Type type = Nullable.GetUnderlyingType(typeof(TR));
        //        output = (TR)Convert.ChangeType(input, type);
        //        result = true;
        //    }
        //    catch (Exception)
        //    {
        //        output = default(TR);
        //    }
        //    return result;
        //}

        public void WriteMessage(string message, ConsoleColor color = ConsoleColor.Gray, bool newLine = true)
        {
            Console.ForegroundColor = color;

            if (newLine)
            {
                Console.WriteLine(message);
            }
            else
            {
                Console.Write(message);
            }

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void ClearScreen()
        {
            Console.Clear();
        }
    }
}
