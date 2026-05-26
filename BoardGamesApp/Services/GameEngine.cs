using BoardGamesApp.Models.Actions;
using BoardGamesApp.Models.Games;
using BoardGamesApp.Services;

namespace BoardGamesApp.Services
{
    public class GameEngine
    {
        private readonly TurnManager _turnManager;
        private readonly GameValidator _validator;

        public GameEngine()
        {
            _turnManager = new TurnManager();
            _validator = new GameValidator();
        }

        public void StartGame(BoardGame game)
        {
            if (!_validator.Validate(game))
            {
                Console.WriteLine("Game cannot start.");

                return;
            }

            Console.WriteLine($"{game.Name} started!");

            while (!game.IsFinished)
            {
                var currentPlayer =
                    _turnManager.GetCurrentPlayer(game.Players);

                Console.WriteLine(
                    $"Current player: {currentPlayer.Name}");

                IGameAction action = new MoveAction();

                game.MakeTurn(currentPlayer, action);

                Console.WriteLine(
                    $"{currentPlayer.Name} used action: {action.Description}");

                _turnManager.NextTurn(game.Players);
            }

            Console.WriteLine("Game finished!");
        }
    }
}