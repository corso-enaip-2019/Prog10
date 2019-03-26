﻿using System;
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

		public IGrouping<string, string> CurrentAnagramPool { get; private set; }		

		public abstract string Description { get; }
		
		public List<string> GetAnagrams(string word) {
			var myDic = LoadDictionary();
			return GetAnagrams(myDic, word);
		}

		private List<string> GetAnagrams(List<string> dictionary, string word) {
			return dictionary.Where(x => x.IsAnagram(word)).ToList();
		}

		IGrouping<string, string> GetRandomAnagramPool(List<string> dictionary) {
			var anagGroup = dictionary.GroupBy(x => String.Concat(x.OrderBy(c => c))).Where(g => g.Count() > 1);
			CurrentAnagramPool = anagGroup.ElementAt(new Random().Next(0, anagGroup.Count()));
			return CurrentAnagramPool;
		}

		string GetRandomWordFromPool(IGrouping<string, string> anagramPool) {
			return anagramPool.ElementAt(new Random().Next(0, anagramPool.Count()));
		}

		public string GetRandomWord() {
			return GetRandomWordFromPool(GetRandomAnagramPool(LoadDictionary()));
		}

		public bool IsAnagram(string word, string anagram) {
			return word.IsAnagram(anagram);
		}

		public abstract List<string> LoadDictionary();
	}
}
