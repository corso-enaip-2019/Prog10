using System;
using PlugInSystem;

namespace Exercises___Procedural_Paradigm.Exercises
{
    class Ex_1_1 : AExercise
    {
        public override string Description => "Write the answer to all questions";

        public override Version VersionNumber => new Version(1, 1);

        public override void Run(IGUI guiHandler)
        {
            _guiHandler = guiHandler ?? throw new ArgumentNullException(nameof(guiHandler));

            _guiHandler.WriteMessage($"#### {Description} ####");

            _guiHandler.WriteMessage("As we all know, the answer to all the quesions is 42");
        }
    }
}
