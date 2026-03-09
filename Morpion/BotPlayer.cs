using System;
using System.Linq;

namespace Morpion
{
    public class BotPlayer : Player
    {
        private static Random rng = new Random();

        public BotPlayer(char symbol) : base(symbol)
        {
        }

        public override async Task<PlayerMove> GetNextMoveAsync(Board board)
        {
            Console.WriteLine($"Le bot {Symbol} est en train de jouer...");
            await Task.Delay(3000);

            var emptyCells =
                from row in Enumerable.Range(0, 3)
                from col in Enumerable.Range(0, 3)
                where board.IsCellEmpty(row, col)
                select new { row, col };


            var choice = emptyCells.OrderBy(c => rng.Next()).First();

            return new PlayerMove(choice.row, choice.col);
        }
    }
}

