namespace _2048WinFormsApp
{
    partial class RulesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RulesForm));
            HowToPlayLabel = new Label();
            FirstRuleNumberLabel = new Label();
            FirstRuleTextHeaderLabel = new Label();
            FirstRuleTextContentLabel = new Label();
            UnderliningLabel = new Label();
            SecondRuleNumberLabel = new Label();
            SecondRuleTextHeaderLabel = new Label();
            SecondRuleTextContentLabel = new Label();
            SecondRulePictureBox = new PictureBox();
            ThirdRuleNumberLabel = new Label();
            ThirdRuleTextHeaderLabel = new Label();
            ThirdRuleTextContentLabel = new Label();
            ThirdRulePictureBox1 = new PictureBox();
            FirstRulePictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)SecondRulePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ThirdRulePictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)FirstRulePictureBox).BeginInit();
            SuspendLayout();
            // 
            // HowToPlayLabel
            // 
            HowToPlayLabel.Dock = DockStyle.Top;
            HowToPlayLabel.Font = new Font("Segoe UI", 32F);
            HowToPlayLabel.Location = new Point(0, 0);
            HowToPlayLabel.Name = "HowToPlayLabel";
            HowToPlayLabel.Size = new Size(939, 142);
            HowToPlayLabel.TabIndex = 0;
            HowToPlayLabel.Text = "Как играть в 2048?";
            HowToPlayLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FirstRuleNumberLabel
            // 
            FirstRuleNumberLabel.Font = new Font("Segoe UI", 28F);
            FirstRuleNumberLabel.ForeColor = Color.Coral;
            FirstRuleNumberLabel.Location = new Point(0, 111);
            FirstRuleNumberLabel.Name = "FirstRuleNumberLabel";
            FirstRuleNumberLabel.Size = new Size(800, 51);
            FirstRuleNumberLabel.TabIndex = 1;
            FirstRuleNumberLabel.Text = "1";
            FirstRuleNumberLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FirstRuleTextHeaderLabel
            // 
            FirstRuleTextHeaderLabel.Font = new Font("Segoe UI", 20F);
            FirstRuleTextHeaderLabel.Location = new Point(0, 163);
            FirstRuleTextHeaderLabel.Name = "FirstRuleTextHeaderLabel";
            FirstRuleTextHeaderLabel.Size = new Size(800, 37);
            FirstRuleTextHeaderLabel.TabIndex = 2;
            FirstRuleTextHeaderLabel.Text = "Соединяйте плитки";
            FirstRuleTextHeaderLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FirstRuleTextContentLabel
            // 
            FirstRuleTextContentLabel.Font = new Font("Segoe UI", 15F);
            FirstRuleTextContentLabel.Location = new Point(0, 195);
            FirstRuleTextContentLabel.Name = "FirstRuleTextContentLabel";
            FirstRuleTextContentLabel.Size = new Size(800, 120);
            FirstRuleTextContentLabel.TabIndex = 3;
            FirstRuleTextContentLabel.Text = resources.GetString("FirstRuleTextContentLabel.Text");
            FirstRuleTextContentLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UnderliningLabel
            // 
            UnderliningLabel.AutoSize = true;
            UnderliningLabel.Font = new Font("Segoe UI", 10F);
            UnderliningLabel.Location = new Point(84, 84);
            UnderliningLabel.Name = "UnderliningLabel";
            UnderliningLabel.Size = new Size(855, 19);
            UnderliningLabel.TabIndex = 5;
            UnderliningLabel.Text = "_____________________________________________________________________________________________________________________________________________";
            // 
            // SecondRuleNumberLabel
            // 
            SecondRuleNumberLabel.Font = new Font("Segoe UI", 28F);
            SecondRuleNumberLabel.ForeColor = Color.OrangeRed;
            SecondRuleNumberLabel.Location = new Point(0, 576);
            SecondRuleNumberLabel.Name = "SecondRuleNumberLabel";
            SecondRuleNumberLabel.Size = new Size(800, 51);
            SecondRuleNumberLabel.TabIndex = 6;
            SecondRuleNumberLabel.Text = "2";
            SecondRuleNumberLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SecondRuleTextHeaderLabel
            // 
            SecondRuleTextHeaderLabel.Font = new Font("Segoe UI", 20F);
            SecondRuleTextHeaderLabel.Location = new Point(0, 622);
            SecondRuleTextHeaderLabel.Name = "SecondRuleTextHeaderLabel";
            SecondRuleTextHeaderLabel.Size = new Size(800, 76);
            SecondRuleTextHeaderLabel.TabIndex = 8;
            SecondRuleTextHeaderLabel.Text = "Комбинируйте плитки\r\nс преимущественно маленькими числами";
            SecondRuleTextHeaderLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SecondRuleTextContentLabel
            // 
            SecondRuleTextContentLabel.Font = new Font("Segoe UI", 15F);
            SecondRuleTextContentLabel.Location = new Point(0, 694);
            SecondRuleTextContentLabel.Name = "SecondRuleTextContentLabel";
            SecondRuleTextContentLabel.Size = new Size(800, 87);
            SecondRuleTextContentLabel.TabIndex = 9;
            SecondRuleTextContentLabel.Text = resources.GetString("SecondRuleTextContentLabel.Text");
            SecondRuleTextContentLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SecondRulePictureBox
            // 
            SecondRulePictureBox.Image = Properties.Resources.photo_2025_09_21_18_31_09;
            SecondRulePictureBox.Location = new Point(267, 789);
            SecondRulePictureBox.Name = "SecondRulePictureBox";
            SecondRulePictureBox.Size = new Size(260, 232);
            SecondRulePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            SecondRulePictureBox.TabIndex = 10;
            SecondRulePictureBox.TabStop = false;
            // 
            // ThirdRuleNumberLabel
            // 
            ThirdRuleNumberLabel.Font = new Font("Segoe UI", 28F);
            ThirdRuleNumberLabel.ForeColor = Color.Red;
            ThirdRuleNumberLabel.Location = new Point(1, 1046);
            ThirdRuleNumberLabel.Name = "ThirdRuleNumberLabel";
            ThirdRuleNumberLabel.Size = new Size(800, 51);
            ThirdRuleNumberLabel.TabIndex = 11;
            ThirdRuleNumberLabel.Text = "3";
            ThirdRuleNumberLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ThirdRuleTextHeaderLabel
            // 
            ThirdRuleTextHeaderLabel.Font = new Font("Segoe UI", 20F);
            ThirdRuleTextHeaderLabel.Location = new Point(1, 1089);
            ThirdRuleTextHeaderLabel.Name = "ThirdRuleTextHeaderLabel";
            ThirdRuleTextHeaderLabel.Size = new Size(800, 76);
            ThirdRuleTextHeaderLabel.TabIndex = 12;
            ThirdRuleTextHeaderLabel.Text = "Не кладите плитки\r\nс большими цифрами в центре";
            ThirdRuleTextHeaderLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ThirdRuleTextContentLabel
            // 
            ThirdRuleTextContentLabel.Font = new Font("Segoe UI", 15F);
            ThirdRuleTextContentLabel.Location = new Point(1, 1163);
            ThirdRuleTextContentLabel.Name = "ThirdRuleTextContentLabel";
            ThirdRuleTextContentLabel.Size = new Size(800, 87);
            ThirdRuleTextContentLabel.TabIndex = 13;
            ThirdRuleTextContentLabel.Text = resources.GetString("ThirdRuleTextContentLabel.Text");
            ThirdRuleTextContentLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ThirdRulePictureBox1
            // 
            ThirdRulePictureBox1.Image = Properties.Resources.photo_2025_09_21_00_37_47;
            ThirdRulePictureBox1.Location = new Point(267, 1256);
            ThirdRulePictureBox1.Name = "ThirdRulePictureBox1";
            ThirdRulePictureBox1.Size = new Size(260, 232);
            ThirdRulePictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            ThirdRulePictureBox1.TabIndex = 14;
            ThirdRulePictureBox1.TabStop = false;
            // 
            // FirstRulePictureBox
            // 
            FirstRulePictureBox.Image = Properties.Resources.photo_2025_09_21_02_03_48;
            FirstRulePictureBox.Location = new Point(267, 319);
            FirstRulePictureBox.Name = "FirstRulePictureBox";
            FirstRulePictureBox.Size = new Size(260, 232);
            FirstRulePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            FirstRulePictureBox.TabIndex = 4;
            FirstRulePictureBox.TabStop = false;
            // 
            // RulesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(800, 450);
            Controls.Add(ThirdRulePictureBox1);
            Controls.Add(ThirdRuleTextContentLabel);
            Controls.Add(ThirdRuleTextHeaderLabel);
            Controls.Add(ThirdRuleNumberLabel);
            Controls.Add(SecondRulePictureBox);
            Controls.Add(SecondRuleTextContentLabel);
            Controls.Add(SecondRuleTextHeaderLabel);
            Controls.Add(SecondRuleNumberLabel);
            Controls.Add(UnderliningLabel);
            Controls.Add(FirstRulePictureBox);
            Controls.Add(FirstRuleTextContentLabel);
            Controls.Add(FirstRuleTextHeaderLabel);
            Controls.Add(FirstRuleNumberLabel);
            Controls.Add(HowToPlayLabel);
            Name = "RulesForm";
            Text = "2048 | Правила игры";
            ((System.ComponentModel.ISupportInitialize)SecondRulePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)ThirdRulePictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)FirstRulePictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label HowToPlayLabel;
        private Label FirstRuleNumberLabel;
        private Label FirstRuleTextHeaderLabel;
        private Label FirstRuleTextContentLabel;
        private Label UnderliningLabel;
        private Label SecondRuleNumberLabel;
        private Label SecondRuleTextHeaderLabel;
        private Label SecondRuleTextContentLabel;
        private PictureBox SecondRulePictureBox;
        private Label ThirdRuleNumberLabel;
        private Label ThirdRuleTextHeaderLabel;
        private Label ThirdRuleTextContentLabel;
        private PictureBox ThirdRulePictureBox1;
        private PictureBox FirstRulePictureBox;
    }
}