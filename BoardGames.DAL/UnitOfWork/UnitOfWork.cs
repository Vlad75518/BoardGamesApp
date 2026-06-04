using BoardGames.DAL.Repositories;
using BoardGamesApp.BoardGames.DAL.Entities;

namespace BoardGames.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IRepository<GameEntity> Games { get; }

        public IRepository<PlayerEntity> Players { get; }

        public IRepository<GameSessionEntity> Sessions { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;

            Games = new Repository<GameEntity>(_context);

            Players = new Repository<PlayerEntity>(_context);

            Sessions = new Repository<GameSessionEntity>(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}