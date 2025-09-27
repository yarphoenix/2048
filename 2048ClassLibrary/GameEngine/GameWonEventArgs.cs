namespace _2048ClassLibrary.GameEngine;

public class GameWonEventArgs(int score, int value, int row, int col)
    : EventArgs
{
    public int Score { get; } = score;
    public int Value { get; } = value;
    public int Row { get; } = row;
    public int Col { get; } = col;
}