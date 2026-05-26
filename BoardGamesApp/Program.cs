using BoardGamesApp.Models.Enums;
using BoardGamesApp.Models.Players;
using BoardGamesApp.Services;

Console.WriteLine("Choose a game:");
Console.WriteLine("1 - Chess");
Console.WriteLine("2 - Monopoly");
Console.WriteLine("3 - Checkers");
Console.WriteLine("4 - Backgammon");

GameType gameType =
    (GameType)Convert.ToInt32(Console.ReadLine());

var players = new List<Player>
{
    new Player("Alice"),
    new Player("Bob")
};

foreach (var player in players)
{
    player.PlayerWon += winner =>
    {
        Console.WriteLine($"{winner.Name} won the game!");
    };
}

var factory = new GameFactory();

var game = factory.CreateGame(gameType, players);

var engine = new GameEngine();

engine.StartGame(game);