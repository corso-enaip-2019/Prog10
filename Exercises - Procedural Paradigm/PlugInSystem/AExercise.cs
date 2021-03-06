﻿using System;

namespace PlugInSystem
{
    public abstract class AExercise : IExercise
    {
        protected IGUI _guiHandler = null;

        public abstract string Description { get; }

        public abstract Version VersionNumber { get; }

        public abstract void Run(IGUI guiHandler);
        
        protected void WriteTitle()
        {
            _guiHandler.WriteMessage($"#### Esercizio {VersionNumber.ToString(2)} ####");
            _guiHandler.WriteMessage($"#### {Description} ####");
        }
    }
}
