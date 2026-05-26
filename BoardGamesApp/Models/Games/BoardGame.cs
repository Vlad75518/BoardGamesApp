using BoardGamesApp.Models.Actions;
using BoardGamesApp.Models.Components;
using BoardGamesApp.Models.Players;
using BoardGamesApp.Models.Rules;

namespace BoardGamesApp.Models.Games
{
    public abstract class BoardGame
    {
        public string Name { get; }

        public List<Player> Players { get; }

        public List<GameComponent> Components { get; }

        public GameRules Rules { get; }

        public bool IsStarted { get; protected set; }

        public bool IsFinished { get; protected set; }

        public Player? Winner { get; protected set; }

        protected BoardGame(
            string name,
            List<Player> players,
            List<GameComponent> components,
            GameRules rules)
        {
            Name = name;
            Players = players;
            Components = components;
            Rules = rules;
        }

        public abstract bool CanStart();

        public virtual void MakeTurn(
            Player player,
            IGameAction action)
        {
            bool isAllowed =
                Rules.AllowedActions.Contains(action.GetType());

            if (!isAllowed)
            {
                throw new InvalidOperationException(
                    "This action is not allowed in this game.");
            }

            action.Execute();
        }

        protected void FinishGame(Player winner)
        {
            Winner = winner;

            IsFinished = true;

            winner.Win();
        }
    }
}