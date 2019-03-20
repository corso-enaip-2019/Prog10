using SimpleLogger;
using SimpleLogger.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerTester {
	class Program {
		static void Main(string[] args) {


			ILogger logger = new Logger(LoggerType.Console);

			logger.LogInfo("Messaggio informativo");

			logger.LogError("Questo è un errore!", new Exception("Error"));


			Console.ReadKey(true);
		}
	}
}
