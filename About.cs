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
    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            InitializeComponent();
        }

        // Close on click
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
