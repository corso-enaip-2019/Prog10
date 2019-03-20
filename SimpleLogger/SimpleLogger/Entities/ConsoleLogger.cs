using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger.Entities {
	internal class ConsoleLogger : ILogger {
		public void LogError(string message, Exception ex) {
			Console.WriteLine($"{DateTime.Now.ToString("o")} - ERRORE - {message}");
			Console.WriteLine($"Messaggio: {ex.Message}");
			Console.WriteLine($"Stack: {ex.StackTrace}");
		}

		public void LogInfo(string message, Exception ex = null) {
			Console.WriteLine($"{DateTime.Now.ToString("o")} - INFO - {message}");
		}
	}
}
