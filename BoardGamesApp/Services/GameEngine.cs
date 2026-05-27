using BoardGamesApp.Models.Actions;
using BoardGamesApp.Models.Games;
using System;
using System.Threading;

namespace BoardGamesApp.Services
{
    public class GameEngine
    {
        public GameEngine()
        {
        }

        public void StartGame(BoardGame game)
        {
            Console.Clear(); // Очищаємо екран від меню для чистого логу

            // Перевірка можливості старту гри
            if (!game.CanStart())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[ERROR] Game '{game.Name}' cannot start. Check requirements (players or components)!");
                Console.ResetColor();
                return;
            }

            // Підписка на подію ходу
            game.TurnMade += (player, action) =>
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"[{player.Name}] ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"used action: {action.Description}");
            };

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"=== {game.Name.ToUpper()} STARTED ===");
            Console.ResetColor();
            Console.WriteLine("Simulating gameplay...\n");

            Thread.Sleep(1000);

            Random random = new Random();

            int currentPlayerIndex = 0;

            while (!game.IsFinished)
            {
                // Беремо поточного гравця за його індексом у списку
                var currentPlayer = game.Players[currentPlayerIndex];

                // Випадковий вибір дозволеної дії для конкретної гри
                var allowedActions = game.Rules.AllowedActions;
                Type randomActionType = allowedActions[random.Next(allowedActions.Count)];
                IGameAction action = (IGameAction)Activator.CreateInstance(randomActionType)!;

                // Виконуємо хід
                game.MakeTurn(currentPlayer, action);

                Thread.Sleep(800);

                currentPlayerIndex = (currentPlayerIndex + 1) % game.Players.Count;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n=== GAME OVER ===");
            Console.ResetColor();
        }
    }
}