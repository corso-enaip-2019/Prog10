using DIOC_Contracts;
using System;

namespace ConsoleIO
{
    public class ConsoleGui : IGui
    {
        public int ReadInt(string message)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(message);
                while (true)
                {
                    var canConvert = int.TryParse(Console.ReadLine(), out int value);
                    if (canConvert)
                        return value;

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid value. Re-enter: ");
                }
            }
            finally
            {
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public void Write(string message, bool newLine = true)
        {
            if (newLine)
                Console.WriteLine(message);
            else
                Console.Write(message);
        }
    }
}
