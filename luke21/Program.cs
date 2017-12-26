using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace luke21
{
	class Program
	{
		const string Friendship = "vennskap";
		const string Enemyship = "fiendskap";

		static void Main(string[] args)
		{
			var sw = Stopwatch.StartNew();
			Console.WriteLine("Starting...");
			string filename = @"etteretningsrapport.txt";
			var model = new Model(filename);

			model.PrintStatsFor("Asgeir");

			// // 4360 4336 2232 (4431/4324/2173)
			// Console.WriteLine($"friends: {asgeirCluster.Count()}, enemies: {beateCluster.Count()}, neutrals: {neutrals.Count()}");

			Console.WriteLine($"\nDone in {sw.Elapsed}!");
		}
	}
}
