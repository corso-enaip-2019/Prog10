using System;

namespace SimpleLogger.Entities {
	internal class DBLogger : ILogger {
		public void LogError(string message, Exception ex) {
			throw new NotImplementedException();
		}

		public void LogInfo(string message, Exception ex = null) {
			throw new NotImplementedException();
		}
	}
}