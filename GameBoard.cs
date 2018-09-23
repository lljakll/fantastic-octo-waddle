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
    public partial class FormGameBoard : Form
    {
        public int BoardSize { get; set; }

        public FormGameBoard( int size)
        {
            InitializeComponent();
            BoardSize = size;

            Grid gameGrid = new Grid(size);
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {

                    Controls.Add(gameGrid.board[row, col]);

                    gameGrid.board[row, col].Click += FormGameBoard_Click;
                    
                }
            }           
        }

        private void FormGameBoard_Click(object sender, EventArgs e)
        {
            Cell cell = (Cell)sender;
            if(int.TryParse(cell.Text, out int counter))
            {
                counter++;
            }
            else
            {
                counter = 1;
            }

            cell.Text = counter.ToString();
        }
    }
}
