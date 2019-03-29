using PlugInSystem;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises___Procedural_Paradigm.GUI
{
    class ConsoleGUI : IGUI
    {
        public bool AskForExit()
        {
            bool valid = false;

            do
            {
                WriteMessage("Vuoi uscire? (s/n):", false);
                var keyOut = AskForKey().Key;
                switch (keyOut)
                {
                    default:
                        WriteMessage("Risposta non valida", Color.Red);
                        break;
                    case ConsoleKey.Escape:
                        return true;
                    case ConsoleKey.S:
                        return true;
                    case ConsoleKey.N:
                        return false;
                }
            }
            while (!valid);

            return false;
        }

        public ConsoleKeyInfo AskForKey(bool intercept = false)
        {
            return Console.ReadKey(intercept);
        }

        public int AskForPositiveInt(string requestMessage)
        {
            int outValue = 0;
            bool valid = false;
            do
            {
                valid = Int32.TryParse(AskForText(requestMessage), out outValue);
                if (!valid || outValue < 0)
                {
                    Console.WriteLine("Valore inserito non valido!");
                    requestMessage = "Inserire un valore valido: ";
                    valid = false;
                }
            }
            while (!valid);

            return outValue;
        }

        public string AskForText(string requestMessage)
        {
            WriteMessage(requestMessage, false);
            return Console.ReadLine();
        }

        public void WriteMessage(string message, bool newLine = true)
        {
            WriteMessage(message, Color.Gray, newLine);
        }

        public void WriteMessage(string message, Color color, bool newLine = true)
        {
            Console.ForegroundColor = ClosestConsoleColor(color.R, color.G, color.B);
            if (newLine)
                Console.WriteLine(message);
            else
                Console.Write(message);
        }

        ConsoleColor ClosestConsoleColor(byte r, byte g, byte b)
        {
            ConsoleColor ret = 0;
            double rr = r, gg = g, bb = b, delta = double.MaxValue;

            foreach (ConsoleColor cc in Enum.GetValues(typeof(ConsoleColor)))
            {
                var n = Enum.GetName(typeof(ConsoleColor), cc);
                var c = System.Drawing.Color.FromName(n == "DarkYellow" ? "Orange" : n); // bug fix
                var t = Math.Pow(c.R - rr, 2.0) + Math.Pow(c.G - gg, 2.0) + Math.Pow(c.B - bb, 2.0);
                if (t == 0.0)
                    return cc;
                if (t < delta)
                {
                    delta = t;
                    ret = cc;
                }
            }
            return ret;
        }
    }
}
