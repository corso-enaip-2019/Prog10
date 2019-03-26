using Anagrams.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Anagrams {
	class ConsoleUI : IUIHandler {
		IRepository _wordRepository;

		public string AskForString() {
			return Console.ReadLine();
		}

		public void WriteMessage(string message) {
			WriteMessage(message, ConsoleColor.Gray);
		}

		public void WriteMessage(string message, ConsoleColor color) {
			Console.ForegroundColor = color;
			Console.WriteLine(message);
		}

		public void ClearScreen() {
			Console.Clear();
		}

		public void Run() {
			ConsoleKey option = ConsoleKey.NoName;

			List<IGamePlay> _gameModes = LoadAvailableGamePlays();

			while (option != ConsoleKey.Escape) {
				if (_wordRepository is null) {
					ManageSettings();
				}
				Console.Clear();
				ShowOptionsMenu(_gameModes);
				WriteMessage("Seleziona una modalità: ", ConsoleColor.White);
				option = Console.ReadKey(true).Key;

				switch (option) {
					default:
						if (option >= ConsoleKey.F1 && option <= ConsoleKey.F12) {
							int index = option - ConsoleKey.F1;
							if (index < _gameModes.Count && index >= 0) {
								IGamePlay game = _gameModes[index];
								game.Run(this, _wordRepository);
							}	
						}
						else {
							WriteMessage("L'opzione scelta non è valida o non disponibile.", ConsoleColor.Red );
						}
						break;
					case ConsoleKey.Escape:
						WriteMessage("Grazie per aver giocato.", ConsoleColor.White);
						break;
					case ConsoleKey.S:
						ManageSettings();
						break;
				}
			}
			Console.ReadKey(true);
		}

		private void ManageSettings(string initText = null) {
			Console.Clear();
			if (initText != null) {
				WriteMessage(initText);
			}
			WriteMessage("- IMPOSTAZIONI -");
			WriteMessage("Dizionari disponibili:");
			Dictionary<ConsoleKey, string> dics = new Dictionary<ConsoleKey, string>();
			ConsoleKey start = ConsoleKey.NumPad0;
			var repos = LoadAvailableRepos();
			foreach (var repo in repos) {
				WriteMessage($"{start++} - {repo.Description}");
			}

			var selectedDic = Console.ReadKey(true).Key;
			int index = selectedDic - ConsoleKey.NumPad0;
			if (index < repos.Count && index >= 0) { 			
				_wordRepository = repos[selectedDic - ConsoleKey.NumPad0];
				WriteMessage($"Hai selezionato: {_wordRepository.Description}");
			}
			else {
				ManageSettings("Il valore selezionato è errato");
			}
		}

		private void ShowOptionsMenu(List<IGamePlay> _gameModes) {
			if (_wordRepository != null) {
				WriteMessage($"Modalità corrente - {_wordRepository.Description}", ConsoleColor.White);
				WriteMessage("----", ConsoleColor.White);
			}
			WriteMessage("");
			Dictionary<ConsoleKey, string> _options = new Dictionary<ConsoleKey, string>();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("");
            Console.WriteLine("   /\\       /\\                                                     /\\      /\\");
            Console.WriteLine("   \\/      /  \\        /\\        |------------------|     /\\       \\/     /  \\");
            Console.WriteLine("           \\  /        \\/        |  Welcome to the  |    /  \\             \\  /");
            Console.WriteLine("            \\/     /\\            |   Anagram Game   |    \\  /              \\/");
            Console.WriteLine("                   \\/            |------------------|     \\/           /\\");
            Console.WriteLine("       /\\                                                              \\/");
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.WriteLine("                                                                                ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;

			_options.Add(ConsoleKey.Escape, "EXIT");
			_options.Add(ConsoleKey.S, "SETTINGS");

			foreach (var opt in _options) {
				WriteMessage($"{opt.Key} - {opt.Value}", ConsoleColor.Yellow);
			}

			WriteMessage("");
			WriteMessage("-- GAME MODE--", ConsoleColor.Red);
			ConsoleKey starting = ConsoleKey.F1;
			foreach (var game in _gameModes) {
				WriteMessage($"{starting++} - {game.Description}");
			}
			WriteMessage("");
		}

		#region Dynamic loading
		List<T> loadTypes<T>() {
			List<T> _types = new List<T>();

			Assembly me = Assembly.GetExecutingAssembly();
			var list = me.GetTypes().Where(t => t != typeof(T) && typeof(T).IsAssignableFrom(t))
				.ToList();
			foreach(var type in list) {
				if (!type.IsAbstract) {
					_types.Add((T)Activator.CreateInstance(type));
				}
			}
			return _types;
		}

		List<IRepository> LoadAvailableRepos() {
			return loadTypes<IRepository>();
		}

		List<IGamePlay> LoadAvailableGamePlays() {
			return loadTypes<IGamePlay>();
		}
		#endregion Dynamic loading
	}
}
