using BoardGames.BLL.DTOs;
using BoardGamesApp.BoardGames.DAL.Entities;

namespace BoardGames.BLL.Mappers
{
    public static class GameSessionMapper
    {
        public static GameSessionDto ToDto(GameSessionEntity entity)
        {
            return new GameSessionDto
            {
                Id = entity.Id,
                GameName = entity.GameName,
                WinnerName = entity.WinnerName,
                PlayedAt = entity.PlayedAt
            };
        }

        public static GameSessionEntity ToEntity(GameSessionDto dto)
        {
            return new GameSessionEntity
            {
                Id = dto.Id,
                GameName = dto.GameName,
                WinnerName = dto.WinnerName,
                PlayedAt = dto.PlayedAt
            };
        }
    }
}