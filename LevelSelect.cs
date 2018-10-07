using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
        
        // Calls the gameboard, Hides itself, passes the playername and difficulty.  clears
        // player name when unhidden after gameboard and scoreboard are closed.
        private void ButtonPlay_Click(object sender, EventArgs e)
        {
            string playerName = "";
            int difficulty = 0;

            if (RadioButtonEasy.Checked)
                difficulty = 1;
            else if (RadioButtonModerate.Checked)
                difficulty = 2;
            else if (RadioButtonHard.Checked)
                difficulty = 3;


            if (TextBoxPlayerName.Text == "")
                playerName = "NoName";
            else
                playerName = TextBoxPlayerName.Text;
                

            this.Hide();

            GameBoard gameBoard = new GameBoard(playerName, difficulty);
            gameBoard.ShowDialog();

            TextBoxPlayerName.Text = "";

            this.Show();
        }


    }
}
