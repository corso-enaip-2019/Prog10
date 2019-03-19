using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria.Entities {
	interface IShape {
		double Area { get; }
		double Perimeter { get; }
	}
}
