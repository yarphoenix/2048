using System.Drawing.Text;

namespace _2048WinFormsApp
{
    public partial class MainMenuForm : Form
    {
        private PrivateFontCollection _fonts = new();

        public MainMenuForm()
        {
            InitializeComponent();

            _fonts.AddFontFile(Path.Combine(Application.StartupPath, "FoglihtenBlackPcs.ttf"));
            _fonts.AddFontFile(Path.Combine(Application.StartupPath, "Aladdin.ttf"));
            _fonts.AddFontFile(Path.Combine(Application.StartupPath, "a_FuturaRound.ttf"));

            GameNameLabel.Font = new Font(_fonts.Families[2], 46);
            UnderliningLabel.Font = new Font(_fonts.Families[2], 10);
            GameTextLabel.Font = new Font(_fonts.Families[2], 13);

            AuthorLabel.Font = new Font(_fonts.Families[0], 15);

            StartGameButton.Font = new Font(_fonts.Families[1], 15);
            ShowRulesButton.Font = new Font(_fonts.Families[1], 10);
            ShowUsersResultsButton.Font = new Font(_fonts.Families[1], 12);
            QuitButton.Font = new Font(_fonts.Families[1], 12);
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {

        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            Hide();
            var game = new GameForm();
            game.FormClosed += (_, _) => Close();
            game.Show();
        }

        private void ShowUsersResultsButton_Click(object sender, EventArgs e)
        {

        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ShowRulesButton_Click(object sender, EventArgs e)
        {

        }
    }
}
