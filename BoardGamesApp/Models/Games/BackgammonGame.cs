using BoardGamesApp.Models.Actions;
using BoardGamesApp.Models.Components;
using BoardGamesApp.Models.Players;
using BoardGamesApp.Models.Rules;

namespace BoardGamesApp.Models.Games
{
    public class BackgammonGame : BoardGame
    {
        public BackgammonGame(
            List<Player> players,
            List<GameComponent> components)
            : base(
                "Backgammon",
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
                    typeof(Dice),
                    typeof(Piece)
                },

                AllowedActions = new List<Type>
                {
                    typeof(MoveAction)
                }
            };
        }

        public override bool CanStart()
        {
            return true;
        }
    }
}