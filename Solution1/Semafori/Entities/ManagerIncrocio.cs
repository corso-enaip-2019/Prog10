using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semafori.Entities {
	class ManagerIncrocio {

		Strada[] _strade = new Strada[2];

		public ManagerIncrocio() {
			_strade[0] = new Strada("A", Semaforo.VERDE);
			_strade[1] = new Strada("B", Semaforo.ROSSO);
		}

		///Sincronizzazione
		public void SwitchTraffic() {
			Strada stradaA = _strade[0];
			Strada stradaB = _strade[1];

			if (stradaA.StreetStatus == Semaforo.VERDE && stradaB.StreetStatus == Semaforo.ROSSO) {
				if (stradaA.BecomeRed()) {
					stradaB.BecomeGreen();
				}
			}
			else if (stradaA.StreetStatus == Semaforo.ROSSO && stradaB.StreetStatus == Semaforo.VERDE) {
				if (stradaB.BecomeRed()) {
					stradaA.BecomeGreen();
				}
			} 
		}

		//public string PrintStatusIncrocio() {
		//	string statoIncrocio = "";
		//	foreach (var strada in _strade) {
		//		statoIncrocio += $"Strada {strada.NomeStrada}{Environment.NewLine}{strada.PrintStreetStatus()}";				
		//	}
		//	return statoIncrocio;
		//}

	}
}
