namespace fantasticOctoWaddle
{
    partial class LevelSelect
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
            this.GroupBoxSelectLevel = new System.Windows.Forms.GroupBox();
            this.RadioButtonEasy = new System.Windows.Forms.RadioButton();
            this.RadioButtonModerate = new System.Windows.Forms.RadioButton();
            this.RadioButtonHard = new System.Windows.Forms.RadioButton();
            this.ButtonPlay = new System.Windows.Forms.Button();
            this.ButtonQuit = new System.Windows.Forms.Button();
            this.GroupBoxSelectLevel.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBoxSelectLevel
            // 
            this.GroupBoxSelectLevel.Controls.Add(this.RadioButtonHard);
            this.GroupBoxSelectLevel.Controls.Add(this.RadioButtonModerate);
            this.GroupBoxSelectLevel.Controls.Add(this.RadioButtonEasy);
            this.GroupBoxSelectLevel.Location = new System.Drawing.Point(40, 32);
            this.GroupBoxSelectLevel.Name = "GroupBoxSelectLevel";
            this.GroupBoxSelectLevel.Size = new System.Drawing.Size(400, 360);
            this.GroupBoxSelectLevel.TabIndex = 0;
            this.GroupBoxSelectLevel.TabStop = false;
            this.GroupBoxSelectLevel.Text = "Select Level";
            // 
            // RadioButtonEasy
            // 
            this.RadioButtonEasy.AutoSize = true;
            this.RadioButtonEasy.Location = new System.Drawing.Point(48, 80);
            this.RadioButtonEasy.Name = "RadioButtonEasy";
            this.RadioButtonEasy.Size = new System.Drawing.Size(115, 36);
            this.RadioButtonEasy.TabIndex = 0;
            this.RadioButtonEasy.TabStop = true;
            this.RadioButtonEasy.Text = "Easy";
            this.RadioButtonEasy.UseVisualStyleBackColor = true;
            // 
            // RadioButtonModerate
            // 
            this.RadioButtonModerate.AutoSize = true;
            this.RadioButtonModerate.Location = new System.Drawing.Point(48, 168);
            this.RadioButtonModerate.Name = "RadioButtonModerate";
            this.RadioButtonModerate.Size = new System.Drawing.Size(172, 36);
            this.RadioButtonModerate.TabIndex = 1;
            this.RadioButtonModerate.TabStop = true;
            this.RadioButtonModerate.Text = "Moderate";
            this.RadioButtonModerate.UseVisualStyleBackColor = true;
            // 
            // RadioButtonHard
            // 
            this.RadioButtonHard.AutoSize = true;
            this.RadioButtonHard.Location = new System.Drawing.Point(48, 256);
            this.RadioButtonHard.Name = "RadioButtonHard";
            this.RadioButtonHard.Size = new System.Drawing.Size(113, 36);
            this.RadioButtonHard.TabIndex = 2;
            this.RadioButtonHard.TabStop = true;
            this.RadioButtonHard.Text = "Hard";
            this.RadioButtonHard.UseVisualStyleBackColor = true;
            // 
            // ButtonPlay
            // 
            this.ButtonPlay.Location = new System.Drawing.Point(288, 408);
            this.ButtonPlay.Name = "ButtonPlay";
            this.ButtonPlay.Size = new System.Drawing.Size(152, 64);
            this.ButtonPlay.TabIndex = 1;
            this.ButtonPlay.Text = "Play";
            this.ButtonPlay.UseVisualStyleBackColor = true;
            this.ButtonPlay.Click += new System.EventHandler(this.ButtonPlay_Click);
            // 
            // ButtonQuit
            // 
            this.ButtonQuit.Location = new System.Drawing.Point(40, 408);
            this.ButtonQuit.Name = "ButtonQuit";
            this.ButtonQuit.Size = new System.Drawing.Size(152, 64);
            this.ButtonQuit.TabIndex = 2;
            this.ButtonQuit.Text = "Quit";
            this.ButtonQuit.UseVisualStyleBackColor = true;
            this.ButtonQuit.Click += new System.EventHandler(this.ButtonQuit_Click);
            // 
            // LevelSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 557);
            this.ControlBox = false;
            this.Controls.Add(this.ButtonQuit);
            this.Controls.Add(this.ButtonPlay);
            this.Controls.Add(this.GroupBoxSelectLevel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LevelSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Level";
            this.GroupBoxSelectLevel.ResumeLayout(false);
            this.GroupBoxSelectLevel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupBoxSelectLevel;
        private System.Windows.Forms.RadioButton RadioButtonHard;
        private System.Windows.Forms.RadioButton RadioButtonModerate;
        private System.Windows.Forms.RadioButton RadioButtonEasy;
        private System.Windows.Forms.Button ButtonPlay;
        private System.Windows.Forms.Button ButtonQuit;
    }
}

