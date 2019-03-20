using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger.Entities {
	public class MockLogger : ILogger {
		public void LogError(string message, Exception ex) {
			//throw new NotImplementedException();
		}

		public void LogInfo(string message, Exception ex = null) {
			//throw new NotImplementedException();
		}
	}
}
