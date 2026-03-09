using Microsoft.EntityFrameworkCore;

namespace Morpion.Database
{
    public class DatabaseService
    {
        private MorpionContext _context => new MorpionContext();

        public DatabaseService()
        {
            using var ctx = _context;
            ctx.Database.Migrate();
        }

        public int CreateGame(string gameMode)
        {
            using var ctx = _context;
            var game = new GameRecord
            {
                GameMode = gameMode,
                IsFinished = false,
                PlayedAt = DateTimeOffset.UtcNow
            };
            ctx.Games.Add(game);
            ctx.SaveChanges();
            return game.Id;
        }

        public void FinishGame(int gameId, string result)
        {
            using var ctx = _context;
            var game = ctx.Games.FirstOrDefault(g => g.Id == gameId);
            if (game != null)
            {
                game.Result = result;
                game.IsFinished = true;
                game.BoardState = null;
                ctx.SaveChanges();
            }
        }

        public void SaveBoardState(int gameId, string boardState)
        {
            using var ctx = _context;
            var game = ctx.Games.FirstOrDefault(g => g.Id == gameId);
            if (game != null)
            {
                game.BoardState = boardState;
                ctx.SaveChanges();
            }
        }

        public void PrintStats()
        {
            using var ctx = _context;

            var total = ctx.Games.Count(g => g.IsFinished);

            var stats = ctx.Games
                .Where(g => g.IsFinished && g.GameMode == "HvB")
                .GroupBy(g => g.Result)
                .Select(g => new { Result = g.Key, Count = g.Count() })
                .ToList();

            int humanWins = stats.FirstOrDefault(s => s.Result == "X")?.Count ?? 0;
            int botWins = stats.FirstOrDefault(s => s.Result == "O")?.Count ?? 0;
            int draws = stats.FirstOrDefault(s => s.Result == "Draw")?.Count ?? 0;

            Console.WriteLine("=== HISTORIQUE ===");
            Console.WriteLine($"Parties terminées : {total}");
            Console.WriteLine($"[HvBot] Victoires humain : {humanWins} | Victoires bot : {botWins} | Nuls : {draws}");
            Console.WriteLine("==================");
        }

        public GameRecord? GetLastUnfinishedGame()
        {
            using var ctx = _context;
            return ctx.Games
                .Where(g => !g.IsFinished)
                .OrderByDescending(g => g.PlayedAt)
                .FirstOrDefault();
        }
    }
}