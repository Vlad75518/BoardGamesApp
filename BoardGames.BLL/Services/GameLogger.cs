using System;
using System.IO;

namespace BoardGamesApp.BoardGames.BLL.Services
{
    public sealed class GameLogger
    {
        private static readonly GameLogger _instance =
            new GameLogger();

        public static GameLogger Instance => _instance;

        private readonly string _logFilePath;

        private GameLogger()
        {
            _logFilePath = "game.log";
        }

        public void Log(string message)
        {
            string logEntry =
                $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";

            File.AppendAllText(
                _logFilePath,
                logEntry + Environment.NewLine);
        }
    }
}
