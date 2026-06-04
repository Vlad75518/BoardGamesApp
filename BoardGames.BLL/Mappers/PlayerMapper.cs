using BoardGames.BLL.DTOs;
using BoardGamesApp.BoardGames.DAL.Entities;

namespace BoardGames.BLL.Mappers
{
    public static class PlayerMapper
    {
        public static PlayerDto ToDto(PlayerEntity entity)
        {
            return new PlayerDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Wins = entity.Wins
            };
        }

        public static PlayerEntity ToEntity(PlayerDto dto)
        {
            return new PlayerEntity
            {
                Id = dto.Id,
                Name = dto.Name,
                Wins = dto.Wins
            };
        }
    }
}
