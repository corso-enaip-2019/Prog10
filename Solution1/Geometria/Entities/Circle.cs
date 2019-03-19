using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria.Entities {
	class Circle : AShape {

		int Raggio;

		public double Circonferenza {
			get {
				return CalculatePerimeter();
			}
		}

		public Circle(int raggio) {
			Raggio = raggio;
		}

		protected override double CalculateArea() {
			return Math.PI * (Raggio ^2);
		}

		protected override double CalculatePerimeter() {
			return 2 * Raggio * Math.PI;
		}		

		public override string ToString() {
			return $"Cerchio di raggio {Raggio}";
		}
	}
}
