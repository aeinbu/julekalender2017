using System;
using System.Linq;

namespace luke2
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<int> Test = x => Console.WriteLine($"{x} - {x.CountSetBits().IsOdd()}");

            Test(1);
            Test(2);
            Test(3);
            Test(10);
            Test(11);
        }

        private static int CountSetBits(int x) => Enumerable.Range(0,32).Sum(i => x >> i & 1);
    }
}
