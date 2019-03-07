using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaStudenti {
	class Classroom {
		public int NumeroClasse { get; }
		private List<Student> ListaStudenti { get; }
		public School ScuolaAppartenenza { get; private set; }

		public int CountStudenti {
			get { return ListaStudenti.Count; }
		}

		public Classroom(int numero) {
			NumeroClasse = numero;
			ListaStudenti = new List<Student>();
		}
		
		public bool AddStudent(Student studente) {
			if (!ListaStudenti.Contains(studente)) {
				ListaStudenti.Add(studente);
				studente.AddToClass(this);

				return true;
			}
			return false;
		}

		public void AddToSchool(School scuola) {
			ScuolaAppartenenza = scuola;
		}

		public Student FindStudente(string nomeStudente) {
			return ListaStudenti.Find(x => x.Nome == nomeStudente);			
		}

		public bool DeleteStudent(string nomeStudente) {
			Student studente = FindStudente(nomeStudente);
			if (studente.RemoveFromClass(this)) {
				return ListaStudenti.Remove(studente);
			}
			return false;
		}

		internal string PrintStudentList() {
			string testoStampa = "";

			testoStampa += $"--- Studenti della classe {NumeroClasse}: " + Environment.NewLine;
			foreach (var studente in ListaStudenti) {
				testoStampa += studente;
				testoStampa += Environment.NewLine;
			}
			return testoStampa;
		}
	}
}
