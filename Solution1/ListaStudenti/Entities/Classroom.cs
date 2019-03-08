using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaStudenti {
	class Classroom {
		public int NumeroClasse { get; }
		private List<Student> _listaStudenti = new List<Student>();
		public School ScuolaAppartenenza { get; private set; }

		public int CountStudenti {
			get { return _listaStudenti.Count; }
		}

		public Classroom(int numero) {
			NumeroClasse = numero;
		}
		
		public bool AddStudent(Student studente) {
			if (!_listaStudenti.Contains(studente)) {
				_listaStudenti.Add(studente);
				studente.RegisterToClass(this);

				return true;
			}
			return false;
		}

		public void AddToSchool(School scuola) {
			ScuolaAppartenenza = scuola;
		}

		public Student FindStudente(string nomeStudente) {
			return _listaStudenti.Find(x => x.Nome == nomeStudente);			
		}

		public bool RemoveStudent(string nomeStudente) {
			Student studente = FindStudente(nomeStudente);
			if (studente.LeaveClass(this)) {
				return _listaStudenti.Remove(studente);
			}
			return false;
		}

		internal string PrintStudentList() {
			string testoStampa = "";

			testoStampa += $"--- Studenti della classe {NumeroClasse}: " + Environment.NewLine;
			foreach (var studente in _listaStudenti) {
				testoStampa += studente;
				testoStampa += Environment.NewLine;
			}
			return testoStampa;
		}
	}
}
