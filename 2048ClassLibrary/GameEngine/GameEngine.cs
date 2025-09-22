namespace _2048ClassLibrary.GameEngine;

public sealed class GameEngine
{
    private readonly Random _random;
    private int?[,]? _board;
    public User User { get; }

    public static int MapSize => 4;

    public GameEngine()
    {
        _random = new Random();
        User = new User();

        InitBoard();
        // Стандартно начинают с двух плиток
        GenerateNumber();
        GenerateNumber();
    }

    private void InitBoard()
    {
        //_board = new int?[MapSize, MapSize];

        _board = new int?[,] { { 2, 4, 8, 16 },
            { 32, 64, 128, 256 }, 
            { 512, 1024, 2048, 2048 * 2 },
            { 2048 * 2 * 2, 2048 * 2 * 2 * 2, 1024, 1024 } };
    }

    /// <summary>
    /// Возвращает копию текущей доски (без возможности изменить внутреннее состояние напрямую).
    /// </summary>
    public int?[,] GetBoardCopy()
    {
        var copy = new int?[MapSize, MapSize];
        if (_board is null) return copy;

        for (var r = 0; r < MapSize; r++)
        for (var c = 0; c < MapSize; c++)
            copy[r, c] = _board[r, c];
        return copy;
    }

    /// <summary>
    /// Сгенерировать одну плитку (2 или 4) в случайной пустой клетке.
    /// Вызывает событие BoardChanged после генерации.
    /// </summary>
    public void GenerateNumber()
    {
        if (_board is null) InitBoard();

        var empty = new List<(int r, int c)>();
        for (var r = 0; r < MapSize; r++)
            for (var c = 0; c < MapSize; c++)
                if (!_board[r, c].HasValue)
                    empty.Add((r, c));

        if (empty.Count == 0) return;

        int idx = _random.Next(empty.Count);
        (int row, int col) = empty[idx];
        _board[row, col] = _random.NextDouble() < 0.75 ? 2 : 4;

        // Уведомляем подписчиков о смене доски
        OnBoardChanged(GetBoardCopy());

        // Если после генерации больше ходов нет — уведомим о конце игры
        if (IsGameOver())
            TriggerGameOver();
    }

    /// <summary>
    /// Универсальный двигатель: извлекает линию в правильном порядке, делает slide+merge, записывает назад.
    /// Возвращает true если произошли изменения.
    /// </summary>
    public bool Move(Direction dir)
    {
        if (_board is null) return false;

        var moved = false;

        for (var index = 0; index < MapSize; index++)
        {
            var line = new int?[MapSize];
            for (var pos = 0; pos < MapSize; pos++)
                line[pos] = dir switch
                {
                    Direction.Left => _board[index, pos],
                    Direction.Right => _board[index, MapSize - 1 - pos],
                    Direction.Up => _board[pos, index],
                    Direction.Down => _board[MapSize - 1 - pos, index],
                    _ => line[pos]
                };

            (int?[] newLine, int gained) = SlideAndMergeLine(line);
            if (gained > 0)
            {
                User.AddScore(gained);
                OnScoreChanged(new ScoreChangedEventArgs(User.Score));
            }

            for (var pos = 0; pos < MapSize; pos++)
            {
                int r, c;
                switch (dir)
                {
                    case Direction.Left:
                        r = index;
                        c = pos;
                        break;
                    case Direction.Right:
                        r = index;
                        c = MapSize - 1 - pos;
                        break;
                    case Direction.Up:
                        r = pos;
                        c = index;
                        break;
                    case Direction.Down:
                    default:
                        r = MapSize - 1 - pos;
                        c = index;
                        break;
                }

                if (_board[r, c] != newLine[pos]) moved = true;
                _board[r, c] = newLine[pos];
            }
        }

        if (moved)
        {
            // Уведомляем, что доска изменилась (перед генерацией нового числа).
            OnBoardChanged(GetBoardCopy());

            // Если нет возможных ходов — уведомим
            if (IsGameOver())
                TriggerGameOver();
        }

        return moved;
    }

    /// <summary>
    /// Выполняет сдвиг влево и объединение на одномерной линии.
    /// Возвращает новую линию и сумму очков, полученных на этом слиянии.
    /// </summary>
    private static (int?[] NewLine, int ScoreGained) SlideAndMergeLine(int?[] line)
    {
        var compact = line.Where(x => x.HasValue).Select(x => x!.Value).ToList();
        var result = new List<int?>(MapSize);
        var gained = 0;

        for (var i = 0; i < compact.Count; i++)
        {
            if (i + 1 < compact.Count && compact[i] == compact[i + 1])
            {
                int merged = compact[i] * 2;
                result.Add(merged);
                gained += merged;
                i++; // пропускаем объединённую плитку
            }
            else
            {
                result.Add(compact[i]);
            }
        }

        while (result.Count < MapSize) result.Add(null);

        return (result.ToArray(), gained);
    }

    /// <summary>
    /// Сбрасывает игру: доска заново, две стартовые плитки, и обнуляет счёт.
    /// </summary>
    public void Reset()
    {
        InitBoard();
        // обнулим счёт (User.Score имеет public setter в вашей реализации)
        User.ResetScore();
        GenerateNumber();
        GenerateNumber();

        OnScoreChanged(new ScoreChangedEventArgs(User.Score));
        OnBoardChanged(GetBoardCopy());
    }

    /// <summary>
    /// Проверяет, закончилась ли игра.
    /// </summary>
    private bool IsGameOver()
    {
        if (_board is null) return true;

        // если есть пустая клетка — можно ходить
        for (var r = 0; r < MapSize; r++)
            for (var c = 0; c < MapSize; c++)
                if (!_board[r, c].HasValue)
                    return false;

        // если есть соседние равные — можно ходить
        for (var r = 0; r < MapSize; r++)
            for (var c = 0; c < MapSize; c++)
            {
                int? value = _board[r, c];

                if (c < MapSize - 1 && value == _board[r, c + 1])
                    return false;

                if (r < MapSize - 1 && value == _board[r + 1, c])
                    return false;
            }

        return true;
    }

    private void TriggerGameOver()
    {
        try
        {
            SaveResults();
        }
        catch (Exception ex)
        {
            // ignored
        }

        OnGameOver(new GameOverEventArgs(User.Score));
    }
    private void SaveResults()
    {
        UsersResultStorage.Append(User);
    }

    #region События

    public event EventHandler<BoardChangedEventArgs>? BoardChanged;
    public event EventHandler<ScoreChangedEventArgs>? ScoreChanged;
    public event EventHandler<GameOverEventArgs>? GameOver;

    private void OnBoardChanged(int?[,] board)
    {
        var handler = BoardChanged;
        handler?.Invoke(this, new BoardChangedEventArgs(board));
    }

    private void OnScoreChanged(ScoreChangedEventArgs args)
    {
        var handler = ScoreChanged;
        handler?.Invoke(this, args);
    }

    private void OnGameOver(GameOverEventArgs args)
    {
        var handler = GameOver;
        handler?.Invoke(this, args);
    }

    #endregion

    public enum Direction
    {
        Left,
        Right,
        Up,
        Down
    }
}