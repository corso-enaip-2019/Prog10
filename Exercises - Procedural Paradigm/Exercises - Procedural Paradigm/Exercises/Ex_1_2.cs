using System;
using System.Drawing;
using PlugInSystem;

namespace Exercises___Procedural_Paradigm.Exercises
{
    class Ex_1_2 : AExercise
    {
        public override string Description => "Is the number divisible by 42?";

        public override Version VersionNumber => new Version(1, 2);

        public override void Run(IGUI guiHandler)
        {
            _guiHandler = guiHandler ?? throw new ArgumentNullException(nameof(guiHandler));

            int userValue = _guiHandler.AskForPositiveInt("Inserisci un numero positivo: ");

            if (userValue % 42 == 0)
            {
                _guiHandler.WriteMessage("Yeah!!! Il numero è divisibile per 42!", Color.Green);
            }
            else
            {
                _guiHandler.WriteMessage("Mi spiace, il tuo numero non è divisibile per 42!", Color.Red);
            }
        }
    }
}
