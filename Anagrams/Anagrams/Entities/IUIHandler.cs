using System;

namespace Anagrams.Entities {
	public interface IUIHandler {
		string AskForString();
		ConsoleKey AskForKey();
		void WriteMessage(string message);
		void WriteMessage(string message, ConsoleColor color);
		void Run();
		void ClearScreen();
	}
}