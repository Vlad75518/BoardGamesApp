using BoardGames.BLL.DTOs;
using BoardGames.BLL.Mappers;
using BoardGames.DAL.UnitOfWork;
using BoardGamesApp.BoardGames.DAL.Entities;

namespace BoardGames.BLL.Services
{
    public class GameSessionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GameSessionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void SaveGameResult(GameSessionDto dto)
        {
            GameSessionEntity entity =
                GameSessionMapper.ToEntity(dto);

            _unitOfWork.Sessions.Add(entity);

            _unitOfWork.Save();
        }
    }
}