using System.Linq;

namespace luke2
{
	public static class Extensions
	{
		public static bool IsOdd(this int x) => (x & 1) == 1;

		public static int CountSetBits(this long x) => (int)Enumerable.Range(0, 64).Sum(i => x >> i & 1);


	}
}