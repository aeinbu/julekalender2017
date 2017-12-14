using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace luke14
{
	class Program
	{
		static void Main(string[] args)
		{
            var totalSteps = 30;
            var stepCountCombos = CombineOnesAndTwosAndThrees(totalSteps);

            var countOfPermutations = stepCountCombos
                .Select(c => Fact(c.ones + c.twos + c.threes) / (Fact(c.ones) * Fact(c.twos) * Fact(c.threes)));

			var sumOfPermutations = countOfPermutations.Aggregate((n, acc) => acc = acc + n);
            Console.WriteLine($"Permutations: {countOfPermutations.Count()} - {sumOfPermutations}");


			Console.WriteLine("\nDone!");
		}

		private static BigInteger Fact(BigInteger n) => Fact(n, 1);
		private static BigInteger Fact(BigInteger n, BigInteger stop) => n > stop ? n * Fact(n-1) : stop;


		private static IEnumerable<(int ones, int twos, int threes)> CombineOnesAndTwosAndThrees(int totalSteps)
		{
			for (int numberOfOnes = 0; numberOfOnes <= totalSteps; numberOfOnes++)
			{
				for (int numberOfTwos = 0; numberOfTwos <= totalSteps / 2; numberOfTwos++)
				{
					for (int numberOfThrees = 0; numberOfThrees <= totalSteps / 3; numberOfThrees++)
					{
                        if(numberOfOnes + numberOfTwos * 2 + numberOfThrees * 3 == totalSteps)
                        {
                            yield return (numberOfOnes, numberOfTwos, numberOfThrees);
                        }
					}
				}
			}
		}


	}
}
