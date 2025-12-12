using System;
using System.Collections.Generic;
using System.Text;



namespace Morpion
{
    public abstract class Player
    {
        public char Symbol { get; }

        protected Player(char symbol)
        {
            Symbol = symbol;
        }

        public record PlayerMove(int row, int column);

        public abstract Task<PlayerMove> GetNextMoveAsync(Board board);

    }
}
