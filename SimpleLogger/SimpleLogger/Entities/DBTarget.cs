using System;

namespace SimpleLogger.Entities {
	public class DBTarget : ILogTarget {

		public void WriteLog(LogEntry entry) {
			throw new NotImplementedException();
		}
	}
}