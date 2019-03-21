using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger.Entities {
	public class Logger:ILogger {
		readonly List<ILogTarget> _writers = new List<ILogTarget>();

		public Logger() {

		}

		public void LogError(string message, Exception ex) {
			WriteLog(LogEntry.LogLevel.Error, message, ex);
		}

		public void LogInfo(string message, Exception ex = null) {
			WriteLog(LogEntry.LogLevel.Info, message, ex);
		}

		private void WriteLog(LogEntry.LogLevel level, string message, Exception ex = null) {
			foreach (var log in _writers) {
				log.WriteLog(new LogEntry(level) {Message = message, Error = ex });
			}
		}

		public bool AddTarget(ILogTarget writer) {
			_writers.Add(writer);
			return true;
		}

		public bool RemoveTarget(ILogTarget writer) {
			_writers.Remove(writer);
			return true;
		}
	}
}
