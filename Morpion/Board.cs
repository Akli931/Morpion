using System;
using System.Collections.Generic;
using System.Text;

namespace Morpion
{
    public class Board
    {
        private char[,] plateau;

        public Board()
        {
            plateau = new char[3, 3]
            {
            { ' ', ' ', ' ' },
            { ' ', ' ', ' ' },
            { ' ', ' ', ' ' }
            };
        }


        public void DisplayBoard()
        {
           

            for (int i = 0; i < 3; i++)
            {
                Console.Write(" ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(" " + plateau[i, j] + " ");
                    if (j < 2)
                        Console.Write("|");
                }
                Console.WriteLine();

                if (i < 2)
                {
                    Console.Write(" ---+---+---");
                    Console.WriteLine();
                }
            }
        }

        public bool IsCellEmpty(int row, int col)
        {
            return plateau[row, col] == ' ';
        }


       public void PlayMove(int row, int col, char player)
        {
             plateau[row, col] = player; 
        }


        public bool IsGameWon(char player)
        {
           
            bool ligne = Enumerable.Range(0, 3)
                .Any(i => Enumerable.Range(0, 3)
                    .All(j => plateau[i, j] == player));

            
            bool colonne = Enumerable.Range(0, 3)
                .Any(j => Enumerable.Range(0, 3)
                    .All(i => plateau[i, j] == player));

            
            bool diag1 = Enumerable.Range(0, 3)
                .All(i => plateau[i, i] == player);

            
            bool diag2 = Enumerable.Range(0, 3)
                .All(i => plateau[i, 2 - i] == player);

            return ligne || colonne || diag1 || diag2;
        }


        public bool IsDraw()
        {
            return plateau.Cast<char>().All(c => c != ' ');
        }



    }
}


