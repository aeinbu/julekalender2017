using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace luke24
{
	class Program
	{
		static List<Portal> _portals = Portal.LoadPortals(@"Portals.txt").ToList();
		static (int x, int y) _start = (x: 0, y: 0);
		static (int x, int y) _end = (x: 9999, y: 9999);
		static int _shortestKnown;

		static void Main(string[] args)
		{
			var sw = Stopwatch.StartNew();

			var rec0portals = new[] { (stepsUsed: 0, newPos: _start) };
			_shortestKnown = rec0portals.Select(p1 => p1.stepsUsed + CountSteps(p1.newPos, _end)).Min();
			Console.WriteLine($"shortest known after rec#0 {_shortestKnown}");

			var res = Rec(rec0portals);

			var stepCounts = res.Select(p1 => p1.stepsUsed + CountSteps(p1.newPos, _end));
			var minStepCount = stepCounts.Min();
			Console.Write($"found min {minStepCount} in {sw.Elapsed}");

			Console.WriteLine("\nDone!");
		}

		static IEnumerable<(int stepsUsed, (int x, int y) newPos)> Rec(IEnumerable<(int stepsUsed, (int x, int y) newPos)> rec0portals)
		{
			var rec1portals = rec0portals.SelectMany(p1 => _portals.Where(p2 => CountSteps(p1.newPos, p2.From) <= _shortestKnown - p1.stepsUsed)
															   .Select(p2 => (stepsUsed: CountSteps(p1.newPos, p2.From) + p1.stepsUsed, newPos: p2.To)));
			if (rec1portals.Any())
			{
				_shortestKnown = rec1portals.Select(p1 => p1.stepsUsed + CountSteps(p1.newPos, _end)).Min();
				Console.WriteLine($"shortest known so far {_shortestKnown}");
				return Rec(rec1portals);
			}
			return rec0portals;
		}

		static int CountSteps((int x, int y) from, (int x, int y) to)
		{
			// naïve first version: does not take into account walking over other portal's from fields.
			var rel = (x: Math.Abs(to.x - from.x), y: Math.Abs(to.y - from.y));
			if (rel.x == 0 || rel.y == 0)
			{
				// Console.WriteLine($"from: {from} to: {to}");
				if (rel.x == 0)
				{
					var xBlockers = _portals.Where(portal => portal.From.x == from.x);
					// Console.WriteLine($"x blockers: {xBlockers.Count()}");
				}

				if (rel.y == 0)
				{
					var yBlockers = _portals.Where(portal => portal.From.y == from.y);
					// Console.WriteLine($"y blockers: {yBlockers.Count()}");
				}

				// Console.WriteLine();
			}

			return rel.x + rel.y;
		}

	}
}
