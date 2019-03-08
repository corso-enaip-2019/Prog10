using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semafori.Entities {
	class Strada {
		public string NomeStrada { get; private set; }
		List<Semaforo> Semafori = new List<Semaforo>();

		/// <summary>
		/// TODO:
		/// Chiedere a tutti i semafori il loro stato attuale e segnalare possibile discrepanza
		/// </summary>
		public string StreetStatus { get; private set; }

		//string status {
		//	get {
		//		string strOut = null;

		//		foreach (var sem in Semafori) {
		//			if(strOut != sem.CurrentColor) {
		//				///Cos'è successo? manca sync
		//			}
		//			strOut = sem.CurrentColor;
		//		}

		//		return strOut;
		//	}
		//}

		public Strada(string nomeStrada, string statoSemafori) {
			NomeStrada = nomeStrada;
			Semafori.Add(new Semaforo("1", statoSemafori));
			Semafori.Add(new Semaforo("2", statoSemafori));
			StreetStatus = statoSemafori;
		}

		private void printNomeStrada() {
			Console.WriteLine($"Strada {NomeStrada}");
		}

		public bool BecomeRed() {
			printNomeStrada();
			foreach (var semaforo in Semafori) {
				semaforo.BecomeYellow();
				StreetStatus = Semaforo.GIALLO;
			}
			foreach (var semaforo in Semafori) {
				semaforo.BecomeRed();
				StreetStatus = Semaforo.ROSSO;
			}
			
			///TODO: gestire eccezioni AIUTO!!!!
			return true;
		}

		public bool BecomeGreen() {
			printNomeStrada();
			foreach (var semaforo in Semafori) {
				semaforo.BecomeYellow();
				StreetStatus = Semaforo.GIALLO;
			}
			foreach (var semaforo in Semafori) {
				semaforo.BecomeGreen();
				StreetStatus = Semaforo.VERDE;
			}
			
			///TODO: gestire eccezioni AIUTO!!!!
			return true;
		}

		//public string PrintStreetStatus() {
		//	string strOut = "";
		//	foreach (var sem in Semafori) {
		//		strOut += $" - sem.{sem.NomeSemaforo} {sem.CurrentColor}{Environment.NewLine}";
		//	}
		//	return strOut;
		//}
	}
}
