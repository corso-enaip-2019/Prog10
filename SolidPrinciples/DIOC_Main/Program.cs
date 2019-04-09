using ConsoleIO;
using DIOC_Contracts;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DIOC_Main
{
    class Program
    {
        static void Main(string[] args)
        {
            IGui gui = new ConsoleGui();

            var value = gui.ReadInt("Give me an int: ");
            
            //var mathCalculator = LoadMathCalculatorRigid();

            var mathCalculator = LoadMathCalculatorDecoupled();

            bool isPrime = mathCalculator.IsPrime(value);

            gui.Write($"The number { value } is {(isPrime? "": "not ")}prime");

            Console.ReadKey();
        }

        private static IMath LoadMathCalculatorRigid()
        {
            var asm = Assembly.LoadFile(@"C:\Users\triprog-10\source\repos\Prog10\SolidPrinciples\DIOC_MathSlow\bin\Debug\netstandard2.0\DIOC_MathSlow.dll");
            var type = asm.GetType("DIOC_MathSlow.PrimeCalculator");
            var mathCalculator = Activator.CreateInstance(type) as IMath;

            if (mathCalculator == null) throw new Exception("broke");
            return mathCalculator;
        }

        private static IMath LoadMathCalculatorDecoupled()
        {
            var dir = Directory.GetCurrentDirectory();

            var path = Path.Combine(dir, "MathLibrary.dll");

            var library = Assembly.LoadFile(path);
            var iMathInterface = typeof(IMath);

            var mathCalculatorType = library
                .GetTypes()
                .FirstOrDefault(x => x.GetInterfaces().Contains(iMathInterface));

            if (mathCalculatorType == null)
                throw new InvalidOperationException("Type non found");

            var mathCalculator = Activator.CreateInstance(mathCalculatorType) as IMath;

            if (mathCalculator == null)
                throw new InvalidOperationException("Cannot create instance of IMath");

            return mathCalculator;
        }
    }
}
