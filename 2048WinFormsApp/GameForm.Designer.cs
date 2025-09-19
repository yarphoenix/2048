namespace _2048WinFormsApp
{
    partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            ScoreTextLabel = new Label();
            ScoreLabel = new Label();
            SuspendLayout();
            // 
            // ScoreTextLabel
            // 
            resources.ApplyResources(ScoreTextLabel, "ScoreTextLabel");
            ScoreTextLabel.Name = "ScoreTextLabel";
            // 
            // ScoreLabel
            // 
            resources.ApplyResources(ScoreLabel, "ScoreLabel");
            ScoreLabel.Name = "ScoreLabel";
            // 
            // GameForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(ScoreLabel);
            Controls.Add(ScoreTextLabel);
            Name = "GameForm";
            Load += GameForm_Load;
            KeyDown += GameForm_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label ScoreTextLabel;
        private Label ScoreLabel;
    }
}