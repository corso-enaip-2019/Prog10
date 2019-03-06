using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaStudenti {
	class Studente {
		public Classe ClasseAppartenenza { get; set; }
		public string Nome { get; set; }

		public Studente(string nome) {
			this.Nome = nome;
		}

		public override string ToString() {
			return this.Nome;
		}
	}
}
