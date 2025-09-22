using _2048ClassLibrary.GameEngine;

namespace _2048WinFormsApp
{
    public partial class GameForm : Form
    {
        private const int CellSize = 100;
        private const int Gap = 7;

        private readonly GameEngine _game;

        private static readonly Font CellFont = new("Yu Gothic UI Semibold", 20F, FontStyle.Bold);
        private Label[,] _labelsMap = null!;

        public GameForm()
        {
            InitializeComponent();

            _game = new GameEngine();

            _game.BoardChanged += Game_BoardChanged;
            _game.ScoreChanged += Game_ScoreChanged;
            _game.GameOver += Game_GameOver;
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            InitMap();

            UpdateUIFromBoard(_game.GetBoardCopy());
            ScoreLabel.Text = _game.User.Score.ToString();
        }

        private void InitMap()
        {
            _labelsMap = new Label[GameEngine.MapSize, GameEngine.MapSize];

            for (var r = 0; r < GameEngine.MapSize; r++)
                for (var c = 0; c < GameEngine.MapSize; c++)
                {
                    var lbl = new Label
                    {
                        BackColor = Color.Silver,
                        Font = CellFont,
                        Size = new Size(CellSize, CellSize),
                        TextAlign = ContentAlignment.MiddleCenter
                    };
                    lbl.Location = new Point(10 + c * (CellSize + Gap), 40 + r * (CellSize + Gap));
                    Controls.Add(lbl);
                    _labelsMap[r, c] = lbl;
                }
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            GameEngine.Direction? dir = e.KeyCode switch
            {
                Keys.Left or Keys.A => GameEngine.Direction.Left,
                Keys.Right or Keys.D => GameEngine.Direction.Right,
                Keys.Up or Keys.W => GameEngine.Direction.Up,
                Keys.Down or Keys.S => GameEngine.Direction.Down,
                _ => null
            };

            if (!dir.HasValue) return;

            bool moved = _game.Move(dir.Value);
            if (moved)
            {
                _game.GenerateNumber();
            }
        }

        #region Обработчики событий GameEngine

        private void Game_BoardChanged(object? sender, BoardChangedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke((Action)(() => UpdateUIFromBoard(e.Board)));
            }
            else
            {
                UpdateUIFromBoard(e.Board);
            }
        }

        private void Game_ScoreChanged(object? sender, ScoreChangedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke((Action)(() => ScoreLabel.Text = e.NewScore.ToString()));
            }
            else
            {
                ScoreLabel.Text = e.NewScore.ToString();
            }
        }

        private void Game_GameOver(object? sender, GameOverEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke((Action)(() => HandleGameOver(e.FinalScore)));
            }
            else
            {
                HandleGameOver(e.FinalScore);
            }
        }

        private void HandleGameOver(int finalScore)
        {
            var result = MessageBox.Show(
                $"""
                 Игра окончена! Счёт: {finalScore}
                 Хотите начать заново?
                 """,
                @"Game Over",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _game.Reset();
            }
        }

        #endregion

        private void UpdateUIFromBoard(int?[,] board)
        {
            for (var r = 0; r < GameEngine.MapSize; r++)
                for (var c = 0; c < GameEngine.MapSize; c++)
                {
                    int? val = board[r, c];
                    var lbl = _labelsMap[r, c];
                    TileStyleManager.ApplyStyle(lbl, val, ScoreLabel.Font);
                }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            _game.BoardChanged -= Game_BoardChanged;
            _game.ScoreChanged -= Game_ScoreChanged;
            _game.GameOver -= Game_GameOver;
        }
    }
}