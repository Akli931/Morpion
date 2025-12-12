using Morpion;
using System.Collections.Generic;

namespace Morpion.Tests
{
    public class FakePlayer : Player
    {
        private Queue<PlayerMove> moves;

        public FakePlayer(char symbol, IEnumerable<PlayerMove> moves)
            : base(symbol)
        {
            this.moves = new Queue<PlayerMove>(moves);
        }

        public override PlayerMove GetNextMove(Board board)
        {
            return moves.Dequeue();
        }
    }
}
