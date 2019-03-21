using System;
using System.IO;

namespace SimpleLogger.Entities {
	public class FileTarget : ILogTarget {

		private string _fileName = null;

		public FileTarget(string fileName) {
			_fileName = fileName;
		}
		
		public void WriteLog(LogEntry entry) {
			string logText = $"{entry.Date.ToString("o")} - {entry.Level} - {entry.Message}{Environment.NewLine}";

			if (entry.Error != null) {
				logText += $"ex message: {entry.Error.Message}{Environment.NewLine}";
				logText += $"stack: {entry.Error.StackTrace}{Environment.NewLine}";
			}

			File.AppendAllText(_fileName, logText);
		}
	}
}