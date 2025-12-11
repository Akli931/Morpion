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

            Console.WriteLine("Choisir le mode de jeu :");
            Console.WriteLine("1 - Joueur vs Joueur");
            Console.WriteLine("2 - Joueur vs Bot");
            Console.Write("Votre choix : ");

            string choice = Console.ReadLine() ?? "1";

            if (choice == "2")
            {
                playerX = new HumanPlayer('X');
                playerO = new BotPlayer('O');
                Console.WriteLine("Mode sélectionné : Joueur vs Bot");
            }
            else
            {
                playerX = new HumanPlayer('X');
                playerO = new HumanPlayer('O');
                Console.WriteLine("Mode sélectionné : Joueur vs Joueur");
            }

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
