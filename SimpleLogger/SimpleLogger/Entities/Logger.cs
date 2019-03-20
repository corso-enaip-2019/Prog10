using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger.Entities {
	public class Logger:ILogger {
		readonly List<ILogger> _loggers = new List<ILogger>();

		public Logger(params LoggerType[] types) {
			foreach(var type in types) {
				switch (type) {
					case LoggerType.Console:
						_loggers.Add(new ConsoleLogger());
						break;
					case LoggerType.File:
						_loggers.Add(new FileLogger());
						break;
					case LoggerType.DB:
						_loggers.Add(new DBLogger());
						break;
				}
			}
		}

		public void LogError(string message, Exception ex) {
			foreach(var log in _loggers) {
				log.LogError(message, ex);
			}
		}

		public void LogInfo(string message, Exception ex = null) {
			foreach (var log in _loggers) {
				log.LogInfo(message, ex);
			}
		}
	}
}
