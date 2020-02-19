using System.Linq;

namespace BlazorConnectFour.Data
{
	public class GameBoard
    {
        public ColoredDisc[,] Board { get; }
        public TurnManager TurnManager { get; }
		public WinnerManager WinnerManager { get; }

		public int LengthX => Board.GetLength(0);
        public int LengthY => Board.GetLength(1);

        public GameBoard()
        {
            Board = new ColoredDisc[7, 6];
            TurnManager = new TurnManager();
			WinnerManager = new WinnerManager();

			for (int x = 0; x < LengthX; x++)
            {
                for (int y = 0; y < LengthY; y++)
                {
                    Board[x, y] = new ColoredDisc();
                }
            }
        }

        public bool IsYPositionInsideBoard(int y)
        {
            return y < LengthY - 1;
        }

		public bool IsComplete()
		{
			return !Board.Cast<ColoredDisc>().Any(slot => slot.IsEmpty());
		}

		public void CheckWinner()
		{
			var HEIGHT = LengthX;
			var WIDTH = LengthY;
			for (int x = 0; x < HEIGHT; x++)
			{ // iterate rows, bottom to top
				for (int y = 0; y < WIDTH; y++)
				{ // iterate columns, left to right
					var slot = Board[x, y];
					if (slot.IsEmpty())
						continue; // don't check empty slots

					if (y + 3 < WIDTH &&
						slot.Color == Board[x, y + 1].Color && // look right
						slot.Color == Board[x, y + 2].Color &&
						slot.Color == Board[x, y + 3].Color)
					{
						WinnerManager.SetWinner(slot.Color);
						return;
					}
					if (x + 3 < HEIGHT)
					{
						if (slot.Color == Board[x + 1, y].Color && // look up
							slot.Color == Board[x + 2, y].Color &&
							slot.Color == Board[x + 3, y].Color)
						{
							WinnerManager.SetWinner(slot.Color);
							return;
						}
						if (y + 3 < WIDTH &&
							slot.Color == Board[x + 1, y + 1].Color && // look up & right
							slot.Color == Board[x + 2, y + 2].Color &&
							slot.Color == Board[x + 3, y + 3].Color)
						{
							WinnerManager.SetWinner(slot.Color);
							return;
						}
						if (y - 3 >= 0 &&
							slot.Color == Board[x + 1, y - 1].Color && // look up & left
							slot.Color == Board[x + 2, y - 2].Color &&
							slot.Color == Board[x + 3, y - 3].Color)
						{
							WinnerManager.SetWinner(slot.Color);
							return;
						}
					}
				}
			}
			WinnerManager.SetWinner(DiscColor.Blank); // no winner found
		}
	}
}
