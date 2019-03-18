using Poker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker {
	class Program {
		static void Main(string[] args) {
			Deck mazzo = new Deck();
			Console.WriteLine("Mazzo nuovo");
			Console.WriteLine(mazzo);
			System.Threading.Thread.Sleep(500);
			mazzo.Shuffle();
			Console.WriteLine("Mazzo mescolato");
			Console.WriteLine(mazzo);


			Console.ReadLine();
			Console.WriteLine("Pesco 5 carte");
			var mano1 = mazzo.PescaMano(5);
			Console.WriteLine(mano1);
			var mano2 = mazzo.PescaMano(5);
			Console.WriteLine(mano2);
			mano1.CompareTo(mano2);

			Console.WriteLine();

			Console.ReadLine();
		}
	}
}
