namespace _2048WinFormsApp;

public partial class GameForm : Form
{
    private const int MapSize = 4;
    private readonly Random _random;
    private Label[,] _labelsMap;
    private int?[,] _board;
    private int _score;

    private static readonly Font CellFont = new Font("Yu Gothic UI Semibold", 20F, FontStyle.Bold);
    private const int CellSize = 100;
    private const int Gap = 7;

    private enum Direction { Left, Right, Up, Down }

    public GameForm() : this(null) { }

    public GameForm(int? seed)
    {
        InitializeComponent();
        KeyPreview = true;
        _random = seed.HasValue ? new Random(seed.Value) : new Random();
    }

    private void GameForm_Load(object sender, EventArgs e)
    {
        InitBoard();
        InitMap();
        // стандартно - можно сгенерировать 1 или 2 плитки; здесь — 1, но легко поменять
        GenerateNumber();
        ShowScore();
        UpdateUI();
    }

    private void InitBoard()
    {
        _board = new int?[MapSize, MapSize];
        _score = 0;
    }

    private void InitMap()
    {
        _labelsMap = new Label[MapSize, MapSize];

        for (var r = 0; r < MapSize; r++)
        {
            for (var c = 0; c < MapSize; c++)
            {
                var lbl = new Label
                {
                    BackColor = Color.Silver,
                    Font = CellFont,
                    Size = new Size(CellSize, CellSize),
                    TextAlign = ContentAlignment.MiddleCenter,
                };
                lbl.Location = new Point(10 + c * (CellSize + Gap), 40 + r * (CellSize + Gap));
                Controls.Add(lbl);
                _labelsMap[r, c] = lbl;
            }
        }
    }

    private void GenerateNumber()
    {
        var empty = new List<(int r, int c)>();
        for (int r = 0; r < MapSize; r++)
            for (int c = 0; c < MapSize; c++)
                if (!_board[r, c].HasValue)
                    empty.Add((r, c));

        if (empty.Count == 0) return;

        int idx = _random.Next(empty.Count);
        (int row, int col) = empty[idx];
        _board[row, col] = _random.NextDouble() < 0.75 ? 2 : 4;
    }

    private void ShowScore() => ScoreLabel.Text = _score.ToString();

    private void UpdateUI()
    {
        for (var r = 0; r < MapSize; r++)
        {
            for (var c = 0; c < MapSize; c++)
            {
                var lbl = _labelsMap[r, c];
                int? val = _board[r, c];
                TileStyleManager.ApplyStyle(lbl, val, ScoreLabel.Font);
            }
        }
    }

    private void GameForm_KeyDown(object sender, KeyEventArgs e)
    {
        Direction? dir = e.KeyCode switch
        {
            Keys.Left or Keys.A => Direction.Left,
            Keys.Right or Keys.D => Direction.Right,
            Keys.Up or Keys.W => Direction.Up,
            Keys.Down or Keys.S => Direction.Down,
            _ => null
        };

        if (!dir.HasValue) return;

        bool moved = Move(dir.Value);
        if (moved)
        {
            GenerateNumber();
            UpdateUI();
            ShowScore();
        }
    }

    /// <summary>
    /// Универсальный двигатель: извлекает линию в правильном порядке, делает slide+merge, записывает назад.
    /// Возвращает true если произошли изменения.
    /// </summary>
    private new bool Move(Direction dir)
    {
        var moved = false;

        for (var index = 0; index < MapSize; index++)
        {
            var line = new int?[MapSize];
            for (var pos = 0; pos < MapSize; pos++)
            {
                line[pos] = dir switch
                {
                    Direction.Left => _board[index, pos],
                    Direction.Right => _board[index, MapSize - 1 - pos],
                    Direction.Up => _board[pos, index],
                    Direction.Down => _board[MapSize - 1 - pos, index],
                    _ => line[pos]
                };
            }

            (int?[] newLine, int gained) = SlideAndMergeLine(line);
            if (gained > 0) _score += gained;

            for (var pos = 0; pos < MapSize; pos++)
            {
                int r, c;
                switch (dir)
                {
                    case Direction.Left:
                        r = index; c = pos; break;
                    case Direction.Right:
                        r = index; c = MapSize - 1 - pos; break;
                    case Direction.Up:
                        r = pos; c = index; break;
                    case Direction.Down:
                    default:
                        r = MapSize - 1 - pos; c = index; break;
                }

                if (_board[r, c] != newLine[pos])
                {
                    moved = true;
                }
                _board[r, c] = newLine[pos];
            }
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
                i++;
            }
            else
            {
                result.Add(compact[i]);
            }
        }

        while (result.Count < MapSize) result.Add(null);

        return (result.ToArray(), gained);
    }
}
