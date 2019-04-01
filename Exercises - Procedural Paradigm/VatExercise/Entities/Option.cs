using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VatExercise.Entities
{
    internal class Option
    {
        public string Description;
        public string Code;
        public Action<List<AVAT>> Operation;
    }
}
