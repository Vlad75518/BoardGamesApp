using BoardGames.BLL.DTOs;
using BoardGamesApp.BoardGames.DAL.Entities;

namespace BoardGames.BLL.Mappers
{
    public static class GameMapper
    {
        public static GameDto ToDto(GameEntity entity)
        {
            return new GameDto
            {
                Id = entity.Id,
                Name = entity.Name,
                MinPlayers = entity.MinPlayers,
                MaxPlayers = entity.MaxPlayers
            };
        }

        public static GameEntity ToEntity(GameDto dto)
        {
            return new GameEntity
            {
                Id = dto.Id,
                Name = dto.Name,
                MinPlayers = dto.MinPlayers,
                MaxPlayers = dto.MaxPlayers
            };
        }
    }
}