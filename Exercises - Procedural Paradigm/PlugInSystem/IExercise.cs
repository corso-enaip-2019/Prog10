using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlugInSystem
{
    public interface IExercise
    {
        string Description { get; }
        Version Number { get; }
        void Run(IGUI guiHandler);
    }
}
