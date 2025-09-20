using _2048ClassLibrary;

namespace _2048WinFormsApp;

public partial class ResultsForm : Form
{
    public ResultsForm()
    {
        InitializeComponent();
    }

    private void ResultsForm_Load(object sender, EventArgs e)
    {
        var results = UsersResultStorage.GetUserResults();
        foreach (var result in results)
        {
            ResultsGridView.Rows.Add(result.Name, result.Score);
        }
    }
}