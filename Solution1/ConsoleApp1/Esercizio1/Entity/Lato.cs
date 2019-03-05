using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Esercizio1.Entity {
	class Lato {
		/// <summary>
		/// Nome identificativo del lato
		/// </summary>
		public string IDLato { get; set; }
		/// <summary>
		/// Dimensione del lato
		/// </summary>
		public int Size { get; set; }

		public Lato(string idLato) {
			this.IDLato = idLato;
			this.Size = 0;
		}
	}
}
