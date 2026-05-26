namespace BoardGamesApp.Models.Players
{
    public class Player
    {
        public string Name { get; }

        public bool IsWinner { get; private set; }

        public event Action<Player>? PlayerWon;

        public Player(string name)
        {
            Name = name;
        }

        public void Win()
        {
            IsWinner = true;

            PlayerWon?.Invoke(this);
        }
    }
}