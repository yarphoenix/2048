namespace _2048ClassLibrary;

public class User(string name = "Аноним")
{
    public string? Name { get; } = name;

    public int Score { get; private set; }

    public void AddScore(int amount)
    {
        if (amount < 0)
            throw new ArgumentException("Нельзя уменьшать очки.");
        Score += amount;
    }

    public void ResetScore()
    {
        Score = 0;
    }
}