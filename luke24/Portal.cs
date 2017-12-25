using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace luke24
{
	public class Portal
	{
		public static IEnumerable<Portal> LoadPortals(string filename)
		{
			// (8385,7421)->(887,1369)
			var regex = new Regex(@"\((?<fromX>\d+),(?<fromY>\d+)\)->\((?<toX>\d+),(?<toY>\d+)\)", RegexOptions.Compiled);
			using (var sr = new StreamReader(filename))
			{
				// var matches = regex.Matches(sr.ReadToEnd());
				// foreach (Match match in matches)
				// {
				// 	Func<string, int> get = groupname => int.Parse(match.Groups[groupname].Value);
				// 	var from = (x: get("fromX"), y: get("fromY"));
				// 	var to = (x: get("toX"), y: get("toY"));
				// 	yield return new Portal(from, to);
				// }

				while(!sr.EndOfStream){
					var line = sr.ReadLine();
					var match = regex.Match(line);
					Func<string, int> get = groupname => int.Parse(match.Groups[groupname].Value);
					var from = (x: get("fromX"), y: get("fromY"));
					var to = (x: get("toX"), y: get("toY"));
					yield return new Portal(from, to);
				}
			}
		}

		public (int x, int y) From {get;}
		public (int x, int y) To {get;}

		public Portal((int x, int y) from, (int x, int y) to)
		{
			From = from;
			To = to;
		}

		public override string ToString()
		{
			return $"portal: {From}->{To}";
		}
	}
}