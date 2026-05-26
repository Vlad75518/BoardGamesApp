using BoardGamesApp.Models.Actions;
using BoardGamesApp.Models.Components;
using BoardGamesApp.Models.Players;
using BoardGamesApp.Models.Rules;

namespace BoardGamesApp.Models.Games
{
    public abstract class BoardGame
    {
        public event Action<Player, IGameAction>? TurnMade;
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

        public virtual bool CanStart()
        {
            // Перевірка кількості гравців
            if (Players.Count < Rules.MinPlayers || Players.Count > Rules.MaxPlayers)
                return false;

            // Перевірка наявності всіх необхідних компонентів
            foreach (var requiredType in Rules.RequiredComponents)
            {
                if (!Components.Any(c => c.GetType() == requiredType))
                    return false;
            }

            // Перевірка, що немає "зайвих" компонентів
            if (Components.Count != Rules.RequiredComponents.Count)
                return false;

            return true;
        }

        public virtual void MakeTurn(Player player, IGameAction action)
        {
            bool isAllowed = Rules.AllowedActions.Contains(action.GetType());
            if (!isAllowed)
            {
                throw new InvalidOperationException("This action is not allowed in this game.");
            }

            action.Execute();
            TurnMade?.Invoke(player, action);

            // СИМУЛЯЦІЯ: З ймовірністю 15% гравець перемагає на цьому ході
            Random rnd = new Random();
            if (rnd.Next(1, 100) <= 15)
            {
                FinishGame(player);
                player.Win(); // Викликаємо подію перемоги у гравця
            }
        }

        protected void FinishGame(Player winner)
        {
            Winner = winner;

            IsFinished = true;

            winner.Win();
        }
    }
}