using System;
using System.Collections.Generic;
using System.Linq;

namespace luke23
{
	public enum Winner {None, X, O};
	public enum Player {X = 0, O = ~0};

	public class Game
	{

		Dictionary<Player, int> _boards = new Dictionary<Player, int>();
		Player _nextPlayer;

		readonly int[] _winningCombos = new[]{
			0b000_000_111,	// [1,2,3],
			0b000_111_000,	// [4,5,6],
			0b111_000_000,	// [7,8,9],
			0b001_001_001,	// [1,4,7],
			0b010_010_010,	// [2,5,8],
			0b100_100_100,	// [3,6,9],
			0b100_010_001,	// [1,5,9],
			0b001_010_100		// [3,5,7]

		};

		public Winner Winner { get; internal set; }
		public bool IsFinished { get; internal set; }

		public Game()
		{
			Console.WriteLine("Game starts!");
			_boards[Player.X] = 0;
			_boards[Player.O] = 0;
			_nextPlayer = Player.X;
		}

		internal void Play(int move)
		{
			var currentPlayer = _nextPlayer;
			Console.WriteLine($"{currentPlayer} plays {move}");
			
			_nextPlayer = ~currentPlayer;
			
			_boards[currentPlayer] |= 1 << (move-1);
			CheckOutcome(currentPlayer);
		}

		private void CheckOutcome(Player currentPlayer)
		{
			if(_winningCombos.Any(combo => (_boards[currentPlayer] & combo) == combo))
			{
				Console.WriteLine($"{currentPlayer} wins with {_boards[currentPlayer]} which matches {string.Join("-", _winningCombos.Where(combo => (_boards[currentPlayer] & combo) == combo))}");
				IsFinished = true;
				Winner = currentPlayer == Player.X ? Winner.X : Winner.O;
				return;
			}

			if((_boards[Player.X] | _boards[Player.O]) == 0b111111111)
			{
				Console.WriteLine($"Tie!");
				
				IsFinished = true;
				Winner = Winner.None;
			}
		}
	}
}