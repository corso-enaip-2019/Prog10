using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Esercizio1 {
	abstract class AFormaGeometrica : IFormaGeometrica {

		public Dictionary<string, int> sides = new Dictionary<string, int>();
		public Dictionary<string, int> Sides {
			get { return sides; }
			set { sides = value; }
		} 

		public abstract bool IsValidFigure(Dictionary<string, int> Sides);
	}
}
