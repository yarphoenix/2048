namespace _2048ClassLibrary;

public class User(string name = "Аноним")
{
    private readonly string? _name = name;
    private int _score;

    public string? Name => _name;

    public int Score
    {
        get => _score;
        set
        {
            if (value < _score)
                throw new InvalidOperationException("Score можно только увеличивать.");
            _score = value;
        }
    }

    public void AddScore(int amount)
    {
        if (amount < 0)
            throw new ArgumentException("Нельзя уменьшать очки.");
        _score += amount;
    }
}