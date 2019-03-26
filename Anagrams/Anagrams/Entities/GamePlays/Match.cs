using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagrams.Entities.GamePlays {
	class Match : IGamePlay {
		public string Description => "Match";
		IUIHandler _uiHandler = null;
		IRepository _wordRepository;

		public int Score { get; private set; }

		public void Run(IUIHandler handler, IRepository repo) {
			_uiHandler = handler;
			_wordRepository = repo;
			Run();
		}

		void Run() {
			bool continua = true;
			Score = 0;
			while (continua) {
				_uiHandler.WriteMessage("- MATCH GAME -");
				_uiHandler.WriteMessage("La parola da anagrammare è: ");
				string randomWord = _wordRepository.GetRandomWord();
				_uiHandler.WriteMessage(randomWord);
				_uiHandler.WriteMessage("Inserisci un anagramma:");
				///Start timer
				DateTime time = DateTime.Now;
				string answer =_uiHandler.AskForString();
				bool correctAnswer = _wordRepository.IsAnagram(randomWord, answer);
				///Stop timer
				var totalTime = DateTime.Now.Subtract(time);
				_uiHandler.WriteMessage($"Ci hai impiegato {totalTime.ToString(@"%s\.fff")} s");				
				if (correctAnswer) {
					_uiHandler.WriteMessage("Bravo! La tua risposta è valida.", ConsoleColor.Green);
				}
				else {
					_uiHandler.WriteMessage("Peccato! Risposta sbagliata.", ConsoleColor.Red);
					_uiHandler.WriteMessage("Alcuni possibili anagrammi sono:");
					foreach (var word in _wordRepository.CurrentAnagramPool) {
						_uiHandler.WriteMessage(word);
					}
				}
				int matchPoints = GetScore(totalTime, correctAnswer);
				_uiHandler.WriteMessage($"Hai guadagnato {matchPoints} pt.");
				_uiHandler.WriteMessage($"Per un totale di {Score+=matchPoints} pt.");

				_uiHandler.WriteMessage("Vuoi continuare? (s/n)");
				string continuare = _uiHandler.AskForString();
				continua = (continuare == "s");
			}
		}

		int GetScore(TimeSpan timeToAnswer, bool correctAnswer) {
			if (correctAnswer) {
				if (timeToAnswer.TotalSeconds < 5) return 10;
				if (timeToAnswer.TotalSeconds < 6) return 6;
				if (timeToAnswer.TotalSeconds < 7) return 4;
				if (timeToAnswer.TotalSeconds < 8) return 2;
				if (timeToAnswer.TotalSeconds < 9) return 1;
			}
			return 0;
		}
	}
}
