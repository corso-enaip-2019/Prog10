using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brackets {
	class Program {

		/// <summary>
		/// Esercizio preso e semplificato da questo
		/// https://www.hackerrank.com/challenges/balanced-brackets/problem
		/// </summary>
		/// <param name="args"></param>

		static void Main(string[] args) {
			bool ok = CheckBrackets(@"
                namespace Brackets
                {
                    class Program
                    {
                        static void Main(string[] args)
                        {
                            bool ok = CheckBrackets("")
                            Console.ReadLine();}
                        }
                        static bool CheckBrackets(string text)
                        {
                        }
                    }
                }",
				out int errorLine,
				out int errorColumn);


			string strOk = ok ? "OK" : "KO";
			Console.WriteLine($"Text is { ok }");

			Console.ReadLine();
		}

		static Dictionary<char, char> _braketsType = new Dictionary<char, char>() {
			{ ')', '(' },
			{ ']', '[' },
			{ '}', '{' }
		};

		static char MatchingBracket(char c) {
			foreach (var item in _braketsType) {
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
		static bool CheckBrackets(string text, out int errorRow, out int errorColumn) {

			bool result = false;

			errorRow = -1;
			errorColumn = -1;
			try {
				Stack<char> openBrackets = new Stack<char>();

				int curCol = 1;
				int curLine = 1;
				foreach (char currentChar in text.ToCharArray()) {

					if (Environment.NewLine.Contains(currentChar)) {
						if (currentChar == '\n') {
							curLine++;
							curCol = 1;
						}
					}

					if (_braketsType.ContainsValue(currentChar)) {
						openBrackets.Push(currentChar);
					}
					else if (_braketsType.ContainsKey(currentChar)) {
						if (openBrackets.Count() == 0) {
							Console.WriteLine($"Il carattere {currentChar} nella posizone {curCol} della riga {curLine} non è corretto");
							errorColumn = curCol;
							errorRow = curLine;
							result = false;
							break;
						}
						//if (openBrackets.Peek() ==  MatchingBracket(currentChar)) {
						if (openBrackets.Peek() == _braketsType[currentChar]) {
							openBrackets.Pop();
						}
					}
					//else {
					//	///Non è un brackets
					//}
					curCol++;
				}

				result = openBrackets.Count() == 0;
			}
			catch (Exception) {
				result = false;
			}

			return result;
		}
	}
}
