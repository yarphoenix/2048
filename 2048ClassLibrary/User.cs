namespace _2048ClassLibrary;

public class User(string name)
{
    private readonly string? _name = name;
    private int _score;

    public void ChangeScore(int value)
    {
        _score += value;
    }
}