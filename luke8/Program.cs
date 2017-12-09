using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace luke8
{
	class Program
	{
		static void Main(string[] args)
		{
			var sw = Stopwatch.StartNew();
			long sum = 0;
			for (int i = 0; i <= 10000000; i++)
			{
				if(GetLastInSequence(i) == 1)
				{
					sum += i;
				}
			}
			Console.WriteLine(sw.Elapsed);
			Console.WriteLine(sum);

			Console.WriteLine("\nDone!");
		}

		private static int GetLastInSequence(int v)
		{
			var parts = GetDigits(v);
			var nextSum = parts.Select(part => part*part).Sum(partSquared => partSquared);
			if(new[]{0, 1, 4}.Contains(nextSum))
			{
				return nextSum;
			}
			// System.Console.WriteLine(nextSum);
			return GetLastInSequence(nextSum);
		}

		private static List<int> GetDigits(int v)
		{
			if(v >= 10)
			{
				var ret = new List<int>{v % 10};
				ret.AddRange(GetDigits(v / 10));
				return ret;
			}
			return new List<int>{v};
		}
	}
}
