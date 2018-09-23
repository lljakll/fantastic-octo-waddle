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
    public partial class GameBoard : Form
    {
        // setting the passed boardsize integer as a property for future functionality
        public int BoardSize { get; set; }

        public GameBoard( int size)
        {
            InitializeComponent();
            BoardSize = size;

            // create a gameBoard
            Grid gameGrid = new Grid(BoardSize);
            // Iterate through the array
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    // Add the Cell Objects individually to the board (Form) based
                    // on their location
                    Controls.Add(gameGrid.board[row, col]);

                    // Click handler
                    //gameGrid.board[row, col].Click += GameBoard_Click;
                    //gameGrid.board[row, col].MouseClick += GameBoard_Click;
                    gameGrid.board[row, col].MouseUp += GameBoard_Click;
                }
            }           
        }

        // This is where the logic will go for the click next week.
        private void GameBoard_Click(object sender, MouseEventArgs e)
        {
            // The passed object is assigned
            Cell cell = (Cell)sender;

            // if the Cell Object's text is not blank, increment it on left click
            // if it is 1, blank it, if it is > 1, decrement it on right click
            if(int.TryParse(cell.Text, out int counter))
            {
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        counter++;
                        break;
                    case MouseButtons.Right:
                        if (counter > 1)
                            counter--;
                        else
                            counter = 0;
                        break;
                }
            }
            else
            {
                if (e.Button == MouseButtons.Right)
                    counter = 0;
                else
                    counter = 1;
            }

            // display the new text
            if (counter > 0)
                cell.Text = counter.ToString();
            else
                cell.Text = "";
        }
    }
}
