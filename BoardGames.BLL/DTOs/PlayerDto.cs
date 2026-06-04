namespace BoardGames.BLL.DTOs
{
    public class PlayerDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Wins { get; set; }
    }
}