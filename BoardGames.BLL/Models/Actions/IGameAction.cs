namespace BoardGamesApp.BoardGames.BLL.Models.Actions;

public interface IGameAction
{
    string Description { get; }

    void Execute();
}