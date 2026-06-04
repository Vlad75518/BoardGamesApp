using BoardGames.DAL.Repositories;
using BoardGamesApp.BoardGames.DAL.Entities;

namespace BoardGames.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<GameEntity> Games { get; }

        IRepository<PlayerEntity> Players { get; }

        IRepository<GameSessionEntity> Sessions { get; }

        void Save();
    }
}
