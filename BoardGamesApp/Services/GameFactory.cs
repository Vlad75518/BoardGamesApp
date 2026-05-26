using BoardGamesApp.Models.Components;
using BoardGamesApp.Models.Enums;
using BoardGamesApp.Models.Games;
using BoardGamesApp.Models.Players;

namespace BoardGamesApp.Services
{
    public class GameFactory
    {
        public BoardGame CreateGame(
            GameType gameType,
            List<Player> players)
        {
            switch (gameType)
            {
                case GameType.Chess:
                    return new ChessGame(
                        players,
                        new List<GameComponent>
                        {
                            new Board(),
                            new ChessFigure()
                        });

                case GameType.Monopoly:
                    return new MonopolyGame(
                        players,
                        new List<GameComponent>
                        {
                            new Board(),
                            new Dice(),
                            new Piece("Player Piece")
                        });

                case GameType.Checkers:
                    return new CheckersGame(
                        players,
                        new List<GameComponent>
                        {
                            new Board(),
                            new Checker()
                        });

                case GameType.Backgammon:
                    return new BackgammonGame(
                        players,
                        new List<GameComponent>
                        {
                            new Board(),
                            new Dice(),
                            new Piece("Backgammon Piece")
                        });

                default:
                    throw new ArgumentException(
                        "Invalid game choice.");
            }
        }
    }
}