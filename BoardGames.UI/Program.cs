using BoardGamesApp.BoardGames.BLL.Models.Enums;
using BoardGamesApp.BoardGames.BLL.Models.Players;
using BoardGamesApp.BoardGames.BLL.Services;
using BoardGamesApp.Services;
using BoardGames.BLL.DTOs;
using BoardGames.BLL.Services;
using BoardGames.DAL;
using BoardGames.DAL.UnitOfWork;
using System;
using System.Collections.Generic;

var factory = new GameFactory();
var engine = new GameEngine();
var view = new ConsoleGameView();

var dbContext = new AppDbContext();

var unitOfWork = new UnitOfWork(dbContext);

var sessionService =
    new GameSessionService(unitOfWork);

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

    if (!int.TryParse(input, out int choice) ||
        choice < 1 ||
        choice > 4)
    {
        view.ShowError(
            "\nInvalid choice! Press any key to try again...");

        Console.ReadKey();
        continue;
    }

    try
    {
        GameType gameType = (GameType)choice;

        var players = new List<Player>
        {
            new Player("Alice"),
            new Player("Bob")
        };

        var game = factory.CreateGame(gameType, players);

        // Observer №1
        game.TurnMade += view.ShowTurn;

        // Observer №2
        foreach (var player in players)
        {
            player.PlayerWon += winner =>
            {
                view.ShowWinner(winner);

                GameLogger.Instance.Log(
                    $"WINNER: {winner.Name}");
            };
        }

        Console.Clear();

        view.ShowGameStarted(game.Name);

        // Singleton
        GameLogger.Instance.Log(
            $"Game '{game.Name}' started.");

        engine.StartGame(game);

        if (game.Winner != null)
        {
            var sessionDto = new GameSessionDto
            {
                GameName = game.Name,
                WinnerName = game.Winner.Name,
                PlayedAt = DateTime.Now
            };

            sessionService.SaveGameResult(sessionDto);

            GameLogger.Instance.Log(
                "Game result saved to database.");
        }

        GameLogger.Instance.Log(
            $"Game '{game.Name}' finished.");

        view.ShowGameOver();
    }
    catch (Exception ex)
    {
        view.ShowError(
            $"Error: {ex.Message}");
    }

    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine(
        "\nPress any key to return to Main Menu...");
    Console.ResetColor();

    Console.ReadKey();
}
