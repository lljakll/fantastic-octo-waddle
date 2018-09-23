using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fantasticOctoWaddle
{
    public partial class LevelSelect : Form
    {
        public LevelSelect()
        {
            InitializeComponent();
        }

        private void ButtonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonPlay_Click(object sender, EventArgs e)
        {
            int boardSize = 0;
            if (RadioButtonEasy.Checked)
                boardSize = 10;
            else if (RadioButtonModerate.Checked)
                boardSize = 15;
            else if (RadioButtonHard.Checked)
                boardSize = 20;

            this.Hide();
            FormGameBoard gameBoard = new FormGameBoard(boardSize);
            gameBoard.ShowDialog();
            this.Close();
        }
    }
}
