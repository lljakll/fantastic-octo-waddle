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
            gameGrid.Activate();
            gameGrid.PopulateNeighborValues();

            // Iterate through the array
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    // Add the Cell Objects individually to the board (Form) based
                    // on their location
                    Controls.Add(gameGrid.board[row, col]);

                    // Click handler
                    gameGrid.board[row, col].MouseUp += GameBoard_Click;
                }
            }           
        }

        // Logic for the mouse click event and checking the cells.  
        // Actions after cells are checked follow the click event
        private void GameBoard_Click(object sender, MouseEventArgs e)
        {
            
            // The passed object is assigned
            Cell cell = (Cell)sender;

                switch (e.Button)
                {
                    case MouseButtons.Left:
                    // Code for checking isLive and responding to it appropriatley;
                    if (cell.IsLive)
                    {
                        // if cell is live, call Detonate() and GameOver(gameTimeElapsed)

                    }
                    else
                    {

                    }
                        break;
                    case MouseButtons.Right:
                    // code for flagging the unchecked cell and marking it as flagged
                    if (cell.IsFlagged)
                    {
                        cell.BackgroundImage = null;
                        cell.IsFlagged = false;
                    }
                    else
                    {
                        cell.BackgroundImage = fantastic_octo_waddle.Properties.Resources.mineSweeperFlag;
                        cell.IsFlagged = true;
                    }
                    break;
                }
        }
    } 
}
