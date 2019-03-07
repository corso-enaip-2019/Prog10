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

		static School scuola = new School();

		static void Main(string[] args) {

			bool esci = false;
			int countInsertErrors = 0;
			while (!esci) {
				Console.Clear();
				Console.WriteLine($"{INSERT} = inserisci; {STAMPA} = stampa; {FIND} = trova; {DELETE} = cancella; {EXIT} = esci; ");
				Console.Write("scelta: ");
				switch (Console.ReadLine()) {
					default:
						//non faccio nulla
						countInsertErrors++;
						string insulti = "";
						if (countInsertErrors > 10) {
							insulti = "Quando si dice analfabeta funzionale si parla di te vero?";
						}
						else if (countInsertErrors > 5) {
							insulti = "No, sul serio, le scelte sono davvero limitate...";
						}
						else if (countInsertErrors > 3) {
							insulti = "Eppure le scelte non sono molte...";
						} 
						Console.WriteLine(insulti);
						Console.ReadLine();
						break;
					case EXIT:
						esci = true;
						Environment.Exit(0);
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
			}
			
			Console.ReadLine();
		}

		private static void PrintClasses() {
			Console.WriteLine(scuola.PrintClasses());
			Console.ReadLine();
		}

		private static string GetNomeStudente() {
			Console.Write("Nome dello studente: ");
			return Console.ReadLine();
		}

		private static List<Classroom> FindStudent(string nomeStudente) {			
			List<Classroom> classi = new List<Classroom>();
			if (scuola.FindStudent(nomeStudente, out classi)) {
				return classi;
			}
			return null;
		}

		private static void FindStudent() {
			List<Classroom> classi = FindStudent(GetNomeStudente());
			PrintListClassiStudente(classi);
			Console.ReadLine();
		}

		private static void PrintListClassiStudente(List<Classroom> classi) {
			if (classi.Count == 1) {
				Console.WriteLine($"Studente trovato in {classi.First().NumeroClasse}");
			}
			else {
				foreach (var c in classi) {
					Console.WriteLine($"Studente trovato in {c.NumeroClasse}");
				}
			}
		}

		private static int GetClasseInteresse(string text) {
			Console.Write($"{text} ");
			if (int.TryParse(Console.ReadLine(), out int intClasse)) {
				if (intClasse > 0 && intClasse < 6) {
					return intClasse;
				}
				else {
					Console.WriteLine("Classe non valida, immettere un numero tra 1 e 5.");
					return GetClasseInteresse(text);
				}
			}
			else {
				Console.WriteLine("Numero non valido, immettere un numero tra 1 e 5.");
				return GetClasseInteresse(text);
			}
		}

		private static void DeleteStudent() {
			string nomeStudente = GetNomeStudente();
			List<Classroom> classi = FindStudent(nomeStudente);
			int classe = 0;
			if (classi.Count == 1) {
				classe = classi.First().NumeroClasse;
				classi.First().DeleteStudent(nomeStudente);
			}
			else {
				PrintListClassiStudente(classi);
				classe = GetClasseInteresse("Da quale classe lo vuoi cancellare?");
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
