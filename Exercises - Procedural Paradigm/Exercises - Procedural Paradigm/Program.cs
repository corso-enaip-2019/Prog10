using Exercises___Procedural_Paradigm.GUI;
using System;
using System.Linq;
using PlugInSystem;
using System.Drawing;

namespace Exercises___Procedural_Paradigm
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleGUI gui = new ConsoleGUI();

            //PlugInLoader plugIn = new PlugInLoader();
            //var exercises = plugIn.LoadAvailableExercises().OrderBy(x => x.VersionNumber);

            //foreach (var exercise in exercises)
            //{
            //    gui.WriteMessage($"##### {exercise.VersionNumber} - {exercise.Description} #####", Color.Yellow);
            //    exercise.Run(gui);
            //    Console.ReadKey();
            //}


            //VatExerciseMain vat = new VatExerciseMain();
            //vat.Run(null);

            //VatExercise.VatExerciseClasses vatClasses = new VatExercise.VatExerciseClasses();
            //vatClasses.Run(gui);

            StarWars.StarWarsMain starWars = new StarWars.StarWarsMain();
            starWars.Run(gui);

            //Console.ReadKey();
        }
    }
}
