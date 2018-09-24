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

        // Calls the GameBoard and passes the size of the board
        // This form is the Application Form, so it is hidden.
        // Currently, when the GameBoard Form is closed, the
        // remainder of the code executes and closes this form.
        // TODO: setup a playAgain dialog that will allow the player
        // to play again if desired.
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
            GameBoard gameBoard = new GameBoard(boardSize);
            gameBoard.ShowDialog();

            // this is here we will add the code for a new game question
            this.Close();
        }
    }
}
