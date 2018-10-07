namespace fantasticOctoWaddle
{
    partial class Scores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Scores));
            this.ButtonClose = new System.Windows.Forms.Button();
            this.TBDifficultyText = new System.Windows.Forms.TextBox();
            this.DGTop5Scores = new System.Windows.Forms.DataGridView();
            this.PlayerName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlayerScore1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGTop5Scores)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonClose
            // 
            this.ButtonClose.Location = new System.Drawing.Point(264, 504);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(176, 64);
            this.ButtonClose.TabIndex = 2;
            this.ButtonClose.Text = "Close";
            this.ButtonClose.UseVisualStyleBackColor = true;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // TBDifficultyText
            // 
            this.TBDifficultyText.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.TBDifficultyText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBDifficultyText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBDifficultyText.Location = new System.Drawing.Point(250, 24);
            this.TBDifficultyText.Name = "TBDifficultyText";
            this.TBDifficultyText.Size = new System.Drawing.Size(204, 46);
            this.TBDifficultyText.TabIndex = 3;
            this.TBDifficultyText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DGTop5Scores
            // 
            this.DGTop5Scores.AllowUserToAddRows = false;
            this.DGTop5Scores.AllowUserToDeleteRows = false;
            this.DGTop5Scores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGTop5Scores.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGTop5Scores.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DGTop5Scores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGTop5Scores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PlayerName1,
            this.PlayerScore1});
            this.DGTop5Scores.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.DGTop5Scores.Location = new System.Drawing.Point(40, 88);
            this.DGTop5Scores.MultiSelect = false;
            this.DGTop5Scores.Name = "DGTop5Scores";
            this.DGTop5Scores.ReadOnly = true;
            this.DGTop5Scores.RowTemplate.Height = 40;
            this.DGTop5Scores.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.DGTop5Scores.Size = new System.Drawing.Size(624, 352);
            this.DGTop5Scores.TabIndex = 5;
            // 
            // PlayerName1
            // 
            this.PlayerName1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PlayerName1.FillWeight = 60F;
            this.PlayerName1.HeaderText = "Name";
            this.PlayerName1.Name = "PlayerName1";
            this.PlayerName1.ReadOnly = true;
            this.PlayerName1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PlayerScore1
            // 
            this.PlayerScore1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PlayerScore1.FillWeight = 40F;
            this.PlayerScore1.HeaderText = "Score";
            this.PlayerScore1.Name = "PlayerScore1";
            this.PlayerScore1.ReadOnly = true;
            this.PlayerScore1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Scores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 629);
            this.Controls.Add(this.DGTop5Scores);
            this.Controls.Add(this.TBDifficultyText);
            this.Controls.Add(this.ButtonClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Scores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "High Scores";
            this.Load += new System.EventHandler(this.Scores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGTop5Scores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ButtonClose;
        private System.Windows.Forms.TextBox TBDifficultyText;
        private System.Windows.Forms.DataGridView DGTop5Scores;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerName1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerScore1;
    }
}