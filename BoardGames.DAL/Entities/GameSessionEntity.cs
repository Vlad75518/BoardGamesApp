using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGamesApp.BoardGames.DAL.Entities
{
    public class GameSessionEntity
    {
        public int Id { get; set; }

        public string GameName { get; set; } = string.Empty;

        public string WinnerName { get; set; } = string.Empty;

        public DateTime PlayedAt { get; set; }
    }
}
