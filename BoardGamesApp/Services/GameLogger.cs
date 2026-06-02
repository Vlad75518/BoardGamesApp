using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGamesApp.Services
{
    public sealed class GameLogger
    {
        private static readonly GameLogger _instance =
            new GameLogger();

        public static GameLogger Instance
            => _instance;

        private GameLogger()
        {
        }

        public void Log(string message)
        {
            Console.WriteLine(
                $"[LOG] {message}");
        }
    }
}
