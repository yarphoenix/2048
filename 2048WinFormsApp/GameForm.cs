namespace _2048WinFormsApp;

public partial class GameForm : Form
{
    private const int MapSize = 4;

    private readonly Random _random;
    private Label[,] _labelsMap;
    private int _score;

    public GameForm() : this(null)
    {
    }

    public GameForm(int? seed)
    {
        InitializeComponent();
        _random = seed.HasValue ? new Random(seed.Value) : new Random();
    }

    private void GameForm_Load(object sender, EventArgs e)
    {
        InitMap();
        GenerateNumber();
        ShowScore();
    }

    private void ShowScore()
    {
        ScoreLabel.Text = _score.ToString();
    }

    private void InitMap()
    {
        _labelsMap = new Label[MapSize, MapSize];

        for (var i = 0; i < MapSize; i++)
        {
            for (var j = 0; j < MapSize; j++)
            {
                var newLabel = CreateLabel(i, j);
                Controls.Add(newLabel);
                _labelsMap[i, j] = newLabel;
            }
        }
    }

    private void GenerateNumber()
    {
        var emptyCells = new List<(int Row, int Col)>();

        for (var r = 0; r < MapSize; r++)
        {
            for (var c = 0; c < MapSize; c++)
            {
                if (string.IsNullOrEmpty(_labelsMap[r, c].Text))
                {
                    emptyCells.Add((r, c));
                }
            }
        }

        if (emptyCells.Count == 0)
        {
            return;
        }

        int chosenIndex = _random.Next(emptyCells.Count);
        var (row, column) = emptyCells[chosenIndex];

        int value = _random.NextDouble() < 0.9 ? 2 : 4;
        _labelsMap[row, column].Text = value.ToString();
    }

    private static Label CreateLabel(int row, int column)
    {
        var label = new Label();
        label.BackColor = Color.Silver;
        label.Font = new Font("Yu Gothic UI Semibold", 20F, FontStyle.Bold);
        label.Size = new Size(100, 100);
        label.TextAlign = ContentAlignment.MiddleCenter;
        int x = 10 + column * 107;
        int y = 40 + row * 107;
        label.Location = new Point(x, y);

        return label;
    }

    private void GameForm_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode is Keys.Right or Keys.D)
        {
            for (var i = 0; i < MapSize; i++)
            {
                for (int j = MapSize - 1; j >= 0; j--)
                {
                    if (!string.IsNullOrEmpty(_labelsMap[i, j].Text))
                    {
                        for (int k = j - 1; k >= 0; k--)
                        {
                            if (!string.IsNullOrEmpty(_labelsMap[i, k].Text))
                            {
                                if (_labelsMap[i, j].Text == _labelsMap[i, k].Text)
                                {
                                    int newValue = int.Parse(_labelsMap[i, j].Text) * 2;
                                    _score += newValue;
                                    _labelsMap[i, j].Text = newValue.ToString();
                                    _labelsMap[i, k].Text = string.Empty;
                                }
                                break;
                            }
                        }
                    }
                }
            }

            for (var i = 0; i < MapSize; i++)
            {
                for (int j = MapSize - 1; j >= 0; j--)
                {
                    if (string.IsNullOrEmpty(_labelsMap[i, j].Text))
                    {
                        for (int k = j - 1; k >= 0; k--)
                        {
                            if (!string.IsNullOrEmpty(_labelsMap[i, k].Text))
                            {
                                _labelsMap[i, j].Text = _labelsMap[i, k].Text;
                                _labelsMap[i, k].Text = string.Empty;
                                break;
                            }
                        }
                    }
                }
            }
        }
        if (e.KeyCode is Keys.Up or Keys.W)
        {
            for (var j = 0; j < MapSize; j++)
            { 
                for (var i = 0; i < MapSize; i++)
                {
                    if (!string.IsNullOrEmpty(_labelsMap[i, j].Text))
                    {
                        for (int k = i + 1; k < MapSize; k++)
                        {
                            if (!string.IsNullOrEmpty(_labelsMap[k, j].Text))
                            {
                                if (_labelsMap[i, j].Text == _labelsMap[k, j].Text)
                                {
                                    int newValue = int.Parse(_labelsMap[i, j].Text) * 2;
                                    _score += newValue;
                                    _labelsMap[i, j].Text = newValue.ToString();
                                    _labelsMap[k, j].Text = string.Empty;
                                }
                                break;
                            }
                        }
                    }
                }
            }

            for (var j = 0; j < MapSize; j++)
            {
                for (var i = 0; i < MapSize; i++)
                {
                    if (string.IsNullOrEmpty(_labelsMap[i, j].Text))
                    {
                        for (int k = i + 1; k < MapSize; k++)
                        {
                            if (!string.IsNullOrEmpty(_labelsMap[k, j].Text))
                            {
                                _labelsMap[i, j].Text = _labelsMap[k, j].Text;
                                _labelsMap[k, j].Text = string.Empty;
                                break;
                            }
                        }
                    }
                }
            }
        }
        if (e.KeyCode is Keys.Left or Keys.A)
        {
            for (var i = 0; i < MapSize; i++)
            {
                for (var j = 0; j < MapSize; j++)
                {
                    if (!string.IsNullOrEmpty(_labelsMap[i, j].Text))
                    {
                        for (int k = j + 1; k < MapSize; k++)
                        {
                            if (!string.IsNullOrEmpty(_labelsMap[i, k].Text))
                            {
                                if (_labelsMap[i, j].Text == _labelsMap[i, k].Text)
                                {
                                    int newValue = int.Parse(_labelsMap[i, j].Text) * 2;
                                    _score += newValue;
                                    _labelsMap[i, j].Text = newValue.ToString();
                                    _labelsMap[i, k].Text = string.Empty;
                                }
                                break;
                            }
                        }
                    }
                }
            }

            for (var i = 0; i < MapSize; i++)
            {
                for (var j = 0; j < MapSize; j++)
                {
                    if (string.IsNullOrEmpty(_labelsMap[i, j].Text))
                    {
                        for (int k = j + 1; k < MapSize; k++)
                        {
                            if (!string.IsNullOrEmpty(_labelsMap[i, k].Text))
                            {
                                _labelsMap[i, j].Text = _labelsMap[i, k].Text;
                                _labelsMap[i, k].Text = string.Empty;
                                break;
                            }
                        }
                    }
                }
            }
        }
        if (e.KeyCode is Keys.Down or Keys.S)
        {
            for (var j = 0; j < MapSize; j++)
            {
                for (int i = MapSize - 1; i >= 0; i--)
                {
                    if (!string.IsNullOrEmpty(_labelsMap[i, j].Text))
                    {
                        for (int k = i - 1; k >= 0; k--)
                        {
                            if (!string.IsNullOrEmpty(_labelsMap[k, j].Text))
                            {
                                if (_labelsMap[i, j].Text == _labelsMap[k, j].Text)
                                {
                                    int newValue = int.Parse(_labelsMap[i, j].Text) * 2;
                                    _score += newValue;
                                    _labelsMap[i, j].Text = newValue.ToString();
                                    _labelsMap[k, j].Text = string.Empty;
                                }
                                break;
                            }
                        }
                    }
                }
            }

            for (var j = 0; j < MapSize; j++)
            {
                for (int i = MapSize - 1; i >= 0; i--)
                {
                    if (string.IsNullOrEmpty(_labelsMap[i, j].Text))
                    {
                        for (int k = i - 1; k >= 0; k--)
                        {
                            if (!string.IsNullOrEmpty(_labelsMap[k, j].Text))
                            {
                                _labelsMap[i, j].Text = _labelsMap[k, j].Text;
                                _labelsMap[k, j].Text = string.Empty;
                                break;
                            }
                        }
                    }
                }
            }
        }

        GenerateNumber();
        ShowScore();
    }
}