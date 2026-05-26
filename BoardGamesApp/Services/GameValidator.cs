using BoardGamesApp.Models.Games;

namespace BoardGamesApp.Services
{
    public class GameValidator
    {
        public bool Validate(BoardGame game)
        {
            return ValidatePlayers(game)
                && ValidateComponents(game);
        }

        private bool ValidatePlayers(BoardGame game)
        {
            return game.Players.Count >= game.Rules.MinPlayers
                && game.Players.Count <= game.Rules.MaxPlayers;
        }

        private bool ValidateComponents(BoardGame game)
        {
            foreach (var requiredComponent in game.Rules.RequiredComponents)
            {
                bool exists = game.Components
                    .Any(component => component.GetType() == requiredComponent);

                if (!exists)
                {
                    return false;
                }
            }

            return true;
        }
    }
}