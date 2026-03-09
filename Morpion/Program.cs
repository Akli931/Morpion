using Morpion;

var db = new DatabaseService();
db.PrintStats();

var unfinished = db.GetLastUnfinishedGame();
if (unfinished != null && unfinished.BoardState != null)
{
    Console.WriteLine("\nUne partie est en cours. Voulez-vous la reprendre ? (o/n)");
    string resume = Console.ReadLine() ?? "n";
    if (resume.ToLower() == "o")
    {
        var game = new Game(unfinished, db);
        await game.StartAsync();
        Console.ReadLine();
        return;
    }
}

Game newGame = new Game(db);
await newGame.StartAsync();
Console.ReadLine();
