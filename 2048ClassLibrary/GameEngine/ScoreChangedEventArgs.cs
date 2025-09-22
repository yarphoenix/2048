namespace _2048ClassLibrary.GameEngine;

/// <summary>Аргументы события изменения счёта.</summary>
public class ScoreChangedEventArgs(int newScore) : EventArgs
{
    public int NewScore { get; } = newScore;
}