﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Esercizio1 {
	interface IFormaGeometrica {
		Dictionary<string, int> Sides { get; set; }
		bool IsValidFigure(Dictionary<string, int> Sides);
	}
}