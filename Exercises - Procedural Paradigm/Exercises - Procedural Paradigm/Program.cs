using Exercises.GUI;
using System;
using System.Linq;
using PlugInSystem;
using System.Drawing;

namespace Exercises
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

            //VatExercise.VatExerciseClasses vatClasses = new VatExercise.VatExerciseClasses();
            //vatClasses.Run(gui);

            //StarWars.StarWarsMain starWars = new StarWars.StarWarsMain();
            //starWars.Run(gui);

            //StarWars2_Delegates.StarWarsMain starWarsDelegates = new StarWars2_Delegates.StarWarsMain();

            //starWarsDelegates.Run(gui);

            //StarWars3_Events.StarWarsMain starWarsDelegates = new StarWars3_Events.StarWarsMain();
            //starWarsDelegates.Run(gui);

            Filters.FiltersMain filters = new Filters.FiltersMain();
            filters.Run(gui);

            //Console.ReadKey();
        }
    }
}
