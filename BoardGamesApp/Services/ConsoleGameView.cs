using BoardGamesApp.Models.Actions;
using BoardGamesApp.Models.Players;

namespace BoardGamesApp.Services
{
    public class ConsoleGameView
    {
        public void ShowGameStarted(string gameName)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"=== {gameName.ToUpper()} STARTED ===");
            Console.ResetColor();

            Console.WriteLine("Simulating gameplay...\n");
        }

        public void ShowTurn(Player player, IGameAction action)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"[{player.Name}] ");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"used action: {action.Description}");

            Console.ResetColor();
        }

        public void ShowWinner(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"\n🏆 {player.Name} won the game!");
            Console.ResetColor();
        }

        public void ShowGameOver()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n=== GAME OVER ===");
            Console.ResetColor();
        }

        public void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
