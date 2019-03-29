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
    class Ex_3_1 : AExercise
    {
        public override string Description => "Three and Five";

        public override Version VersionNumber => new Version(3, 1);

        public override void Run(IGUI guiHandler)
        {
            _guiHandler = guiHandler ?? throw new ArgumentNullException(nameof(guiHandler));

            _guiHandler.WriteMessage("All the numbers divisible by 3 and 5, from 1 to 100.");
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                    _guiHandler.WriteMessage(i.ToString());
            }

            _guiHandler.WriteMessage("");
            _guiHandler.WriteMessage("All the numbers divisible by 3 or 5, from 1 to 100.");
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                    _guiHandler.WriteMessage(i.ToString());
            }

            _guiHandler.WriteMessage("");
            _guiHandler.WriteMessage("The first 100 numbers that are divisible by 3 or 5.");
            for (int i = 1, c = 0; c <= 100; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                    _guiHandler.WriteMessage($"{c++}: {i}");
            }
        }
    }
}
