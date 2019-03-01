using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Esercizio1 {
	class Triangolo {

		public void VerificaTriangolo() {
			Dictionary<string, int> lati = new Dictionary<string, int> {
				{ "A", -1 },
				{ "B", -1 },
				{ "C", -1 }
			};

			//Acquisisco il valore dei lati
			foreach (var lato in lati) {
				lati[lato.Key] = AskAndCheckLato(lato.Key);
			}

			//Verifico la somma
			bool sumOK = true; ;//= (a < b + c) && (b < a + c) && (c < a + b);
			foreach (var lato in lati) {
				if (sumOK) {
					sumOK = CheckSum(lato, lati);
				}
			}

			//Verifico la differenza
			bool diffOK = true;// = (a > Math.Abs(b - c)) && (b > Math.Abs(a - c)) && (c > Math.Abs(a - b));
			foreach (var lato in lati) {
				if (diffOK) {
					diffOK = CheckDiff(lato, lati);
				}
			}

			if (sumOK && diffOK) {
				Console.WriteLine("è un triangolo");
			}
			else {
				Console.WriteLine("non è un triangolo");
			}
		}

		private bool CheckDiff(KeyValuePair<string, int> lato, Dictionary<string, int> lati) {
			var latiExtra = lati.Where(x => x.Key != lato.Key);
			int diff = -1;
			foreach (var latoExtra in latiExtra) {
				diff += latoExtra.Value;
			}
			if (lato.Value > Math.Abs(diff)) {
				return true;
			}
			else {
				return false;
			}
		}

		private bool CheckSum(KeyValuePair<string, int> lato, Dictionary<string, int> lati) {
			var latiExtra = lati.Where(x => x.Key != lato.Key);
			int somma = -1;
			foreach (var latoExtra in latiExtra) {
				somma += latoExtra.Value;
			}
			if (lato.Value < somma) {
				return true;
			}
			else {
				return false;
			}
		}

		/// <summary>
		/// Chiede all'utente la dimensione del lato e lo converte in int
		/// </summary>
		/// <param name="nomeLato">Nome del lato da richiedere</param>
		/// <returns>Valore intero convertito dalla stringa dell'utente</returns>
		private int AskAndCheckLato(string nomeLato) {
			bool conversionOK = false;
			int valore = -1;

			while (valore < 0) {
				try {
					Console.Write("Inserisci lato " + nomeLato + ": ");
					conversionOK = int.TryParse(Console.ReadLine(), out valore);
					if (!conversionOK) {
						Console.WriteLine("Il valore inserito non è valido!");
					}
					if (valore < 0) {
						Console.WriteLine("Il valore deve essere positivo.");
					}
				}
				catch (Exception ex) {
					Console.WriteLine("Errore imprevisto!");
					valore = -1;
				}
			}
			return valore;
		}
	}
}
