using System;
using System.Linq;
using System.Threading;

namespace luke12
{
	class Program
	{
		enum Color : byte
		{
			White = 0, Black
		};

		private const int BoardSize = 10;

		static void Main(string[] args)
		{
			Console.Clear();

			var board = new Color[BoardSize * BoardSize];
			// var board = new Color[BoardSize, BoardSize];
			var toPos = (x: 0, y: 0);

			(int dx, int dy)[] allMoves = { (-1, 2), (1, 2), (-2, 1), (2, 1), (-1, -2), (1, -2), (-2, -1), (2, -1) };

			int i;
			for (i = 0; i < 200; i++)
			{
				var fromPos = toPos;
				var fromColor = board[FieldNumber(toPos)];
				// var fromColor = board[toPos.x, toPos.y];

				var allPossibilities = allMoves.Select(move => Move(fromPos, move))
											.Where(pos => IsWithinBoard(pos));

				var possibilitiesInCurrentColor = allPossibilities.Where(pos => board[FieldNumber(pos)] == fromColor);
				// var possibilitiesInCurrentColor = allPossibilities.Where(pos => board[pos.x, pos.y] == fromColor);
				if (possibilitiesInCurrentColor.Any())
				{
					toPos = possibilitiesInCurrentColor.OrderBy(pos => FieldNumber(pos)).First();
				}
				else
				{
					toPos = allPossibilities.OrderBy(pos => FieldNumber(pos)).Last();
				}

				board[FieldNumber(fromPos)] = SwitchColor(board[FieldNumber(fromPos)]);
				// board[fromPos.x, fromPos.y] = SwitchColor(board[fromPos.x, fromPos.y]);


				PrintAt(board[FieldNumber(fromPos)] == Color.Black? '■' : ' ', fromPos);
				// PrintAt(board[fromPos.x, fromPos.y] == Color.Black? '■' : ' ', fromPos);
				PrintAt('*', toPos);
				Thread.Sleep(20);
			}

			Console.SetCursorPosition(0, 12);
			Console.Write(board.Where(pos => pos == Color.Black).Count());
			Console.WriteLine("\nDone!");
		}

		private static Color SwitchColor(Color currentColor) => currentColor == Color.White ? Color.Black : Color.White;

		private static void PrintAt(char c, (int x, int y) coord)
		{
			Console.SetCursorPosition(coord.x, coord.y);
			Console.Write(c);
		}

		static (int x, int y) Move((int x, int y) from, (int x, int y) to)
		{
			return (from.x + to.x, from.y + to.y);
		}

		static bool IsWithinBoard((int x, int y) pos)
		{
			return pos.x >= 0 && pos.x < BoardSize && pos.y >= 0 && pos.y < BoardSize;
		}

		static int FieldNumber((int x, int y) pos) => pos.x * BoardSize + pos.y;
		static (int x, int y) FieldPos(int fieldNumber) => (x: fieldNumber % BoardSize, y: fieldNumber / BoardSize);
	}
}
