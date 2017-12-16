using System;
using System.Collections.Generic;
using System.IO;

namespace luke16
{
	class Program
	{
		static void Main(string[] args)
		{
			var prisonersWhoTurnedOnTheLight = new List<string>();
			var lightIsOn = false;
			var numberOfTimesTheLightsAreTurnedOf = 0;
			var iterationsCount = 0;
			foreach (var prisoner in GetVisitationSequence())
			{
				iterationsCount++;
				if (prisoner == "1")
				{
					if (lightIsOn && ++numberOfTimesTheLightsAreTurnedOf == 99)
					{
						break;
					}
					lightIsOn = false;

					continue;
				}

				if (!lightIsOn && !prisonersWhoTurnedOnTheLight.Contains(prisoner))
				{
					prisonersWhoTurnedOnTheLight.Add(prisoner);
					lightIsOn = true;
				}
			}
            
			Console.WriteLine(iterationsCount);

			Console.WriteLine("\nDone!");
		}

		public static IEnumerable<string> GetVisitationSequence()
		{
			var filename = "prisoners.txt";
			using (var sr = new StreamReader(filename))
			{
				while (!sr.EndOfStream)
				{
					yield return sr.ReadLine();
				}
			}
		}
	}
}
