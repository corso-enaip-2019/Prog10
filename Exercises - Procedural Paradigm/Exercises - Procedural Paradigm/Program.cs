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
using System.Drawing;

namespace Exercises___Procedural_Paradigm
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleGUI gui = new ConsoleGUI();

            PlugInLoader plugIn = new PlugInLoader();
            var exercises = plugIn.LoadAvailableExercises().OrderBy(x => x.VersionNumber);

            foreach (var exercise in exercises)
            {
                gui.WriteMessage($"##### {exercise.VersionNumber} - {exercise.Description} #####", Color.Yellow);
                exercise.Run(gui);
                Console.ReadKey();
            }

            //VatExerciseMain vat = new VatExerciseMain();
            //vat.Run(null);

            //Console.ReadKey();
        }
    }
}
