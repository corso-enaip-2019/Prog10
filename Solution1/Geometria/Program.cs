using Geometria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria {
	class Program {
		static void Main(string[] args) {

			List<IShape> forme = new List<IShape>();

			Triangle tr1 = new Triangle(2, 2, 2);
			forme.Add(tr1);
			tr1 = new Triangle(2, 2, 3);
			forme.Add(tr1);
			tr1 = new Triangle(2, 3, 4);
			forme.Add(tr1);

			Circle cr1 = new Circle(4);
			forme.Add(cr1);

			Rectangle Rt1 = new Rectangle(3,4);
			forme.Add(Rt1);
			Rectangle Rt2 = new Rectangle(4, 4);
			forme.Add(Rt2);



			foreach (AShape frm in forme) {
				Console.WriteLine($"{frm}");
				Console.WriteLine($"Area: {String.Format("{0:F2}", frm.Area)}");

				string perDesc = frm is Circle? "Circonferenza": "Perimetro";

				Console.WriteLine($"{perDesc} {string.Format("{0:F2}",frm.Perimeter)}");
				
				Console.WriteLine();
			}

			Console.ReadLine();
		}
	}
}
