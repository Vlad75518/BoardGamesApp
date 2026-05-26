using BoardGamesApp.Models.Actions;
using BoardGamesApp.Models.Components;
using BoardGamesApp.Models.Players;
using BoardGamesApp.Models.Rules;

namespace BoardGamesApp.Models.Games
{
    public class ChessGame : BoardGame
    {
        private int _turnCount;

        public ChessGame(
            List<Player> players,
            List<GameComponent> components)
            : base(
                "Chess",
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
                    typeof(ChessFigure)
                },

                AllowedActions = new List<Type>
                {
                    typeof(MoveAction),
                    typeof(CaptureAction)
                }
            };
        }

        public override bool CanStart()
        {
            return true;
        }

        public override void MakeTurn(
            Player player,
            IGameAction action)
        {
            base.MakeTurn(player, action);

            _turnCount++;

            if (_turnCount >= 3)
            {
                FinishGame(player);
            }
        }
    }
}