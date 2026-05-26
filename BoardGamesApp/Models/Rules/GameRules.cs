using BoardGamesApp.Models.Actions;
using System;
using System.Collections.Generic;

namespace BoardGamesApp.Models.Rules;

public class GameRules
{
    public int MinPlayers { get; set; }

    public int MaxPlayers { get; set; }

    public bool OnlyOneActionPerTurn { get; set; }

    public List<Type> RequiredComponents { get; set; } = new();

    public List<Type> AllowedActions { get; set; } = new();
}