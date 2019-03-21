using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger.Entities {

	public class LogEntry {
		public enum LogLevel {
			Debug,
			Info,
			Warn,
			Error,
			Fatal,
		}

		public string Message { get; set; }
		public DateTime Date { get; }
		public Exception Error { get; set; }
		public LogLevel Level { get; }

		public LogEntry(LogLevel level) {
			Date = DateTime.Now;
			Level = level;
		}
	}
}
