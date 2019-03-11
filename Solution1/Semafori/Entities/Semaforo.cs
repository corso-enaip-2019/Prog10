using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semafori.Entities {
	class Semaforo {
		public const string ROSSO = "ROSSO";
		public const string GIALLO = "GIALLO";
		public const string VERDE = "VERDE";

		public string NomeSemaforo { get; private set; }

		/// <summary>
		/// STATO DEL SEMAFORO
		/// </summary>
		public string CurrentColor { get; private set; }
		
		public Semaforo(string nomeSemaforo, string statoIniziale) {
			CurrentColor = statoIniziale;
			NomeSemaforo = nomeSemaforo;
		}

		public void BecomeGreen() {
			CurrentColor = VERDE;
			printStatus();
		}

		public void BecomeYellow() {
			CurrentColor = GIALLO;
			printStatus();
		}

		public void BecomeRed() {
			CurrentColor = ROSSO;
			printStatus();
		}

		void printStatus() {
			//Console.WriteLine($"{NomeSemaforo} : {CurrentColor}");
		}
	}
}
