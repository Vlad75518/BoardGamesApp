using BoardGamesApp.Models.Enums;
using BoardGamesApp.Models.Players;
using BoardGamesApp.Services;
using System;
using System.Collections.Generic;

var factory = new GameFactory();
var engine = new GameEngine();

while (true)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("=================================");
    Console.WriteLine("===   BOARD GAMES SIMULATOR   ===");
    Console.WriteLine("=================================");
    Console.ResetColor();

    Console.WriteLine("Choose a game to play:");
    Console.WriteLine("1 - Chess");
    Console.WriteLine("2 - Monopoly");
    Console.WriteLine("3 - Checkers");
    Console.WriteLine("4 - Backgammon");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("0 - Exit Program");
    Console.ResetColor();
    Console.Write("\nEnter choice > ");

    string? input = Console.ReadLine();
    if (input == "0")
    {
        Console.WriteLine("Goodbye!");
        break;
    }

    if (!int.TryParse(input, out int choice) || choice < 1 || choice > 4)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nInvalid choice! Press any key to try again...");
        Console.ResetColor();
        Console.ReadKey();
        continue;
    }

    GameType gameType = (GameType)choice;

    // Створюємо нових гравців для кожної нової партії
    var players = new List<Player>
    {
        new Player("Alice"),
        new Player("Bob")
    };

    // Підписка на подію перемоги гравця
    foreach (var player in players)
    {
        player.PlayerWon += winner =>
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"\n🏆 {winner.Name} won the game!");
            Console.ResetColor();
        };
    }

    // Фабрика створює чистий екземпляр гри, де IsFinished = false
    var game = factory.CreateGame(gameType, players);

    // Запускаємо симуляцію гри
    engine.StartGame(game);

    // Після завершення гри повертаємось сюди
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine("\nPress any key to return to Main Menu...");
    Console.ResetColor();
    Console.ReadKey();
}