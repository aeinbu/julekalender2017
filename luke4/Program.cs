using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace luke4
{
    class Program
    {
        static void Main(string[] args)
        {
            var filename = @"ordliste.txt";
            using (var sr = new StreamReader(filename))
            {
                var totalCount = 0;
                var palindromeAnagramCount = 0;
                var palindromeCount = 0;

                var palindromes = new List<string>();
                var anagrams = new List<string>();

                while (!sr.EndOfStream)
                {
                    var word = sr.ReadLine().ToLower();
                    totalCount++;

                    if (IsPalindrome(word))
                    {
                        palindromeCount++;
                        palindromes.Add(word);
                        continue;
                    }

                    if (HasPalindromeAnagram(word))
                    {
                        palindromeAnagramCount++;
                        anagrams.Add(word);
                    }
                }
                Console.WriteLine($"total: {totalCount}, palindromes: {palindromeCount}, palindrome anagrams: {palindromeAnagramCount}");

                // // Report all non-palindrome words that have anagrams that are valid palindromes
                // var t = anagrams.Concat(palindromes).GroupBy(it => Canonicalize(it))
                //                 .Where(g => g.Count() > 1)
                //                 .SelectMany(g => g)
                //                 .Where(word => !palindromes.Contains(word) && palindromes.Select(Canonicalize).Contains(Canonicalize(word)));
                // foreach (var word in t)
                // {
                //     Console.WriteLine($"{word}  -> {palindromes.SingleOrDefault(p => Canonicalize(word) == Canonicalize(p)) ?? "N/A"}");
                // }
                // Console.WriteLine($"valid palindrome anagrams: {t.Count()}");
            }

            Console.WriteLine("\nDone!");
        }

        private static bool HasPalindromeAnagram(string word)
        {
            return 1 >= word.GroupBy(c => c).Count(g => (g.Count() & 1) == 1);
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

        private static string Canonicalize(string word)
        {
            var arr = word.ToCharArray();
            Array.Sort(arr);
            return new string(arr);
        }
    }
}
