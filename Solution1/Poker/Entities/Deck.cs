using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Entities {
	class Deck {
		List<Card> _carte { get; }
		Queue<Card> _mazzoGioco { get; set; }
		int _numeroCarte = 0;
		//bool _jollyPresent = false;

		public Deck() {
			_carte = new List<Card>();
			for (int s = 0; s < 4; s++) {
				for (int n = 0; n < 13; n++) {
					_carte.Add(new Card(s, n));
				}
			}
			_mazzoGioco = new Queue<Card>(_carte);
			UpdateNumeroCarte();
		}

		void UpdateNumeroCarte() {
			_numeroCarte = _mazzoGioco.Count();
		}

		//public void AddJolly(int quantity) {
		//	for (int i = 0; i < quantity; i++) {
		//		_carte.Add(new Card(4, 13));
		//	}
		//}

		public void Shuffle() {
			List<Card> inDeck = new List<Card>(_carte);
			_mazzoGioco = new Queue<Card>();

			Random r = new Random();
			int randomIndex = 0;
			while (inDeck.Count > 0) {
				randomIndex = r.Next(0, inDeck.Count); //Choose a random object in the list
				_mazzoGioco.Enqueue(inDeck[randomIndex]);
				inDeck.RemoveAt(randomIndex); //remove to avoid duplicates
			}
		}

		public Hand PescaMano(int nCarte) {
			Hand mano = new Hand(PescaCarte(nCarte));
			return mano;
		}

		private List<Card> PescaCarte(int nCarte) {
			List<Card> pescate = new List<Card>();
			for (int i = 0; i < nCarte; i++) {
				pescate.Add(_mazzoGioco.Dequeue());
			}

			UpdateNumeroCarte();
			return pescate;
		}

		public int VerifyHandValue(List<Card> mano) {
			

			var signGroups = mano.GroupBy(x => x.Segno);
			var numberGroups = mano.GroupBy(x => x.Numero);

			if (numberGroups.Count() == 5) {
				///Sono tutte di valori diversi
				
			}



			Dictionary<string, int> multipli = new Dictionary<string, int>();

			foreach (var carta in mano) {
				if (multipli.Keys.Contains(carta.Segno)) {
					multipli[carta.Segno]++;
				}
				else {
					multipli.Add(carta.Segno, 1);
				}
			}

			switch (multipli.Count) {
				case 5:
					///Sono tutte diverse
					///SCALA, COLORE, SCALA COLORE, SCALA REALE ?
					///

					break;
				case 4:
					///Ho una coppia, devo valutarla
					///

					break;
				case 3:
					///Ho un tris, devo valutarlo
					///

					break;
				case 2:
					///Ho un poker, devo valutarlo
					///

					break;
				case 1:
					///Sono tutte e cinque uguali????
					///Solo se ci sono i jolly nel mazzo
					
					break;
			}

			return 0;
		}

		public override string ToString() {
			string strOut = "";
			for (int i = 0; i < _mazzoGioco.Count; i++) {
				strOut += $" {_mazzoGioco.ToArray()[i]} ";
				if ((i+1)%13 == 0) {
					strOut += Environment.NewLine;
				}
			}
			return strOut;
		}
	}
}
