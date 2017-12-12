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
			// Third(numberOfGuests);

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

			System.Console.WriteLine($"\nFirst says: {listOfGuests[0]}");
		}

		private static void Second(int numberOfGuests)
		{
			var listOfGuests = Enumerable.Range(1, numberOfGuests).ToList();
            var servingStartsAt = 0;
			while (listOfGuests.Count > 1)
			{
                var temp = listOfGuests.Nth(2, servingStartsAt).ToList();
                if((listOfGuests.Count & 1) == 1)
                {
                    servingStartsAt ^= 1;
                }
                listOfGuests = temp;

			}

			System.Console.WriteLine($"\nSecond says: {listOfGuests[0]}");
		}


		// private static void Third(int numberOfGuests)
		// {
		// 	var bitPos = 0;
		// 	var add = false;
		// 	var guestPos = 0;
		// 	while (numberOfGuests > 0)
		// 	{
        //         if((numberOfGuests & 1) != 1)
        //         {
		// 			add = !add;
        //         }
		// 		if(add){
		// 			guestPos += 1 << bitPos;
		// 		}
		// 		bitPos++;
		// 		numberOfGuests = numberOfGuests >> 1;
		// 	}

		// 	System.Console.WriteLine($"\nThird says: {guestPos + 1}");
		// }


	}
}
