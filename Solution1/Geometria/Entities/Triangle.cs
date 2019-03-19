using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria.Entities {
	class Triangle : AShape {
				
		private enum TriangleType {
			Equilatero = 1,
			Isoscele = 2,
			Scaleno = 3,
		}

		int LatoA;
		int LatoB;
		int LatoC;
			   
		TriangleType TipoTriangolo {
			get {
				if (LatoA == LatoB && LatoB == LatoC) {
					return TriangleType.Equilatero;
				}
				else if (LatoA == LatoB || LatoB == LatoC || LatoA == LatoC) {
					return TriangleType.Isoscele;
				}
				else {
					return TriangleType.Scaleno;
				}
			}
		}

		public Triangle(int latoA, int latoB, int latoC) {
			LatoA = latoA;
			LatoB = latoB;
			LatoC = latoC;
		}

		protected override double CalculateArea() {
			double s = (LatoA + LatoB + LatoC) / 2D;
			return (Math.Sqrt(s * (s - LatoA) * (s - LatoB) * (s - LatoC)));
		}

		protected override double CalculatePerimeter() {
			return (LatoA + LatoB + LatoC);
		}

		public override string ToString() {
			return $"Triangolo {TipoTriangolo} di lati: {LatoA}, {LatoB}, {LatoC}";
		}
	}

}
