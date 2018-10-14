namespace fantasticOctoWaddle
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.MenuStripMain = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.FileToolStripNewGame = new System.Windows.Forms.ToolStripMenuItem();
            this.FileToolStripExit = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewToolStripScoreboard = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewToolStripScoreboardEasy = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewToolStripScoreboardModerate = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewToolStripScoreboardHard = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuHowToPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.hintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripHintShowTheBoard = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelGamePanel = new System.Windows.Forms.Panel();
            this.MenuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStripMain
            // 
            this.MenuStripMain.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.MenuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenu,
            this.ViewToolStripMenu,
            this.HelpToolStripMenu});
            this.MenuStripMain.Location = new System.Drawing.Point(0, 0);
            this.MenuStripMain.Name = "MenuStripMain";
            this.MenuStripMain.Size = new System.Drawing.Size(292, 52);
            this.MenuStripMain.TabIndex = 0;
            this.MenuStripMain.Text = "menuStrip1";
            // 
            // FileToolStripMenu
            // 
            this.FileToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripNewGame,
            this.FileToolStripExit});
            this.FileToolStripMenu.Name = "FileToolStripMenu";
            this.FileToolStripMenu.Size = new System.Drawing.Size(75, 48);
            this.FileToolStripMenu.Text = "File";
            // 
            // FileToolStripNewGame
            // 
            this.FileToolStripNewGame.Name = "FileToolStripNewGame";
            this.FileToolStripNewGame.Size = new System.Drawing.Size(278, 46);
            this.FileToolStripNewGame.Text = "New Game";
            this.FileToolStripNewGame.Click += new System.EventHandler(this.FileToolStripMenuNewGame_Click);
            // 
            // FileToolStripExit
            // 
            this.FileToolStripExit.Name = "FileToolStripExit";
            this.FileToolStripExit.Size = new System.Drawing.Size(278, 46);
            this.FileToolStripExit.Text = "Exit";
            this.FileToolStripExit.Click += new System.EventHandler(this.FileToolStripExit_Click);
            // 
            // ViewToolStripMenu
            // 
            this.ViewToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ViewToolStripScoreboard});
            this.ViewToolStripMenu.Name = "ViewToolStripMenu";
            this.ViewToolStripMenu.Size = new System.Drawing.Size(94, 48);
            this.ViewToolStripMenu.Text = "View";
            // 
            // ViewToolStripScoreboard
            // 
            this.ViewToolStripScoreboard.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ViewToolStripScoreboardEasy,
            this.ViewToolStripScoreboardModerate,
            this.ViewToolStripScoreboardHard});
            this.ViewToolStripScoreboard.Name = "ViewToolStripScoreboard";
            this.ViewToolStripScoreboard.Size = new System.Drawing.Size(285, 46);
            this.ViewToolStripScoreboard.Text = "Scoreboard";
            // 
            // ViewToolStripScoreboardEasy
            // 
            this.ViewToolStripScoreboardEasy.Name = "ViewToolStripScoreboardEasy";
            this.ViewToolStripScoreboardEasy.Size = new System.Drawing.Size(262, 46);
            this.ViewToolStripScoreboardEasy.Text = "Easy";
            this.ViewToolStripScoreboardEasy.Click += new System.EventHandler(this.ViewToolStripScoreboardEasy_Click);
            // 
            // ViewToolStripScoreboardModerate
            // 
            this.ViewToolStripScoreboardModerate.Name = "ViewToolStripScoreboardModerate";
            this.ViewToolStripScoreboardModerate.Size = new System.Drawing.Size(262, 46);
            this.ViewToolStripScoreboardModerate.Text = "Moderate";
            this.ViewToolStripScoreboardModerate.Click += new System.EventHandler(this.ViewToolStripScoreboardModerate_Click);
            // 
            // ViewToolStripScoreboardHard
            // 
            this.ViewToolStripScoreboardHard.Name = "ViewToolStripScoreboardHard";
            this.ViewToolStripScoreboardHard.Size = new System.Drawing.Size(262, 46);
            this.ViewToolStripScoreboardHard.Text = "Hard";
            this.ViewToolStripScoreboardHard.Click += new System.EventHandler(this.ViewToolStripScoreboardHard_Click);
            // 
            // HelpToolStripMenu
            // 
            this.HelpToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpToolStripMenuHowToPlay,
            this.hintToolStripMenuItem,
            this.HelpToolStripMenuAbout});
            this.HelpToolStripMenu.Name = "HelpToolStripMenu";
            this.HelpToolStripMenu.Size = new System.Drawing.Size(92, 48);
            this.HelpToolStripMenu.Text = "Help";
            // 
            // HelpToolStripMenuHowToPlay
            // 
            this.HelpToolStripMenuHowToPlay.Name = "HelpToolStripMenuHowToPlay";
            this.HelpToolStripMenuHowToPlay.Size = new System.Drawing.Size(396, 46);
            this.HelpToolStripMenuHowToPlay.Text = "How To Play";
            this.HelpToolStripMenuHowToPlay.Click += new System.EventHandler(this.HelpToolStripMenuHowToPlay_Click);
            // 
            // hintToolStripMenuItem
            // 
            this.hintToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpToolStripHintShowTheBoard});
            this.hintToolStripMenuItem.Name = "hintToolStripMenuItem";
            this.hintToolStripMenuItem.Size = new System.Drawing.Size(396, 46);
            this.hintToolStripMenuItem.Text = "Hint";
            // 
            // HelpToolStripHintShowTheBoard
            // 
            this.HelpToolStripHintShowTheBoard.Enabled = false;
            this.HelpToolStripHintShowTheBoard.Name = "HelpToolStripHintShowTheBoard";
            this.HelpToolStripHintShowTheBoard.Size = new System.Drawing.Size(396, 46);
            this.HelpToolStripHintShowTheBoard.Text = "Show The Board";
            this.HelpToolStripHintShowTheBoard.Click += new System.EventHandler(this.HelpToolStripHintShowTheBoard_Click);
            // 
            // HelpToolStripMenuAbout
            // 
            this.HelpToolStripMenuAbout.Name = "HelpToolStripMenuAbout";
            this.HelpToolStripMenuAbout.Size = new System.Drawing.Size(396, 46);
            this.HelpToolStripMenuAbout.Text = "About";
            this.HelpToolStripMenuAbout.Click += new System.EventHandler(this.HelpToolStripMenuAbout_Click);
            // 
            // PanelGamePanel
            // 
            this.PanelGamePanel.AutoSize = true;
            this.PanelGamePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PanelGamePanel.Location = new System.Drawing.Point(8, 64);
            this.PanelGamePanel.Name = "PanelGamePanel";
            this.PanelGamePanel.Size = new System.Drawing.Size(0, 0);
            this.PanelGamePanel.TabIndex = 1;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(292, 212);
            this.Controls.Add(this.PanelGamePanel);
            this.Controls.Add(this.MenuStripMain);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.MenuStripMain;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AMMO! Sweeper";
            this.MenuStripMain.ResumeLayout(false);
            this.MenuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStripMain;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem ViewToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripNewGame;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripExit;
        private System.Windows.Forms.ToolStripMenuItem ViewToolStripScoreboard;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuHowToPlay;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuAbout;
        private System.Windows.Forms.ToolStripMenuItem ViewToolStripScoreboardEasy;
        private System.Windows.Forms.ToolStripMenuItem ViewToolStripScoreboardModerate;
        private System.Windows.Forms.ToolStripMenuItem ViewToolStripScoreboardHard;
        private System.Windows.Forms.ToolStripMenuItem hintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripHintShowTheBoard;
        private System.Windows.Forms.Panel PanelGamePanel;
    }
}