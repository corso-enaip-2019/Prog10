using Exercises___Procedural_Paradigm.Exercises;
using Exercises___Procedural_Paradigm.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PlugInSystem;
using VatExercise;

namespace Exercises___Procedural_Paradigm
{
    class Program
    {
        static void Main(string[] args)
        {
            //ConsoleGUI gui = new ConsoleGUI();

            //PlugInLoader plugIn = new PlugInLoader();
            //var exercises = plugIn.LoadAvailableExercises().OrderBy(x => x.Number);

            //foreach(var exercise in exercises)
            //{
            //    exercise.Run(gui);
            //}

            VatExerciseMain vat = new VatExerciseMain();
            vat.Run(null);

            Console.ReadKey();
        }
    }
}
