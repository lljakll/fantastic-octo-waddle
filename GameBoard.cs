using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace fantasticOctoWaddle
{
    public partial class GameBoard : Form
    {
        // setting the passed boardsize integer as a property for future functionality
        public int BoardSize { get; set; }
        private Stopwatch GameTimer = new Stopwatch();
        private int gameMode = 0;
        Grid gameGrid;

        public GameBoard( int size)
        {
            InitializeComponent();
            BoardSize = size;

            // create a gameBoard
            gameGrid = new Grid(BoardSize);
            gameGrid.Activate();
            gameGrid.PopulateNeighborValues();
            GameTimer.Start();

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
                        // if cell is live, stop timer, set game mode to 2, update display and show game over with time.
                        StopTimer();
                        gameMode = 2;
                        ShowBoard();
                        MessageBox.Show("Game Over! Time Elapsed: " + GameTimer.Elapsed.ToString("mm\\:ss"));
                    }
                    else
                    {
                        // if cell is not live, update has been visited, set gameMode to 1, and update display
                        gameMode = 1;
                        cell.HasBeenVisited = true;
                        if (cell.NumLiveNeighbors == 0)   // if there are no live neighbors,
                            Cascade(cell.Row, cell.Col);  // send this cell's row and col to the cascade method
                        ShowBoard();
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
        // checks surrounding cells for cells with no live neighbors and set hasbeenvisited to true
        public void Cascade(int row, int col)
        {
            // check for live neighbors.  If none, iterate through the neighbors to do the following:
            if (gameGrid.board[row, col].NumLiveNeighbors == 0)
            {
                // iterate through each neighbor
                for (int i = -1; i < 2; i++)
                {
                    for (int k = -1; k < 2; k++)
                    {
                        // make sure to stay in bounds
                        if (row + i >= 0 && row + i < gameGrid.board.GetLength(0) && col + k >= 0 && col + k < gameGrid.board.GetLength(1))
                        {
                            // if a neighbor has not been visited
                            if (gameGrid.board[row + i, col + k].HasBeenVisited == false)
                            {
                                // recursively check that cell's neighbors...
                                Cascade(row + i, col + k);
                            }
                        }
                    }
                }
            }
            else
                // if the cell has neighbors.  Back out of that recrusion iteration
                return;
        }

        public void StopTimer()
        {
            GameTimer.Stop();
        }

        public void ShowBoard()
        {
            switch (gameMode)
            {
                case 0: // WinRAR
                    for (int row = 0; row < gameGrid.board.GetLength(0); row++)
                    {
                        for (int col = 0; col < gameGrid.board.GetLength(1); col++)
                        {
                            Controls.Add(gameGrid.board[row, col]);

                            if (gameGrid.board[row, col].IsLive)
                            {
                                gameGrid.board[row, col].BackgroundImage = fantastic_octo_waddle.Properties.Resources.bomb;
                            }
                        }
                    }
                    break;
                case 1: //  Still Alive
                    for (int row = 0; row < gameGrid.board.GetLength(0); row++)
                    {
                        for (int col = 0; col < gameGrid.board.GetLength(1); col++)
                        {
                            Controls.Add(gameGrid.board[row, col]);
                            if(gameGrid.board[row,col].HasBeenVisited == true && gameGrid.board[row,col].IsLive == false)
                            {
                                gameGrid.board[row, col].Text = gameGrid.board[row, col].NumLiveNeighbors.ToString();
                            }
                        }
                    }
                            break;
                case 2: // Dead
                    for (int row = 0; row < gameGrid.board.GetLength(0); row++) 
                    {
                        for(int col=0; col < gameGrid.board.GetLength(1); col++)
                        {
                            Controls.Add(gameGrid.board[row, col]);

                            if (gameGrid.board[row, col].IsLive)
                            {
                                gameGrid.board[row, col].BackgroundImage = fantastic_octo_waddle.Properties.Resources.bomb;
                            }
                        }
                    }
                    break;
            }

        }
    } 
}
