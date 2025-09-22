namespace _2048ClassLibrary.GameEngine;

/// <summary>Аргументы события изменения доски.</summary>
public class BoardChangedEventArgs(int?[,] board) : EventArgs
{
    public int?[,] Board { get; } = board;
}