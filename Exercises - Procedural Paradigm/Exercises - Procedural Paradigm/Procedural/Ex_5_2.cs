using System;
using System.Collections.Generic;
using PlugInSystem;

namespace Exercises_Procedural_Paradigm.Exercises
{
    class Ex_5_2 : AExercise
    {
        public override string Description => "5 Operations";

        public override Version VersionNumber => new Version(5,2);

        public override void Run(IGUI guiHandler)
        {
            _guiHandler = guiHandler ?? throw new ArgumentNullException(nameof(guiHandler));

            _guiHandler.WriteMessage("Read 2 numbers from the Console (giving good input messages to the user), and print all the 5 integer operations in a \"decorated way\"");

            int a = _guiHandler.AskForPositiveInt("Inserisci un numero intero A:");
            int b = _guiHandler.AskForPositiveInt("Inserisci un numero intero B:");

            _guiHandler.WriteMessage($"Somma (a+b): {a + b}");
            _guiHandler.WriteMessage($"Sottrazione (a-b): {a - b}");
            _guiHandler.WriteMessage($"Moltiplicazione (a*b): {a * b}");
            _guiHandler.WriteMessage($"Divisione (a:b): {a / b}");
            _guiHandler.WriteMessage($"Modulo (a%b): {a % b}");
        }

        private void PrintDecorated(string text)
        {
            
            //_guiHandler.WriteMessage()

        }
    }
}
