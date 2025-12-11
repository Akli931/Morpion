using System;
using System.Collections.Generic;
using System.Text;

namespace Morpion
{
    public class Game
    {
        private Board board;
        private Player playerX;
        private Player playerO;
        private Player currentPlayer;

        public Game()
        {
            board = new Board();
            playerX = new Player('X');
            playerO = new Player('O');

            currentPlayer = playerX; 
        }


        public void Start()
        {
            while (true)
            {
                
                board.DisplayBoard();

                Console.WriteLine();
                Console.WriteLine($"Au tour du joueur {currentPlayer.Symbol}");


                var move = currentPlayer.GetNextMove(board);
                board.PlayMove(move.row, move.column, currentPlayer.Symbol);



                if (board.IsGameWon(currentPlayer.Symbol))
                {
                    board.DisplayBoard();
                    Console.WriteLine();
                    Console.WriteLine($" Le joueur {currentPlayer.Symbol} a gagné !");
                    break;
                }

                
                if (board.IsDraw())
                {
                    board.DisplayBoard();
                    Console.WriteLine();
                    Console.WriteLine("Match nul !");
                    break;
                }

                
                currentPlayer = (currentPlayer == playerX) ? playerO : playerX;
            }

            Console.WriteLine();
            Console.WriteLine("Fin de la partie.");
        }


    }
}
