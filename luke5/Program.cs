using System;
using System.Collections.Generic;
using System.Linq;

namespace luke5
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = 1000000;
            var numbers = new List<int>(){1, 2, 2};            
            var nextNum = 3;

            while(numbers.Count < count)
            {
                numbers.AddRange(Enumerable.Repeat(nextNum, numbers[nextNum-1]));
                nextNum++;
            }

            System.Console.WriteLine(numbers.Take(count).Sum(number => (long)number));

            Console.WriteLine("\nDone!");
        }

    }
}
