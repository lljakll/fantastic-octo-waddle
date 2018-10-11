using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace fantasticOctoWaddle
{
    public partial class frmMain : Form
    {
        public int Difficulty { get; set; }
        public string PlayerName { get; set; }

        public frmMain()
        {
            InitializeComponent();
        }

        private void FileToolStripExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewToolStripScoreboardEasy_Click(object sender, EventArgs e)
        {
            Scores dispScore = new Scores();
            dispScore.ReadScoresToCollection();
            dispScore.PopulateTop5(1);
            dispScore.ShowDialog();
        }

        private void ViewToolStripScoreboardModerate_Click(object sender, EventArgs e)
        {
            Scores dispScore = new Scores();
            dispScore.ReadScoresToCollection();
            dispScore.PopulateTop5(2);
            dispScore.ShowDialog();
        }

        private void ViewToolStripScoreboardHard_Click(object sender, EventArgs e)
        {
            Scores dispScore = new Scores();
            dispScore.ReadScoresToCollection();
            dispScore.PopulateTop5(3);
            dispScore.ShowDialog();
        }

        private void FileToolStripMenuNewGame_Click(object sender, EventArgs e)
        {
            using (var form = new LevelSelect())
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    Difficulty = form.Difficulty;
                    PlayerName = form.PlayerName;

                    MessageBox.Show(Difficulty + PlayerName);
                }
            }
        }
    }
}
