using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace luke2
{
	class Program
	{
		private const int gridsize = 20;
		private static bool[,] _visited = new bool[gridsize, gridsize];

		static void Main(string[] args)
		{
			Console.Clear();
			var stopwatch = Stopwatch.StartNew();

			Print(coord => IsClosed(coord) ? '#' : ' ');

			var startCoord = (0, 0);
			Walk(startCoord);
			var endCoord = (0, gridsize +1);
			PrintAt(' ', endCoord);

			// Console.WriteLine();
			// Print(coord => HasBeenVisited(coord) ? '+' : ' ');

			// Console.WriteLine();
			// Print(coord => IsClosed(coord)
			// 				? '#'
			// 				: HasBeenVisited(coord)
			// 					? '.'
			// 					: '*');

			var untouchedCount = 0;
			for (int x = 0; x < gridsize; x++)
			{
				for (int y = 0; y < gridsize; y++)
				{
					var coord = (x, y);
					if (!HasBeenVisited(coord) && !IsClosed(coord))
					{
						untouchedCount++;
					}
				}
			}
            Console.WriteLine(untouchedCount);

			Console.WriteLine($"Time taken: {stopwatch.Elapsed}");
		}

		private static void PrintAt(char c, (int x, int y) coord)
		{
			Console.SetCursorPosition(coord.x, coord.y);
			Console.Write(c);
		}

		private static void Walk((int x, int y) coord)
		{
			Action<(int x, int y)> mark = cursorPos => {PrintAt('+', cursorPos); Thread.Sleep(50);};
			MarkAsVisited(coord);
			mark(coord);

			
			if (CanGoUpFrom(coord) && !HasBeenVisited(UpFrom(coord))) Walk(UpFrom(coord));
			mark(coord);

			if (CanGoRightFrom(coord) && !HasBeenVisited(RightFrom(coord))) Walk(RightFrom(coord));
			mark(coord);

			if (CanGoDownFrom(coord) && !HasBeenVisited(DownFrom(coord))) Walk(DownFrom(coord));
			mark(coord);

			if (CanGoLeftFrom(coord) && !HasBeenVisited(LeftFrom(coord))) Walk(LeftFrom(coord));
			mark(coord);
		}

		private static void MarkAsVisited((int x, int y) coord)
		{
			_visited[coord.x, coord.y] = true;
		}

		private static bool HasBeenVisited((int x, int y) coord)
		{
			return _visited[coord.x, coord.y];
		}

		private static void Print(Func<(int x, int y), char> fn)
		{
			for (int y = 0; y < gridsize; y++)
			{
				for (int x = 0; x < gridsize; x++)
				{
					var coord = (x, y);
					// Console.Write(fn(coord));
					PrintAt(fn(coord), coord);
				}
				Console.WriteLine();
			}
		}


		private static long Pow(int x, int y) => (long)Math.Pow(x, y);

		private static bool IsClosed((int x, int y) coord) => F(coord.x + 1, coord.y + 1).CountSetBits().IsOdd();
		private static long F(int x, int y) => Pow(x, 3) + 12 * x * y + 5 * x * Pow(y, 2);

		public static bool CanGoUpFrom((int x, int y) coord) => (coord.y > 0) && !IsClosed(UpFrom(coord));
		public static bool CanGoDownFrom((int x, int y) coord) => (coord.y < gridsize - 1) && !IsClosed(DownFrom(coord));
		public static bool CanGoLeftFrom((int x, int y) coord) => (coord.x > 0) && !IsClosed(LeftFrom(coord));
		public static bool CanGoRightFrom((int x, int y) coord) => (coord.x < gridsize - 1) && !IsClosed(RightFrom(coord));

		public static (int x, int y) UpFrom((int x, int y) coord) => (coord.x, coord.y - 1);
		public static (int x, int y) DownFrom((int x, int y) coord) => (coord.x, coord.y + 1);
		public static (int x, int y) LeftFrom((int x, int y) coord) => (coord.x - 1, coord.y);
		public static (int x, int y) RightFrom((int x, int y) coord) => (coord.x + 1, coord.y);

		// public static int ToInt((int x, int y) coord) => coord.x + coord.y * gridsize;
		// public static (int x, int y) ToCoordinate(int arrayPos) => (x: arrayPos % gridsize, y: arrayPos / gridsize);


	}
}
