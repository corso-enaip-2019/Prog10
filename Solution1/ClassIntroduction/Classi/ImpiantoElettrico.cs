using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassIntroduction.Classi {
	class Switch {

		public void Click() {
			LightBulb philipsHue400w = new LightBulb(400, 1200);

			if (philipsHue400w.TurnedOn) {
				philipsHue400w.TurnOff();
			}
			else {
				philipsHue400w.TurnOn();
			}

			LightBulb ikeaBulb = new LightBulb(15, 600);
			LightBulb b = philipsHue400w;
			b.TurnOff();
		}
	}

	class LightBulb {
		//Property
		private int _consumption;

		public int Consumption {
			get { return _consumption; }
			set { _consumption = value; }
		}

		//int _lumen;
		//public int Lumen {
		//	get { return _lumen; }
		//	set { _lumen = value; }
		//}
		//public int Lumen { get; private set; }	
		
		//In questo caso Lumen può essere impostato solo nel costruttore
		public int Lumen { get; }
		
		//Stato
		bool _turnedOn;
		public bool TurnedOn {
			get { return _turnedOn; }
		}

		//Metodi
		public void TurnOn() {
			_turnedOn = true;
		}

		public void TurnOff() {
			_turnedOn = false;
		}

		//COSTRUTTORI
		//public LightBulb() {
		//	_consumption = 400;
		//	_lumen = 1000;
		//}
		public LightBulb(int consumption, int lumen) {
			_consumption = consumption;
			Lumen = lumen;
			_turnedOn = false;
		}
	}
}
