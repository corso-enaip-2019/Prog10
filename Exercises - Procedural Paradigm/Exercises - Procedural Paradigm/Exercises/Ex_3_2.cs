using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercises___Procedural_Paradigm.GUI;
using PlugInSystem;

namespace Exercises___Procedural_Paradigm.Exercises
{
    class Ex_3_2 : AExercise
    {
        public override string Description => "Fizz Buzz";

        public override Version VersionNumber => new Version(3, 2);

        public override void Run(IGUI guiHandler)
        {
            _guiHandler = guiHandler ?? throw new ArgumentNullException(nameof(guiHandler));

            _guiHandler.WriteMessage("All the numbers between 1 and 100");
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    _guiHandler.WriteMessage("fizzbuzz");
                }
                else if (i % 3 == 0)
                {
                    _guiHandler.WriteMessage("fizz");
                }
                else if (i % 5 == 0)
                {
                    _guiHandler.WriteMessage("buzz");
                }
                else
                {
                    _guiHandler.WriteMessage($"{i}");
                }
            }
        }
    }
}
