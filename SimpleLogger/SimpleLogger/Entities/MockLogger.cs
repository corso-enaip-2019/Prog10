using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger.Entities {
	public class MockLogger : ILogger {
		public bool AddTarget(ILogTarget writer) {
			//throw new NotImplementedException();
			return true;
		}

		public void LogError(string message, Exception ex) {
			//throw new NotImplementedException();
		}

		public void LogInfo(string message, Exception ex = null) {
			//throw new NotImplementedException();
		}

		public bool RemoveTarget(ILogTarget writer) {
			//throw new NotImplementedException();
			return true;
		}
	}
}
