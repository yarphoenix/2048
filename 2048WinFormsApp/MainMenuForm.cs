using System.Drawing.Text;

namespace _2048WinFormsApp;

public partial class MainMenuForm : Form
{
    public MainMenuForm()
    {
        InitializeComponent();

        GameNameLabel.Font = new Font(FontCollection.FoglihtenBlackPcs, 46);
        UnderliningLabel.Font = new Font(FontCollection.FoglihtenBlackPcs, 10);
        GameTextLabel.Font = new Font(FontCollection.FoglihtenBlackPcs, 13);

        AuthorLabel.Font = new Font(FontCollection.Aladdin, 15);

        StartGameButton.Font = new Font(FontCollection.AFuturaRound, 14);
        ShowRulesButton.Font = new Font(FontCollection.AFuturaRound, 10);
        ShowUsersResultsButton.Font = new Font(FontCollection.AFuturaRound, 12);
        QuitButton.Font = new Font(FontCollection.AFuturaRound, 12);
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
        var resultsForm = new ResultsForm();
        resultsForm.ShowDialog();
    }

    private void QuitButton_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void ShowRulesButton_Click(object sender, EventArgs e)
    {
        var rulesForm = new RulesForm();
        rulesForm.ShowDialog();
    }
}