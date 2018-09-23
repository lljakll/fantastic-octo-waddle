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
                    gameGrid.board[row, col].Click += GameBoard_Click;
                }
            }           
        }

        // This is where the logic will go for the click next week.
        private void GameBoard_Click(object sender, EventArgs e)
        {
            // The passed object is assigned
            Cell cell = (Cell)sender;

            // if the Cell Object's text is not blank, increment it
            if(int.TryParse(cell.Text, out int counter))
            {
                counter++;
            }
            else
            {
                counter = 1;
            }

            // display the new text
            cell.Text = counter.ToString();
        }
    }
}
