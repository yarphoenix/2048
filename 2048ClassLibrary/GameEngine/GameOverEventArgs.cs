namespace _2048ClassLibrary.GameEngine;

/// <summary>Аргументы события конца игры.</summary>
public class GameOverEventArgs(int finalScore) : EventArgs
{
    public int FinalScore { get; } = finalScore;
}