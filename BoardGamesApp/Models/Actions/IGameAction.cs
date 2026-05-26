namespace BoardGamesApp.Models.Actions;

public interface IGameAction
{
    string Description { get; }

    void Execute();
}