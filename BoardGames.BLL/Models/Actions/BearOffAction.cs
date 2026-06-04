namespace BoardGamesApp.BoardGames.BLL.Models.Actions
{
    public class BearOffAction : IGameAction
    {
        public string Description => "Bear Off (remove piece from board)";
        public void Execute() { }
    }
}