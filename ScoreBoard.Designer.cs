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
            this.LVTop5Scores = new System.Windows.Forms.ListView();
            this.PlayerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PlayerScore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ButtonClose = new System.Windows.Forms.Button();
            this.TBDifficultyText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LVTop5Scores
            // 
            this.LVTop5Scores.AutoArrange = false;
            this.LVTop5Scores.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PlayerName,
            this.PlayerScore});
            this.LVTop5Scores.Location = new System.Drawing.Point(96, 96);
            this.LVTop5Scores.Name = "LVTop5Scores";
            this.LVTop5Scores.Size = new System.Drawing.Size(624, 360);
            this.LVTop5Scores.TabIndex = 0;
            this.LVTop5Scores.UseCompatibleStateImageBehavior = false;
            this.LVTop5Scores.View = System.Windows.Forms.View.Details;
            // 
            // PlayerName
            // 
            this.PlayerName.Text = "Name";

            // 
            // PlayerScore
            // 
            this.PlayerScore.Text = "Score";

            // 
            // ButtonClose
            // 
            this.ButtonClose.Location = new System.Drawing.Point(320, 504);
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
            this.TBDifficultyText.Location = new System.Drawing.Point(408, 33);
            this.TBDifficultyText.Name = "TBDifficultyText";
            this.TBDifficultyText.Size = new System.Drawing.Size(204, 31);
            this.TBDifficultyText.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(224, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Difficulty:";
            // 
            // Scores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 647);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TBDifficultyText);
            this.Controls.Add(this.ButtonClose);
            this.Controls.Add(this.LVTop5Scores);
            this.Name = "Scores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ScoreBoard";
            this.Load += new System.EventHandler(this.Scores_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView LVTop5Scores;
        private System.Windows.Forms.Button ButtonClose;
        private System.Windows.Forms.TextBox TBDifficultyText;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ColumnHeader PlayerName;
        public System.Windows.Forms.ColumnHeader PlayerScore;
    }
}