using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Esercizio1 {
	class Triangolo : AFormaGeometrica {

		public Triangolo() {
			Sides = new Dictionary<string, int> {
				{ "A", 0 },
				{ "B", 0 },
				{ "C", 0 }
			};

			var keys = Sides.Keys.ToList();
			//Acquisisco il valore dei lati
			foreach (var lato in keys) {
				Sides[lato] = AskAndCheckLato(lato);
			}
		}

		public bool ProposeValidFigure() {
			bool triangoloValido = false;			
			Dictionary<string, int> latiTest = new Dictionary<string, int>(Sides);
			var keys = Sides.Keys.ToList();

			int iTentativo = 1;
			for (int i = 1; i <= 10; i++) {
				foreach (var lato in keys) {
					///Incremento
					latiTest[lato] = latiTest[lato] + i;
					triangoloValido = IsValidFigure(latiTest);
					Console.WriteLine("Tentativo " + (iTentativo));
					if (triangoloValido) {
						///Esco
						Console.WriteLine("Un triangolo valido simile al tuo potrebbe essere: ");
						WriteLati(latiTest);
						return true;
					}
					else {
						/////Ripristino il valore iniziale
						//Console.WriteLine("Tentativo fallito: ");
						//WriteLati(latiTest);
						latiTest[lato] = Sides[lato];
						iTentativo++;
					}
				}
			}
			return false;
		}

		private void WriteLati(Dictionary<string, int> Lati) {
			foreach (var Lato in Lati) {
				Console.WriteLine(string.Format("{0}: {1}", Lato.Key, Lato.Value));
			}
		}

		public override bool IsValidFigure(Dictionary<string, int> Sides) {		

			//Verifico le somme
			bool sumOK = true; ;//= (a < b + c) && (b < a + c) && (c < a + b);
			foreach (var lato in Sides) {
				if (sumOK) {
					sumOK = CheckSum(lato, Sides);
				}
			}

			//Verifico le differenze
			bool diffOK = true;// = (a > Math.Abs(b - c)) && (b > Math.Abs(a - c)) && (c > Math.Abs(a - b));
			foreach (var lato in Sides) {
				if (diffOK) {
					diffOK = CheckDiff(lato, Sides);
				}
			}

			//if (sumOK && diffOK) {
			//	return true;
			//}
			//else {
			//	return false;
			//}
			return sumOK && diffOK;
		}

		private bool CheckDiff(KeyValuePair<string, int> lato, Dictionary<string, int> lati) {
			var latiExtra = lati.Where(x => x.Key != lato.Key);
			int diff = 0;
			foreach (var latoExtra in latiExtra) {
				diff = latoExtra.Value - diff;				
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
			int somma = 0;
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
					Console.Write(string.Format("{0} {1} {2} ", "Inserisci lato", nomeLato, ":"));
					conversionOK = int.TryParse(Console.ReadLine(), out valore);
					if (!conversionOK) {
						Console.WriteLine("Il valore inserito non è valido!");
					}
					if (valore < 0) {
						Console.WriteLine("Il valore deve essere positivo.");
					}
				}
				catch /*(Exception ex)*/ {
					Console.WriteLine("Errore imprevisto!");
					valore = -1;
				}
			}
			return valore;
		}
	}
}
