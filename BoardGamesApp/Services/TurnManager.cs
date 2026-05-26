using BoardGamesApp.Models.Players;

namespace BoardGamesApp.Services
{
    public class TurnManager
    {
        private int _currentPlayerIndex;

        public Player GetCurrentPlayer(List<Player> players)
        {
            return players[_currentPlayerIndex];
        }

        public void NextTurn(List<Player> players)
        {
            _currentPlayerIndex++;

            if (_currentPlayerIndex >= players.Count)
            {
                _currentPlayerIndex = 0;
            }
        }
    }
}