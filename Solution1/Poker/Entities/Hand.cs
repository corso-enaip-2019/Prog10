using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Entities {
	class Hand: IComparable {
		public List<Card> _carte;

		enum HandRank {
			HighCard = 1,
			Double = 2,
			DoubleDouble = 3,
			Tris = 4,
			Straight = 5, //scala
			Flush = 6, //colore
			Full = 7,
			Poker = 8,
			StraightFlush = 9, //scala colore
			RoyalFlush = 10, //scala reale
		}


		public Hand(List<Card> carteMano) {
			_carte = carteMano;
		}

		public int CompareTo(object obj) {

			if (obj == null) return 1;
			if (obj.GetType() != typeof(Hand)) return 1;

			Hand otherHand = obj as Hand;


			//valori.

			//var oValori = otherHand._carte.GroupBy(x => x.Numero);
			//var oSegni = otherHand._carte.GroupBy(x => x.Segno);



			throw new NotImplementedException();
		}

		public void EvaluateHand() {
			///Come si valutano le mani di poker?
			///https://it.wikipedia.org/wiki/Punti_del_poker
			///Tipo di punteggio	Superiorità ai seguenti punteggi
			///Carta alta - nessuno
			///Coppia - Carta alta
			///Doppia coppia - Carta alta, coppia
			///Tris - Carta alta, coppia, doppia coppia
			///Scala - Carta alta, coppia, doppia coppia, tris
			///Colore - Carta alta, coppia, doppia coppia, tris, scala
			///Full - Carta alta, coppia, doppia coppia, tris, scala, colore
			///Poker - Carta alta, coppia, doppia coppia, tris, scala, colore, full
			///Scala a colore - Carta alta, coppia, doppia coppia, tris, scala, colore, full, Poker
			///Scala reale - tutti
			///


			var valori = _carte.GroupBy(x => x.Numero);
			var segni = _carte.GroupBy(x => x.Segno);


		}

		public override string ToString() {
			string strOut = "";
			foreach (var c in _carte) {
				strOut += $"{c} ";
			}
			return strOut;
		}
	}
}
