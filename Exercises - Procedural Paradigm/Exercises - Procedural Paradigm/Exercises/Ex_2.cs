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
    class Ex_2 : AExercise
    {
        public override string Description => "Double and Triple of a number";

        public override Version VersionNumber => new Version(2, 0);

        public override void Run(IGUI guiHandler)
        {
            _guiHandler = guiHandler ?? throw new ArgumentNullException(nameof(guiHandler));

            int myValue = 42;

            _guiHandler.WriteMessage($"La risposta a tutte le domande è: {myValue}");
            _guiHandler.WriteMessage($"Il suo doppio è: {myValue * 2}");
            _guiHandler.WriteMessage($"Il suo triplo è: {myValue * 3}");
        }
    }
}
