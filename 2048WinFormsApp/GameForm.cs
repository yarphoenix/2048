using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048WinFormsApp
{
    public partial class GameForm : Form
    {
        private const int MapSize = 4;

        private static readonly Random Random = new();

        private Label[,] _labelsMap;

        public GameForm()
        {
            InitializeComponent();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            InitMap();
            GenerateNumber();
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
            int randomNumberLabel = Random.Next(MapSize * MapSize);
            int row = randomNumberLabel / MapSize;
            int column = randomNumberLabel % MapSize;
            if (_labelsMap[row, column].Text == string.Empty)
            {
                // 2 или 4
                _labelsMap[row, column].Text = "2";
            }
        }


        private static Label CreateLabel(int row, int column)
        {
            var label = new Label();
            label.BackColor = Color.Silver;
            label.Font = new Font("Yu Gothic UI Semibold", 20F, FontStyle.Bold);
            label.Size = new Size(100, 100);
            label.TextAlign = ContentAlignment.MiddleCenter;
            int x = 10 + column * 107;
            int y = 10 + row * 107;
            label.Location = new Point(x, y);

            return label;
        }
    }
}
