using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaStudenti {
	class Program {

		const string EXIT = "e";
		const string STAMPA = "s";
		const string INSERT = "i";
		const string DELETE = "d";
		const string FIND = "t";


		static Scuola scuola = new Scuola();

		static void Main(string[] args) {

			bool esci = false;

			while (!esci) {
				Console.WriteLine($"{EXIT} = esci; {STAMPA} = stampa; {INSERT} = inserisci; {DELETE} = cancella; {FIND} = trova");
				Console.Write("scelta: ");
				switch (Console.ReadLine()) {
					default:
						//non faccio nulla
						break;
					case EXIT:
						esci = true;
						break;
					case STAMPA:
						PrintClasses();
						break;
					case INSERT:
						AddStudent();
						break;
					case DELETE:
						DeleteStudent();
						break;
					case FIND:
						FindStudent();
						break;
				}

				Console.Clear();
			}
			
			Console.ReadLine();
		}

		private static void PrintClasses() {
			Console.WriteLine(scuola.PrintClasses());
			Console.ReadLine();
		}

		private static string getNomeStudente() {
			Console.Write("Nome dello studente: ");
			return Console.ReadLine();
		}

		private static List<Classe> findStudent(string nomeStudente) {			
			List<Classe> classi = new List<Classe>();
			if (scuola.FindStudent(nomeStudente, out classi)) {
				return classi;
			}
			return null;
		}

		private static void FindStudent() {
			List<Classe> classi = findStudent(getNomeStudente());
			printListClassiStudente(classi);
			Console.ReadLine();
		}

		private static void printListClassiStudente(List<Classe> classi) {
			if (classi.Count == 1) {
				Console.WriteLine($"Studente trovato in {classi.First().NumeroClasse}");
			}
			else {
				foreach (var c in classi) {
					Console.WriteLine($"Studente trovato in {c.NumeroClasse}");
				}
			}
		}

		private static int getClasseInteresse(string text) {
			Console.Write($"{text} ");
			int intClasse = 0;
			if (int.TryParse(Console.ReadLine(), out intClasse)) {
				if (intClasse > 0 && intClasse < 6) {
					return intClasse;
				}
				else {
					Console.WriteLine("Classe non valida, immettere un numero tra 1 e 5.");
					return getClasseInteresse(text);
				}
			}
			else {
				Console.WriteLine("Numero non valido, immettere un numero tra 1 e 5.");
				return getClasseInteresse(text);
			}
		}

		private static void DeleteStudent() {
			string nomeStudente = getNomeStudente();
			List<Classe> classi = findStudent(nomeStudente);
			int classe = 0;
			if (classi.Count == 1) {
				classe = classi.First().NumeroClasse;
				classi.First().DeleteStudent(nomeStudente);
			}
			else {
				printListClassiStudente(classi);
				classe = getClasseInteresse("Da quale classe lo vuoi cancellare?");
				scuola.DeleteStudenteFromClasse(classe, nomeStudente);
			}
			Console.WriteLine($"Studente {nomeStudente} eliminato dalla classe {classe}");
			Console.ReadLine();
		}

		static private void AddStudent() {
			Console.Write("Nome studente: ");
			string nome = Console.ReadLine();
			Console.Write("Classe di frequentazione: ");
			string classe = Console.ReadLine();

			if (scuola.AddStudent(nome, classe)) {
				Console.Write("Studente aggiunto con successo");
			}
			Console.ReadLine();
		}
	}
}
