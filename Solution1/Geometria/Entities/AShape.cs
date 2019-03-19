using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria.Entities {
	abstract class AShape: IShape {

		protected double _area = 0;
		public double Area {
			get {
				if (_area == 0) {
					_area = CalculateArea();
				}
				return _area;
			}
		}

		protected double _perimeter = 0;
		public double Perimeter {
			get {
				if (_perimeter == 0) {
					_perimeter = CalculatePerimeter();
				}
				return _perimeter;
			}
		}

		protected abstract double CalculatePerimeter();
		protected abstract double CalculateArea();
	}
}
