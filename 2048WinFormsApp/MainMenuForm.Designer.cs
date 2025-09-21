namespace _2048WinFormsApp
{
    partial class MainMenuForm
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
            GameNameLabel = new Label();
            UnderliningLabel = new Label();
            GameTextLabel = new Label();
            StartGameButton = new Button();
            AuthorLabel = new Label();
            ShowRulesButton = new Button();
            ShowUsersResultsButton = new Button();
            QuitButton = new Button();
            SuspendLayout();
            // 
            // GameNameLabel
            // 
            GameNameLabel.AutoSize = true;
            GameNameLabel.BackColor = SystemColors.Control;
            GameNameLabel.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 204);
            GameNameLabel.Location = new Point(195, 41);
            GameNameLabel.Name = "GameNameLabel";
            GameNameLabel.Size = new Size(77, 37);
            GameNameLabel.TabIndex = 0;
            GameNameLabel.Text = "2048";
            // 
            // UnderliningLabel
            // 
            UnderliningLabel.AutoSize = true;
            UnderliningLabel.Font = new Font("Segoe UI", 10F);
            UnderliningLabel.Location = new Point(130, 92);
            UnderliningLabel.Name = "UnderliningLabel";
            UnderliningLabel.Size = new Size(519, 19);
            UnderliningLabel.TabIndex = 1;
            UnderliningLabel.Text = "_____________________________________________________________________________________";
            // 
            // GameTextLabel
            // 
            GameTextLabel.AutoSize = true;
            GameTextLabel.ForeColor = Color.Black;
            GameTextLabel.Location = new Point(401, 81);
            GameTextLabel.Name = "GameTextLabel";
            GameTextLabel.Size = new Size(32, 15);
            GameTextLabel.TabIndex = 2;
            GameTextLabel.Text = "игра";
            // 
            // StartGameButton
            // 
            StartGameButton.Location = new Point(229, 125);
            StartGameButton.Name = "StartGameButton";
            StartGameButton.Size = new Size(195, 30);
            StartGameButton.TabIndex = 3;
            StartGameButton.Text = "Начать игру";
            StartGameButton.UseVisualStyleBackColor = true;
            StartGameButton.Click += StartGameButton_Click;
            // 
            // AuthorLabel
            // 
            AuthorLabel.AutoSize = true;
            AuthorLabel.ForeColor = Color.DarkGray;
            AuthorLabel.Location = new Point(536, 228);
            AuthorLabel.Name = "AuthorLabel";
            AuthorLabel.Size = new Size(74, 15);
            AuthorLabel.TabIndex = 4;
            AuthorLabel.Text = "by yarhoenix";
            // 
            // ShowRulesButton
            // 
            ShowRulesButton.Location = new Point(12, 215);
            ShowRulesButton.Name = "ShowRulesButton";
            ShowRulesButton.Size = new Size(134, 36);
            ShowRulesButton.TabIndex = 5;
            ShowRulesButton.Text = "Посмотреть правила";
            ShowRulesButton.UseVisualStyleBackColor = true;
            ShowRulesButton.Click += ShowRulesButton_Click;
            // 
            // ShowUsersResultsButton
            // 
            ShowUsersResultsButton.Location = new Point(162, 161);
            ShowUsersResultsButton.Name = "ShowUsersResultsButton";
            ShowUsersResultsButton.Size = new Size(317, 30);
            ShowUsersResultsButton.TabIndex = 6;
            ShowUsersResultsButton.Text = "Посмотреть историю результатов";
            ShowUsersResultsButton.UseVisualStyleBackColor = true;
            ShowUsersResultsButton.Click += ShowUsersResultsButton_Click;
            // 
            // QuitButton
            // 
            QuitButton.Location = new Point(257, 197);
            QuitButton.Name = "QuitButton";
            QuitButton.Size = new Size(136, 30);
            QuitButton.TabIndex = 7;
            QuitButton.Text = "Выйти";
            QuitButton.UseVisualStyleBackColor = true;
            QuitButton.Click += QuitButton_Click;
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.MenuBar;
            ClientSize = new Size(654, 261);
            Controls.Add(QuitButton);
            Controls.Add(ShowUsersResultsButton);
            Controls.Add(ShowRulesButton);
            Controls.Add(AuthorLabel);
            Controls.Add(StartGameButton);
            Controls.Add(GameTextLabel);
            Controls.Add(UnderliningLabel);
            Controls.Add(GameNameLabel);
            Name = "MainMenuForm";
            Text = "2048";
            Load += MainMenuForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label GameNameLabel;
        private Label UnderliningLabel;
        private Label GameTextLabel;
        private Button StartGameButton;
        private Label AuthorLabel;
        private Button ShowRulesButton;
        private Button ShowUsersResultsButton;
        private Button QuitButton;
    }
}