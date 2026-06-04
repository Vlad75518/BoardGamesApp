using BoardGamesApp.BoardGames.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BoardGames.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<GameEntity> Games { get; set; }

        public DbSet<PlayerEntity> Players { get; set; }

        public DbSet<GameSessionEntity> GameSessions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=boardgames.db");
        }
    }
}
