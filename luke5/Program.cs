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
            var numbers = new List<int>(){0,1, 2, 2};            
            var nextNum = 3;

            while(numbers.Count < count)
            {
                numbers.AddRange(Enumerable.Repeat(nextNum, numbers[nextNum]));
                nextNum++;
            }

            System.Console.WriteLine(numbers.Skip(1).Take(count).Sum(number => (long)number));

            Console.WriteLine("\nDone!");
        }

    }
}
