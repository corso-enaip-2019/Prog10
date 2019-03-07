using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaStudenti {
	class Student {
		public List<Classroom> ClassiFrequentate { get; }
		public string Nome { get; }

		public Student(string nome) {
			Nome = nome;
			ClassiFrequentate = new List<Classroom>();
		}

		public bool AddToClass(Classroom classeAppartenenza) {
			if (!ClassiFrequentate.Contains(classeAppartenenza)) {
				ClassiFrequentate.Add(classeAppartenenza);
				return true;
			}
			return false;
		}

		internal bool RemoveFromClass(Classroom classe) {
			if (ClassiFrequentate.Contains(classe)) {
				ClassiFrequentate.Remove(classe);
				return true;
			}
			return false;
		}

		public override string ToString() {
			return Nome;
		}
	}
}
