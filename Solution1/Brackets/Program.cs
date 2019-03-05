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
		
		/// <summary>
		/// Verifica se il testo passato contiente un numero coerente di parentesi di apertura e chiusura "(", "[", "{"
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		static bool CheckBrackets(string text) {
			try {

				List<char> validChars = new List<char>() { '(', ')', '[', ']', '{', '}' };

				/////Controllo parità
				//if (text.Length % 2 != 0) {
				//	return false;
				//}

				Stack<char> openBrackets = new Stack<char>();

				foreach (char c in text.ToCharArray()) {
					if (c == '(' || c == '[' || c == '{') {
						openBrackets.Push(c);
					}
					else if (c == ')' || c == ']' || c == '}') {
						char lastChar = openBrackets.Peek();
						if (c == ')' && lastChar == '(') {
							openBrackets.Pop();
						}
						else if (c == ']' && lastChar == '[') {
							openBrackets.Pop();
						}
						else if (c == '}' && lastChar == '{') {
							openBrackets.Pop();
						}
						else {
							return false;
						}
					}
					else {
						///Il carattere non è un brackets
						//return false;
					}
				}

				if (openBrackets.Count() == 0) {
					return true;
				}
			}
			catch (Exception) {

				return false;
				//throw;
			}

			return false;
		}		
	}
}
