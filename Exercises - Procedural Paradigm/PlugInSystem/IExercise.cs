using System;

namespace PlugInSystem
{
    public interface IExercise
    {
        string Description { get; }
        Version VersionNumber { get; }
        void Run(IGUI guiHandler);
    }
}
