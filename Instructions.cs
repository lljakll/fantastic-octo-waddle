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
    public partial class Instructions : Form
    {
        public Instructions()
        {
            InitializeComponent();
        }

        // Close on click.
        private void BtnInstructionsClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
