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

				Switch(stradaA, stradaB);

			}
			else if (stradaA.StreetStatus == Semaforo.ROSSO && stradaB.StreetStatus == Semaforo.VERDE) {

				Switch(stradaB, stradaA);
				
			}
		}

		private void Switch(Strada setRed, Strada setGreen) {
			if (setRed.SetYellow()) {
				PrintCurrentStatus();

				if (setRed.SetRed()) {
					PrintCurrentStatus();

					if (setGreen.SetYellow()) {
						PrintCurrentStatus();

						setGreen.SetGreen();
						PrintCurrentStatus();
						System.Threading.Thread.Sleep(1000);
					}
				}
			}
		}

		private void PrintCurrentStatus() {
			foreach (var strada in _strade) {
				Console.Write($"{strada}    ");
			}
			Console.WriteLine();
			System.Threading.Thread.Sleep(500);
		}
	}
}
