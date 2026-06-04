using BoardGamesApp.BoardGames.BLL.Models.Actions;
using BoardGamesApp.BoardGames.BLL.Models.Components;
using BoardGamesApp.BoardGames.BLL.Models.Players;
using BoardGamesApp.BoardGames.BLL.Models.Rules;

namespace BoardGamesApp.BoardGames.BLL.Models.Games
{
    public class MonopolyGame : BoardGame
    {
        public MonopolyGame(
            List<Player> players,
            List<GameComponent> components)
            : base(
                "Monopoly",
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
                MaxPlayers = 6,
                OnlyOneActionPerTurn = true,

                RequiredComponents = new List<Type>
                {
                    typeof(Board),
                    typeof(Dice),
                    typeof(Piece)
                },

                AllowedActions = new List<Type>
                {
                    typeof(RollDiceAction), // Монополія починається з кубиків
                    typeof(MoveAction),
                    typeof(BuyAction),
                    typeof(SellAction),
                    typeof(PayRentAction),
                    typeof(DrawCardAction)
                }
            };
        }
    }
}