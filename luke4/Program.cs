using System;
using System.IO;
using System.Linq;

namespace luke4
{
	class Program
	{
		static void Main(string[] args)
		{
			var filename = @"ordliste.txt";
			using (var sr = new StreamReader(filename))
			{
				var count = 0;
				var palindromeCount = 0;
				while (!sr.EndOfStream)
				{
					var word = sr.ReadLine().Replace("-", "");

					if (IsPalindrome(word))
					{
						// Console.WriteLine(word);
						palindromeCount++;
						continue;
					}

					if(HasPalindromeAnagram(word))
					{
						count++;
						// Console.WriteLine(word);
					}
				}
				Console.WriteLine($"total: {count + palindromeCount}, palindromes: {palindromeCount}, palindrome anagrams: {count}");
			}

			Console.WriteLine("\nDone!");
		}

        private static bool HasPalindromeAnagram(string word)
        {
			return word.GroupBy(c => c)
				.OrderBy(g => g.Count())
				.Skip(1)
				.All(c => (c.Count() & 1) == 0);
        }

        private static bool IsPalindrome(string word)
		{
			if (word.First() == word.Last())
			{
				var numberOfLetters = word.Length - 2;
				return numberOfLetters > 0
					? IsPalindrome(word.Substring(1, numberOfLetters))
					: true;
			}

			return false;
		}
	}
}
