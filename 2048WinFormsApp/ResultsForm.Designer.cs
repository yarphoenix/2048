namespace _2048WinFormsApp
{
    partial class ResultsForm
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
            ResultsGridView = new DataGridView();
            NameColumn = new DataGridViewTextBoxColumn();
            ScoreColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)ResultsGridView).BeginInit();
            SuspendLayout();
            // 
            // ResultsGridView
            // 
            ResultsGridView.AllowUserToAddRows = false;
            ResultsGridView.AllowUserToDeleteRows = false;
            ResultsGridView.AllowUserToResizeColumns = false;
            ResultsGridView.AllowUserToResizeRows = false;
            ResultsGridView.Columns.AddRange(new DataGridViewColumn[] { NameColumn, ScoreColumn });
            ResultsGridView.Dock = DockStyle.Fill;
            ResultsGridView.Location = new Point(0, 0);
            ResultsGridView.Name = "ResultsGridView";
            ResultsGridView.RightToLeft = RightToLeft.No;
            ResultsGridView.Size = new Size(450, 147);
            ResultsGridView.TabIndex = 0;
            // 
            // NameColumn
            // 
            NameColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            NameColumn.HeaderText = "Имя";
            NameColumn.Name = "NameColumn";
            NameColumn.ReadOnly = true;
            // 
            // ScoreColumn
            // 
            ScoreColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ScoreColumn.HeaderText = "Счёт";
            ScoreColumn.Name = "ScoreColumn";
            ScoreColumn.ReadOnly = true;
            ScoreColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
            // 
            // ResultsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 147);
            Controls.Add(ResultsGridView);
            Name = "ResultsForm";
            Text = "2048 | История результатов";
            ((System.ComponentModel.ISupportInitialize)ResultsGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView ResultsGridView;
        private DataGridViewTextBoxColumn NameColumn;
        private DataGridViewTextBoxColumn ScoreColumn;
    }
}