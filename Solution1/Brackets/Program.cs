using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brackets {
	class Program {
		static void Main(string[] args) {
			bool ok = CheckBrackets(@"
                namespace Brackets
                {
                    class Program
                    {
                        static void Main(string[] args)
                        {
                            bool ok = CheckBrackets("")
                            Console.ReadLine();
                        }
                        static bool CheckBrackets(string text)
                        {
                        }
                    }
                }");

			string strOk = ok ? "OK" : "KO";
			Console.WriteLine($"Text is { ok }");

			Console.ReadLine();
		}

		static Dictionary<char, char> brakets = new Dictionary<char, char>() {
			{'(', ')' },
			{'[', ']' },
			{'{', '}' }
		};

		static char MatchingBracket(char c) {
			foreach(var item in brakets) {
				if (item.Value == c) {
					return item.Key;
				}
			}
			return c;
		}

		/// <summary>
		/// Verifica se il testo passato contiente un numero coerente di parentesi di apertura e chiusura "(", "[", "{"
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		static bool CheckBrackets(string text) {
			try {
				Stack<char> openBrackets = new Stack<char>();

				foreach (char c in text.ToCharArray()) {

					if (brakets.ContainsKey(c)) {
						openBrackets.Push(c);
					}
					else if (brakets.ContainsValue(c) 
						&& openBrackets.Peek() == MatchingBracket(c)) {
						openBrackets.Pop();
					}
					//else {
					//	///Non è un brackets
					//}
				}

				return openBrackets.Count() == 0;
			}
			catch (Exception) {
				return false;
			}
		}		
	}
}
