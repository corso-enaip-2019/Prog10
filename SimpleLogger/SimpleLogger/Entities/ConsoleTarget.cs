using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger.Entities {
	public class ConsoleTarget : ILogTarget {

		public void WriteLog(LogEntry entry) {
			Console.WriteLine($"{entry.Date.ToString("o")} - {entry.Level} - {entry.Message}");
			if (entry.Error != null) {
				Console.WriteLine($"Messaggio: {entry.Error.Message}");
				Console.WriteLine($"Stack: {entry.Error.StackTrace}");
			}
		}
	}
}
