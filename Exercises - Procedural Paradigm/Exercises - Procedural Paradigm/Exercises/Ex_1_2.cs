using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercises___Procedural_Paradigm.GUI;
using PlugInSystem;

namespace Exercises___Procedural_Paradigm.Exercises
{
    class Ex_1_2 : AExercise
    {
        public override string Description => "Is the number divisible by 42?";

        public override Version Number => new Version(1, 2);

        public override void Run(IGUI guiHandler)
        {
            _guiHandler = guiHandler ?? throw new ArgumentNullException(nameof(guiHandler));

            int userValue = _guiHandler.AskForPositiveInt("Inserisci un numero positivo");

        }
    }
}
