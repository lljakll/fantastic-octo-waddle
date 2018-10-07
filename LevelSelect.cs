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

        // Calls the GameBoard and passes the size of the board
        // This form is the Application Form, so it is hidden.
        // Currently, when the GameBoard Form is closed, the
        // remainder of the code executes and closes this form.
        // TODO: setup a playAgain dialog that will allow the player
        // to play again if desired.
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
