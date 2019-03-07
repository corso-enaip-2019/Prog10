using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaStudenti {
	class School {
		public string NomeScuola { get; set; }
		public List<Classroom> ClassiDisponibili { get; set; }

		public School() {
			ClassiDisponibili = new List<Classroom>();
			for (int i = 1; i < 6; i++) {
				Classroom c = new Classroom(i);
				ClassiDisponibili.Add(c);
				c.AddToSchool(this);
			}
		}

		private Classroom NuovaClasse(int classe) {
			Classroom myClass = new Classroom(classe);
			ClassiDisponibili.Add(myClass);
			myClass.AddToSchool(this);
			return myClass;
		}

		public Classroom FindClasse(int classe) {
			Classroom myClass = ClassiDisponibili.FirstOrDefault(x => x.NumeroClasse == classe);
			if (myClass == null) {
				myClass = NuovaClasse(classe);
			}
			return myClass;
		}

		public bool DeleteStudenteFromClasse(int classe, string nomeStudente) {
			Classroom c = FindClasse(classe);
			return c.DeleteStudent(nomeStudente);
		}

		public string PrintClasses() {
			string testoStampa = "";
			foreach (var classe in ClassiDisponibili) {
				if (classe.CountStudenti > 0) {
					testoStampa += classe.PrintStudentList();
					testoStampa += Environment.NewLine;
				}
			}
			return testoStampa;
		}

		internal bool AddStudent(string nome, string classe) {
			Student s = new Student(nome);
			if (int.TryParse(classe, out int iClasse)) {
				return FindClasse(iClasse).AddStudent(s);
			}
			return false;
		}

		internal bool FindStudent(string nomeStudente, out List<Classroom> classi) {

			classi = new List<Classroom>();
			//classi = ClassiDisponibili.FindAll(x => x.FindStudente(nomeStudente).Nome == nomeStudente);

			foreach (Classroom c in ClassiDisponibili) {
				Student s = c.FindStudente(nomeStudente);
				if (s != null) {
					classi.Add(c);
				}
			}

			return true;
		}
	}
}
