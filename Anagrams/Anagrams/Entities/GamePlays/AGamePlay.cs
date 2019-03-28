using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagrams.Entities.GamePlays {
	abstract class AGamePlay : IGamePlay {
		protected IUIHandler _uiHandler;
		protected IRepository _wordRepository;

		public abstract string Description { get; }

		public abstract void Run(IUIHandler handler, IRepository repo);

		protected bool Continue() {
			_uiHandler.WriteMessage("Vuoi continuare? (s/n)");
			var continuare = _uiHandler.AskForKey();
			switch (continuare) {
				default:
					_uiHandler.WriteMessage("Scelta non valida", ConsoleColor.Red);
					return Continue();
				case ConsoleKey.S:
					return true;
				case ConsoleKey.N:
					return false;
			}
		}
	}
}
