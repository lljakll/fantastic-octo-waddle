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
        // Properties
        public int Difficulty { get; set; }
        public string PlayerName { get; set; }

        // Constructor
        public LevelSelect()
        {
            InitializeComponent();
        }

        // Quit Button.  Passes 'Cancel' back to the MainForm
        private void ButtonQuit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        
        // Enter Keypress for use if you press enter after typing in your name.
        // Calls ReturnValues()
        private void TextBoxPlayerName_EnterKeyPress(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                ReturnValues();
            }
        }

        // Play Button.  Calls Return Values.
        private void ButtonPlay_Click(object sender, EventArgs e)
        {
            ReturnValues();
        }

        // Returns difficulty selection and name value.  If no name, fills "Jak"
        // Because...why not!
        private void ReturnValues() { 

            if (RadioButtonEasy.Checked)
                Difficulty = 1;
            else if (RadioButtonModerate.Checked)
                Difficulty = 2;
            else if (RadioButtonHard.Checked)
                Difficulty = 3;

            if (TextBoxPlayerName.Text == "")
                PlayerName = "Jak";
            else
                PlayerName = TextBoxPlayerName.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
