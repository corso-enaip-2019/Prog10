using System;
using System.Collections.Generic;
using PlugInSystem;

namespace Exercises_Procedural_Paradigm.Exercises
{
    class Ex_4 : AExercise
    {
        public override string Description => "String concatenation";

        public override Version VersionNumber => new Version(4,0);

        public override void Run(IGUI guiHandler)
        {
            _guiHandler = guiHandler ?? throw new ArgumentNullException(nameof(guiHandler));

            _guiHandler.WriteMessage("Create 3 strings, then print their concatenations forward and backward");

            List<string> strings = new List<string>();
            strings.Add("Io");
            strings.Add("Sono");
            strings.Add("TuoPadre");

            string strOut = "";
            for (int i = 0; i < strings.Count; i++)
            {
                strOut = String.Concat(strOut, strings[i]);
            }
            _guiHandler.WriteMessage(strOut);

            strOut = "";
            for (int i = strings.Count-1; i >= 0; i--)
            {
                strOut = String.Concat(strOut, strings[i]);
            }
            _guiHandler.WriteMessage(strOut);
        }
    }
}
