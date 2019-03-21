using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger.Entities {
	public interface ILogger {

		void LogInfo(string message, Exception ex = null);

		void LogError(string message, Exception ex);

		bool AddTarget(ILogTarget writer);
		bool RemoveTarget(ILogTarget writer);
	}
}
