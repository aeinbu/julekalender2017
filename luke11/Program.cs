using System;
using System.Collections.Generic;
using System.Linq;

namespace luke11
{
	class Program
	{
		
		static void Main(string[] args)
		{
		 	var _primes = Primes(1000).Select(prime => prime.ToString());
			var answers = _primes.Where(prime => _primes.Contains(Reverse(prime)) && prime != Reverse(prime)).ToList();
			// answers.ForEach(Console.WriteLine);

			System.Console.WriteLine();
			System.Console.WriteLine($"count: {answers.Count}");
			Console.WriteLine("\nDone!");
		}

		private static IEnumerable<int> Primes(int max)
		{
			var numbers = Enumerable.Range(1, max).ToList();

			for (int i = 1; i < numbers.Count(); i++)
			{
				var number = numbers[i];
				for (int j = i + 1; j < numbers.Count; j++)
				{
					if(numbers[j] % number == 0)
					{
						numbers.RemoveAt(j);
						j--;
					}
				}
			}

			return numbers;
		}

		private static string Reverse(string word)
		{
			return new string(word.Reverse().ToArray());
		}

	}
}