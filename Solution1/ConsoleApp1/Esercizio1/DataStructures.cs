using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Esercizio1 {
	class DataStructures {
		/// <summary>
		/// FIFO
		/// </summary>
		public void Queue() {
			Queue<string> codaStringhe = new Queue<string>();
			codaStringhe.Enqueue("uno");
			string nextElement = codaStringhe.Peek();
			nextElement = codaStringhe.Dequeue();
		}

		/// <summary>
		/// LIFO
		/// </summary>
		public void Stack() {
			Stack<string> stackStringhe = new Stack<string>();
			stackStringhe.Push("uno");
			string nextElement = stackStringhe.Peek();
			nextElement = stackStringhe.Pop();
		}
	}
}
