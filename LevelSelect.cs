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
        public int Difficulty { get; set; }
        public string PlayerName { get; set; }

        public LevelSelect()
        {
            InitializeComponent();
        }

        private void ButtonQuit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        
        private void TextBoxPlayerName_EnterKeyPress(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                ReturnValues();
            }
        }

        private void ButtonPlay_Click(object sender, EventArgs e)
        {
            ReturnValues();
        }

        private void ReturnValues() { 
            //string playerName = "";
            //int difficulty = 0;

            if (RadioButtonEasy.Checked)
                Difficulty = 1;
            else if (RadioButtonModerate.Checked)
                Difficulty = 2;
            else if (RadioButtonHard.Checked)
                Difficulty = 3;


            if (TextBoxPlayerName.Text == "")
                PlayerName = "NoName";
            else
                PlayerName = TextBoxPlayerName.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();

            //GameBoard gameBoard = new GameBoard(playerName, difficulty);
            //gameBoard.ShowDialog();

            //TextBoxPlayerName.Text = "";

            //this.Show();
        }


    }
}
