using System.Drawing.Text;

namespace _2048WinFormsApp
{
    public partial class RulesForm : Form
    {
        private readonly PrivateFontCollection _fonts = new();

        public RulesForm()
        {
            InitializeComponent();

            _fonts.AddFontFile(Path.Combine(Application.StartupPath, "a_FuturaRound.ttf"));
            _fonts.AddFontFile(Path.Combine(Application.StartupPath, "FoglihtenBlackPcs.ttf"));

            HowToPlayLabel.Font = new Font(_fonts.Families[1], 32, FontStyle.Bold);
            UnderliningLabel.Font = new Font(_fonts.Families[1], 10);

            FirstRuleNumberLabel.Font = new Font(_fonts.Families[0], 28, FontStyle.Bold);
            FirstRuleTextHeaderLabel.Font = new Font(_fonts.Families[0], 20, FontStyle.Bold);
            FirstRuleTextContentLabel.Font = new Font(_fonts.Families[0], 15);

            SecondRuleNumberLabel.Font = new Font(_fonts.Families[0], 28, FontStyle.Bold);
            SecondRuleTextHeaderLabel.Font = new Font(_fonts.Families[0], 20, FontStyle.Bold);
            SecondRuleTextContentLabel.Font = new Font(_fonts.Families[0], 15);

            ThirdRuleNumberLabel.Font = new Font(_fonts.Families[0], 28, FontStyle.Bold);
            ThirdRuleTextHeaderLabel.Font = new Font(_fonts.Families[0], 20, FontStyle.Bold);
            ThirdRuleTextContentLabel.Font = new Font(_fonts.Families[0], 15);
        }
    }
}
