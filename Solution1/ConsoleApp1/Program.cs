using ConsoleApp1.Esercizio1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1 {
	class Program {
		static void Main(string[] args) {

			//bool continua = true;

			//while (continua) {

			bool triangoloValido = false;
			Triangolo triangolo = new Triangolo();
			triangoloValido = triangolo.IsValidFigure(triangolo.Sides);
			if (triangoloValido) {
				Console.WriteLine("è un triangolo");
			}
			else {
				Console.WriteLine("non è un triangolo");
				triangolo.ProposeValidFigure();
			}


			//Console.WriteLine("Vuoi continuare? y/n");
			//continua = bool.TryParse(Console.ReadLine()
			//}

			Console.ReadLine();
		}
	}
}
