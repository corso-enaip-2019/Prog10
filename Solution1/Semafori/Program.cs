using Semafori.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semafori {
	class Program {


		static void Main(string[] args) {
			ManagerIncrocio manager = new ManagerIncrocio();
			//Console.WriteLine(manager.PrintStatusIncrocio());

			for (int i = 0; i < 10; i++) {

				manager.SwitchTraffic();
				//System.Threading.Thread.Sleep(500);
				//Console.WriteLine();
			}

						
			Console.ReadKey();
		}




	}
}
