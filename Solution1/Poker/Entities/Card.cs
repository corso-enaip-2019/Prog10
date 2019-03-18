using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Entities {
	class Card: IComparable {
		static Dictionary<string, int> _signs = new Dictionary<string, int>() {
			{ "♥", 4 },
			{ "♦", 3 },
			{ "♣", 2 },
			{ "♠", 1 },
			{ "*", 0 },
		};

		static Dictionary<string, int> _numbers = new Dictionary<string, int>(){
			{ "2", 2 },
			{ "3", 3 },
			{ "4", 4 },
			{ "5", 5 },
			{ "6", 6 },
			{ "7", 7 },
			{ "8", 8 },
			{ "9", 9 },
			{ "10", 10 },
			{ "J", 11 },
			{ "Q", 12 },
			{ "K", 13 },
			{ "A", 14 },
			{ "*", 25 },
		};

		public string Numero { get; private set; }
		public string Segno { get; private set; }

		public int Value {
			get {
				int valNumero = 0;
				int valSegno = 0;

				_numbers.TryGetValue(Numero, out valNumero);
				_signs.TryGetValue(Segno, out valSegno);

				return valNumero + valSegno;
			}
		}

		public Card(int segno, int numero) {
			Numero = _numbers.Keys.ToArray()[numero];
			Segno = _signs.Keys.ToArray()[segno];
		}

		public override string ToString() {
			return $"{Numero}{Segno}";
		}

		public int CompareTo(object obj) {

			if (obj == null) return 1;
			if (obj.GetType() != typeof(Card)) return 1;

			Card other = obj as Card;
			//Il valore del'altra carta è più alto
			if (_numbers[other.Numero] > _numbers[this.Numero]) return -1;
			//Il mio valore è più alto
			if (_numbers[other.Numero] < _numbers[this.Numero]) return 1;
			
			//Il valore è lo stesso (guardo il segno)
			if (_signs[other.Segno] > _signs[this.Segno]) {
				return -1;
			}
			else if (_signs[other.Segno] < _signs[this.Segno]) {
				return 1;
			}
			else {
				//Le due carte sono identiche
				return 0;
			}
		}
	}
}
