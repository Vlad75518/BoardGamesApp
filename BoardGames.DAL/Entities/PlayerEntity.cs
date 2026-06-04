using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGamesApp.BoardGames.DAL.Entities
{
    public class PlayerEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Wins { get; set; }
    }
}