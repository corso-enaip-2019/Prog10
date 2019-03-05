using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Esercizio1.Entity {
	abstract class AFormaGeometrica : IFormaGeometrica {

		public List<Lato> sides = new List<Lato>();
		public List<Lato> Sides {
			get { return sides; }
			set { sides = value; }
		} 

		public abstract bool IsValidFigure(List<Lato> Sides);
	}
}
