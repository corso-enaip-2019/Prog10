﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagrams.Entities.GamePlays {
	class Practice : IGamePlay {
		private IUIHandler _uiHandler;
		private IRepository _wordRepository;

		public string Description => "Practice";
		
		public void Run(IUIHandler handler, IRepository repo) {
			_uiHandler = handler;
			_wordRepository = repo;
			Run();
		}

		void Run() {
			bool continua = true;
			while (continua) {
				_uiHandler.ClearScreen();
				_uiHandler.WriteMessage("- PRACTICE GAME -", ConsoleColor.Yellow);
				_uiHandler.WriteMessage("Inserisci una parola di prova");
				string myWord = _uiHandler.AskForString();
				var anagrams = _wordRepository.GetAnagrams(myWord).Where(x => x != myWord);
				foreach (var anag in anagrams) {
					_uiHandler.WriteMessage(anag);
				}

				_uiHandler.WriteMessage("Vuoi continuare? (s/n)");
				string continuare =_uiHandler.AskForString();
				continua = (continuare == "s");
			}
		}
	}
}
