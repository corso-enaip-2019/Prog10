﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Esercizio1.Entity;

namespace ConsoleApp1 {
	class Program {
        static void Main(string[] args) {

			Console.WriteLine(0.1D + 0.2D == 0.3D);

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
