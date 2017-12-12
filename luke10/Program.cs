using System;
using System.Linq;

namespace luke10
{
    class Program
    {
        static void Main(string[] args)
		{
            var numberOfGuests = 1500;
			First(numberOfGuests);
            Second(numberOfGuests);
            

            System.Console.WriteLine();
            Enumerable.Range(1,10).Nth(2,0).ToList().ForEach(Console.WriteLine);
            System.Console.WriteLine();
            Enumerable.Range(1,10).Nth(2,1).ToList().ForEach(Console.WriteLine);
            System.Console.WriteLine();
            Enumerable.Range(1,10).Nth(3,2).ToList().ForEach(Console.WriteLine);



			Console.WriteLine("\nDone!");
		}

		private static void First(int numberOfGuests)
		{
			var listOfGuests = Enumerable.Range(1, numberOfGuests).ToList();
			var pos = 0;
			while (listOfGuests.Count > 1)
			{
				if (++pos >= listOfGuests.Count)
				{
					pos -= listOfGuests.Count;
				}
				listOfGuests.RemoveAt(pos);
			}

			System.Console.WriteLine($"\nSecond says: {listOfGuests[0]}");
		}

		private static void Second(int numberOfGuests)
		{
			var listOfGuests = Enumerable.Range(1, numberOfGuests).ToList();
            var servingStartsAt = 0;
			// var pos = 0;
			while (listOfGuests.Count > 1)
			{
                var temp = listOfGuests.Nth(2, servingStartsAt).ToList();
                if((listOfGuests.Count & 1) == 1)
                {
                    servingStartsAt ^= 1;
                }
                listOfGuests = temp;

			}

			System.Console.WriteLine($"\nFirst says: {listOfGuests[0]}");
		}


	}
}
