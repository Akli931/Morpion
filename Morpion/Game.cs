using System;
using Morpion.Database;

namespace Morpion
{
    public class Game
    {
        private Board board;
        private Player playerX;
        private Player playerO;
        private Player currentPlayer;
        private DatabaseService _db;
        private int _gameId;
        private string _gameMode;
        public Player? Winner { get; private set; }

        public Game(DatabaseService db)
        {
            board = new Board();
            _db = db;

            Console.WriteLine("Choisir le mode de jeu :");
            Console.WriteLine("1 - Joueur vs Joueur");
            Console.WriteLine("2 - Joueur vs Bot");
            Console.Write("Votre choix : ");
            string choice = Console.ReadLine() ?? "1";

            if (choice == "2")
            {
                playerX = new HumanPlayer('X');
                playerO = new BotPlayer('O');
                _gameMode = "HvB";
                Console.WriteLine("Mode sélectionné : Joueur vs Bot");
            }
            else
            {
                playerX = new HumanPlayer('X');
                playerO = new HumanPlayer('O');
                _gameMode = "HvH";
                Console.WriteLine("Mode sélectionné : Joueur vs Joueur");
            }

            currentPlayer = playerX;
            _gameId = _db.CreateGame(_gameMode);
        }

        // Constructeur pour reprendre une partie en cours
        public Game(GameRecord record, DatabaseService db)
        {
            board = new Board();
            _db = db;
            _gameId = record.Id;
            _gameMode = record.GameMode;

            if (_gameMode == "HvB")
            {
                playerX = new HumanPlayer('X');
                playerO = new BotPlayer('O');
            }
            else
            {
                playerX = new HumanPlayer('X');
                playerO = new HumanPlayer('O');
            }

            currentPlayer = playerX;

            if (record.BoardState != null)
                board.LoadBoardState(record.BoardState);

            Console.WriteLine("Partie reprise !");
        }

        public Game(Player playerX, Player playerO)
        {
            board = new Board();
            this.playerX = playerX;
            this.playerO = playerO;
            currentPlayer = playerX;
            _db = new DatabaseService();
            _gameMode = "HvH";
            _gameId = _db.CreateGame(_gameMode);
        }

        public async Task StartAsync()
        {
            while (true)
            {
                board.DisplayBoard();
                Console.WriteLine();
                Console.WriteLine($"Au tour du joueur {currentPlayer.Symbol}");

                var move = await currentPlayer.GetNextMoveAsync(board);
                board.PlayMove(move.row, move.column, currentPlayer.Symbol);
                _db.SaveBoardState(_gameId, board.GetBoardState());

                if (board.IsGameWon(currentPlayer.Symbol))
                {
                    Winner = currentPlayer;
                    _db.FinishGame(_gameId, currentPlayer.Symbol.ToString());
                    board.DisplayBoard();
                    Console.WriteLine();
                    Console.WriteLine($"Le joueur {currentPlayer.Symbol} a gagné !");
                    break;
                }

                if (board.IsDraw())
                {
                    _db.FinishGame(_gameId, "Draw");
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