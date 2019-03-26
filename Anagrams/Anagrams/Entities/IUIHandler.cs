using System;

namespace Anagrams.Entities {
	public interface IUIHandler {
		string AskForString();
		void WriteMessage(string message);
		void WriteMessage(string message, ConsoleColor color);
		void Run();
	}
}