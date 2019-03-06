using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaStudenti {
	class Classe {
		public int NumeroClasse { get; set; }
		public List<Studente> Studenti { get; set; }

		public Classe(int numero) {
			NumeroClasse = numero;
			Studenti = new List<Studente>();
		}
		
		public bool AddStudente(Studente studente) {

			Studenti.Add(studente);
			studente.ClasseAppartenenza = this;

			return true;
		}

		public Studente FindStudente(string nomeStudente) {
			return Studenti.Find(x => x.Nome == nomeStudente);			
		}

		public bool DeleteStudent(string nomeStudente) {
			Studente studente = FindStudente(nomeStudente);
			return Studenti.Remove(studente);
		}

		internal string PrintStudentList() {
			string testoStampa = "";

			testoStampa += $"--- Studenti della classe {NumeroClasse}: " + Environment.NewLine;
			foreach (var studente in Studenti) {
				testoStampa += studente;
				testoStampa += Environment.NewLine;
			}
			return testoStampa;
		}
	}
}
