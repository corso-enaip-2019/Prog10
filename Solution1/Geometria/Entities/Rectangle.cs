using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria.Entities {
	class Rectangle: AShape {

		int Base;
		int Altezza;

		public Rectangle(int Base, int Altezza) {
			this.Base = Base;
			this.Altezza = Altezza;
		}

		public override string ToString() {
			if (Base == Altezza) {
				return $"Quadrato di lato {Base}";
			}
			else {
				return $"Rettangolo di base {Base} e altezza {Altezza}";
			}
		}

		protected override double CalculateArea() {
			return (Base * Altezza);
		}

		protected override double CalculatePerimeter() {
			return (Base+Altezza)*2;
		}
	}
}
