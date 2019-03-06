using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaStudenti {
	class Scuola {
		public string NomeScuola { get; set; }
		public List<Classe> Classi { get; set; }

		public Scuola() {
			Classi = new List<Classe>();
			for (int i = 1; i < 6; i++) {
				Classi.Add(new Classe(i));
			}
		}

		public Classe FindClasse(int classe) {
			return Classi.First(x => x.NumeroClasse == classe);			
		}

		public bool DeleteStudenteFromClasse(int classe, string nomeStudente) {
			Classe c = FindClasse(classe);
			return c.DeleteStudent(nomeStudente);
		}

		public string PrintClasses() {
			string testoStampa = "";
			foreach (var classe in Classi) {
				if (classe.Studenti.Count > 0) {
					testoStampa += classe.PrintStudentList();
					testoStampa += Environment.NewLine;
				}
			}
			return testoStampa;
		}

		internal bool AddStudent(string nome, string classe) {
			Studente s = new Studente(nome);
			int iClasse = 0;
			if (int.TryParse(classe, out iClasse)) {
				return FindClasse(iClasse).AddStudente(s);
			}
			return false;
		}

		internal bool FindStudent(string nomeStudente, out List<Classe> classi) {
			classi = new List<Classe>();
			foreach (Classe c in Classi) {
				Studente s = c.FindStudente(nomeStudente);
				if (s != null) {
					classi.Add(c);
				}
			}

			return true;
		}
	}
}
