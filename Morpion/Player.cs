using System;
using System.Collections.Generic;
using System.Text;

namespace Morpion
{
    public class Player
    {
        public char Symbol { get; }

        public Player(char symbol)
        { this.Symbol = symbol; }

        public record PlayerMove(int row, int column);
        public PlayerMove GetNextMove(Board board)
        {
            int row;
            int col;

            while (true)
            {
                Console.Write($"Joueur {Symbol}, entre une ligne (0-2) : ");
                bool okRow = int.TryParse(Console.ReadLine(), out row);

                Console.Write($"Joueur {Symbol}, entre une colonne (0-2) : ");
                bool okCol = int.TryParse(Console.ReadLine(), out col);

                
                if (!okRow || !okCol || row < 0 || row > 2 || col < 0 || col > 2)
                {
                    Console.WriteLine(" Saisie invalide, réessaie !");
                    continue;
                }

                
                if (!board.IsCellEmpty(row, col))
                {
                    Console.WriteLine(" Cette case est déjà occupée !");
                    continue;
                }

                return new PlayerMove(row, col);

            }


        }
                   
    }
}
