using BoardGamesApp.BoardGames.BLL.Models.Actions;
using BoardGamesApp.BoardGames.BLL.Models.Games;

namespace BoardGamesApp.BoardGames.BLL.Services
{
    public class GameEngine
    {
        public void StartGame(BoardGame game)
        {
            if (!game.CanStart())
            {
                throw new InvalidOperationException(
                    $"Game '{game.Name}' cannot start.");
            }

            Random random = new Random();

            int currentPlayerIndex = 0;

            while (!game.IsFinished)
            {
                var currentPlayer =
                    game.Players[currentPlayerIndex];

                var allowedActions =
                    game.Rules.AllowedActions;

                Type randomActionType =
                    allowedActions[random.Next(allowedActions.Count)];

                IGameAction action =
                    (IGameAction)Activator.CreateInstance(randomActionType)!;

                game.MakeTurn(currentPlayer, action);

                Thread.Sleep(800);

                currentPlayerIndex =
                    (currentPlayerIndex + 1) %
                    game.Players.Count;
            }
        }
    }
}
