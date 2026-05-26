using BoardGamesApp.Models.Actions;
using BoardGamesApp.Models.Games;
using System;
using System.Threading; // Додано для Thread.Sleep

namespace BoardGamesApp.Services
{
    public class GameEngine
    {
        private readonly TurnManager _turnManager;
        private readonly GameValidator _validator;

        public GameEngine()
        {
            _turnManager = new TurnManager();
            _validator = new GameValidator();
        }

        public void StartGame(BoardGame game)
        {
            Console.Clear(); // Очищаємо екран від меню для чистого логу

            // Перевірка правил
            if (!_validator.Validate(game) || !game.CanStart())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[ERROR] Game '{game.Name}' cannot start. Check components and players!");
                Console.ResetColor();
                return;
            }

            // Підписка на подію ходу (вимога викладача: вивід за межами логіки гри)
            game.TurnMade += (player, action) =>
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"[{player.Name}] ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"used action: {action.Description}");
            };

            // Гарний старт
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"=== {game.Name.ToUpper()} STARTED ===");
            Console.ResetColor();
            Console.WriteLine("Simulating gameplay...\n");

            Thread.Sleep(1000); // Пауза перед початком симуляції

            Random random = new Random();

            while (!game.IsFinished)
            {
                var currentPlayer = _turnManager.GetCurrentPlayer(game.Players);

                // Динамічно беремо випадкову дію з дозволених для цієї гри
                var allowedActions = game.Rules.AllowedActions;
                Type randomActionType = allowedActions[random.Next(allowedActions.Count)];
                IGameAction action = (IGameAction)Activator.CreateInstance(randomActionType)!;

                // Робимо хід
                game.MakeTurn(currentPlayer, action);

                // Затримка на 800 мілісекунд, щоб було видно процес гри
                Thread.Sleep(800);

                // Перехід ходу до наступного
                _turnManager.NextTurn(game.Players);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n=== GAME OVER ===");
            Console.ResetColor();
        }
    }
}