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
			WriteMessage(message, ConsoleColor.White);
		}

		public void WriteMessage(string message, ConsoleColor color) {
			Console.ForegroundColor = color;
			Console.WriteLine(message);
		}

		public void Run() {
			ConsoleKey option = ConsoleKey.NoName;

			List<IGamePlay> _gameModes = LoadAvailableGamePlays();

			while (option != ConsoleKey.Escape) {
				Console.Clear();
				ShowOptionsMenu(_gameModes);
				Console.WriteLine("Seleziona una modalità: ");
				option = Console.ReadKey(true).Key;

				switch (option) {
					default:
						if (option >= ConsoleKey.F1 && option <= ConsoleKey.F12) {
							if (_wordRepository is null) {
								ManageSettings();
							}
							int index = option - ConsoleKey.F1;
							if (index < _gameModes.Count && index >= 0) {
								IGamePlay game = _gameModes[index];
								game.Run(this, _wordRepository);
							}	
						}
						else {
							Console.WriteLine("L'opzione scelta non è valida o non disponibile.");
						}
						break;
					case ConsoleKey.Escape:
						Console.WriteLine("Grazie per aver giocato.");
						break;
					case ConsoleKey.S:
						ManageSettings();
						break;
				}

				Console.ReadKey(true);
			}
		}

		private void ManageSettings() {
			Console.WriteLine("Dizionari disponibili:");
			Dictionary<ConsoleKey, string> dics = new Dictionary<ConsoleKey, string>();
			ConsoleKey start = ConsoleKey.NumPad0;
			var repos = LoadAvailableRepos();
			foreach (var repo in repos) {
				Console.WriteLine($"{start++} - {repo.Description}");
			}

			var selectedDic = Console.ReadKey(true).Key;
			int index = selectedDic - ConsoleKey.NumPad0;
			if (index < repos.Count && index >= 0) { 			
				_wordRepository = repos[selectedDic - ConsoleKey.NumPad0];
				Console.WriteLine($"Hai selezionato: {_wordRepository.Description}");
			}
			else {
				Console.WriteLine("Il valore selezionato è errato");
				ManageSettings();
			}
		}

		private void ShowOptionsMenu(List<IGamePlay> _gameModes) {
			if (_wordRepository != null) {
				Console.WriteLine($"Modalità corrente - {_wordRepository.Description}");
			}

			Dictionary<ConsoleKey, string> _options = new Dictionary<ConsoleKey, string>();
			_options.Add(ConsoleKey.Escape, "EXIT");
			_options.Add(ConsoleKey.S, "SETTINGS");

			ConsoleKey starting = ConsoleKey.F1;
			foreach (var opt in _options) {
				Console.WriteLine($"{opt.Key} - {opt.Value}");
			}
			foreach (var game in _gameModes) {
				Console.WriteLine($"{starting++} - {game.Description}");
			}
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
