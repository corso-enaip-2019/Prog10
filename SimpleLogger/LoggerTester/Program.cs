using SimpleLogger;
using SimpleLogger.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerTester {
	class Program {
		static void Main(string[] args) {

			string FileName = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}{Path.DirectorySeparatorChar}mylog.txt";
			//ILogger logger = new Logger(LoggerType.Console, LoggerType.File);

			ILogger logger = new Logger();
			logger.AddTarget(new ConsoleTarget());
			logger.AddTarget(new FileTarget(FileName));

			try {
				throw new Exception("SONO UN ERRORE");
			}
			catch (Exception ex) {
				logger.LogError("Questo è un errore!", ex);
			}

			logger.LogInfo("Messaggio informativo");

			Console.ReadKey(true);
		}
	}
}
