namespace _2048WinFormsApp
{
    public partial class RulesForm : Form
    {
        public RulesForm()
        {
            InitializeComponent();

            HowToPlayLabel.Font = new Font(FontCollection.FoglihtenBlackPcs, 32, FontStyle.Bold);
            UnderliningLabel.Font = new Font(FontCollection.FoglihtenBlackPcs, 10);

            FirstRuleNumberLabel.Font = new Font(FontCollection.AFuturaRound, 28, FontStyle.Bold);
            FirstRuleTextHeaderLabel.Font = new Font(FontCollection.AFuturaRound, 20, FontStyle.Bold);
            FirstRuleTextContentLabel.Font = new Font(FontCollection.AFuturaRound, 15);

            SecondRuleNumberLabel.Font = new Font(FontCollection.AFuturaRound, 28, FontStyle.Bold);
            SecondRuleTextHeaderLabel.Font = new Font(FontCollection.AFuturaRound, 20, FontStyle.Bold);
            SecondRuleTextContentLabel.Font = new Font(FontCollection.AFuturaRound, 15);

            ThirdRuleNumberLabel.Font = new Font(FontCollection.AFuturaRound, 28, FontStyle.Bold);
            ThirdRuleTextHeaderLabel.Font = new Font(FontCollection.AFuturaRound, 20, FontStyle.Bold);
            ThirdRuleTextContentLabel.Font = new Font(FontCollection.AFuturaRound, 15);
        }
    }
}
