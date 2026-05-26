using BoardGamesApp.Models.Actions;
using BoardGamesApp.Models.Components;
using BoardGamesApp.Models.Players;
using BoardGamesApp.Models.Rules;

namespace BoardGamesApp.Models.Games
{
    public class CheckersGame : BoardGame
    {
        public CheckersGame(
            List<Player> players,
            List<GameComponent> components)
            : base(
                "Checkers",
                players,
                components,
                CreateRules())
        {
        }

        private static GameRules CreateRules()
        {
            return new GameRules
            {
                MinPlayers = 2,
                MaxPlayers = 2,
                OnlyOneActionPerTurn = true,

                RequiredComponents = new List<Type>
                {
                    typeof(Board),
                    typeof(Checker)
                },

                AllowedActions = new List<Type>
                {
                    typeof(MoveAction),
                    typeof(CaptureAction),
                    typeof(PromoteAction)
                }
            };
        }
    }
}