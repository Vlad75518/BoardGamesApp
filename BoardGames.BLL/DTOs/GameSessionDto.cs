namespace BoardGames.BLL.DTOs
{
    public class GameSessionDto
    {
        public int Id { get; set; }

        public string GameName { get; set; } = string.Empty;

        public string WinnerName { get; set; } = string.Empty;

        public DateTime PlayedAt { get; set; }
    }
}