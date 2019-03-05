using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Esercizio1.Entity {
	class Triangolo : AFormaGeometrica {

		public Triangolo() {
			Sides = new List<Lato>();
			Sides.Add(new Lato ("A"));
			Sides.Add(new Lato ("B"));
			Sides.Add(new Lato ("C"));
						
			//Acquisisco il valore dei lati
			foreach (var lato in Sides) {
				lato.Size = AskAndCheckLato(lato.IDLato);
			}
		}

		public bool ProposeValidFigure() {
			bool triangoloValido = false;
			List<Lato> latiTest = new List<Lato>(Sides);
			
			int iTentativo = 1;
			for (int i = 1; i <= 10; i++) {
				foreach (var lato in latiTest) {
					int orgLato = lato.Size;
					///Incremento
					lato.Size = lato.Size + i;
					triangoloValido = IsValidFigure(latiTest);
					Console.WriteLine("Tentativo " + (iTentativo));
					if (triangoloValido) {
						///Esco
						Console.WriteLine("Un triangolo valido simile al tuo potrebbe essere: ");
						WriteLati(latiTest);
						return true;
					}
					else {
						///Ripristino il valore iniziale
						//Console.WriteLine("Tentativo fallito: ");
						//WriteLati(latiTest);
						lato.Size = orgLato;						
						iTentativo++;
					}
				}
			}
			return false;
		}

		private void WriteLati(List<Lato> Lati) {
			foreach (var Lato in Lati) {
				Console.WriteLine(string.Format("{0}: {1}", Lato.IDLato, Lato.Size));
			}
		}

		public override bool IsValidFigure(List<Lato> Sides) {		

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

		private bool CheckDiff(Lato lato, List<Lato> lati) {
			var latiExtra = lati.Where(x => x.IDLato != lato.IDLato);
			int diff = 0;
			foreach (var latoExtra in latiExtra) {
				diff = latoExtra.Size - diff;				
			}
			if (lato.Size > Math.Abs(diff)) {
				return true;
			}
			else {
				return false;
			}
		}

		private bool CheckSum(Lato lato, List<Lato> lati) {
			var latiExtra = lati.Where(x => x.IDLato != lato.IDLato);
			int somma = 0;
			foreach (var latoExtra in latiExtra) {
				somma += latoExtra.Size;
			}
			if (lato.Size < somma) {
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
