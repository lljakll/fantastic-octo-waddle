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
        public frmMain()
        {
            InitializeComponent();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void easyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Scores dispScore = new Scores();
            dispScore.ReadScoresToCollection();
            dispScore.PopulateTop5(1);
            dispScore.ShowDialog();
        }

        private void moderateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Scores dispScore = new Scores();
            dispScore.ReadScoresToCollection();
            dispScore.PopulateTop5(2);
            dispScore.ShowDialog();
        }

        private void hardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Scores dispScore = new Scores();
            dispScore.ReadScoresToCollection();
            dispScore.PopulateTop5(3);
            dispScore.ShowDialog();
        }
    }
}
