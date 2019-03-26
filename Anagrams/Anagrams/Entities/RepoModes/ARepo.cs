using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagrams.Entities.RepoModes {
	static class AnagramExt {
		public static bool IsAnagram(this string word, string anagram) {
			if (word.Length != anagram.Length) {
				return false;
			}

			if (String.Concat(word.ToLower().OrderBy(c => c)) == String.Concat(anagram.ToLower().OrderBy(c => c))) {
				return true;
			}

			return false;
		}
	}

	abstract class ARepo: IRepository {

		List<string> _dictionary;
		protected List<string> Dictionary {
			get {
				if (_dictionary == null) {
					_dictionary = LoadDictionary();
				}
				return _dictionary;
			}
		}

		IGrouping<string, string> _currentAnagramPool;
		IEnumerable<IGrouping<string, string>> _anagramPools;
		IEnumerable<IGrouping<string, string>> AnagramPools {
			get {
				if (_anagramPools == null) {
					_anagramPools = Dictionary.GroupBy(x => String.Concat(x.OrderBy(c => c))).Where(g => g.Count() > 1);
				}
				return _anagramPools;
			}
		}

		public abstract string Description { get; }
		
		public List<string> GetAnagrams(string word) {
			return Dictionary.Where(x => x.IsAnagram(word)).Where(w => w != word).ToList();
		}

		IGrouping<string, string> GetRandomAnagramPool() {
			_currentAnagramPool = AnagramPools.ElementAt(new Random().Next(0, AnagramPools.Count()));
			return _currentAnagramPool;
		}

		string GetRandomWordFromPool(IGrouping<string, string> anagramPool) {
			return anagramPool.ElementAt(new Random().Next(0, anagramPool.Count()));
		}

		public string GetRandomWord() {
			return GetRandomWordFromPool(GetRandomAnagramPool());
		}

		bool IsValidWord(string word) {
			return Dictionary.Contains(word);
		}

		public bool IsAnagram(string word, string anagram) {
			if (IsValidWord(anagram))
				return word.IsAnagram(anagram);

			return false;
		}

		public abstract List<string> LoadDictionary();
	}
}
