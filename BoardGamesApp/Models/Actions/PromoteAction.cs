namespace BoardGamesApp.Models.Actions
{
    public class PromoteAction : IGameAction
    {
        public string Description => "Promote piece (became a King/Queen)";
        public void Execute() { }
    }
}