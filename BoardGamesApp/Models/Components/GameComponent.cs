namespace BoardGamesApp.Models.Components;

public abstract class GameComponent
{
    public string Name { get; }

    protected GameComponent(string name)
    {
        Name = name;
    }
}