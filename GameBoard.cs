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

        public GameBoard( string PlayerName, int difficulty)
        {
            InitializeComponent();
            double percentActive = 0;

            switch (difficulty)
            {
                case 1:
                    BoardSize = 10;
                    percentActive = .15;
                    break;
                case 2:
                    BoardSize = 15;
                    percentActive = .25;
                    break;
                case 3:
                    BoardSize = 20;
                    percentActive = .4;
                    break;
            }

            // create a gameBoard
            gameGrid = new Grid(BoardSize);
            gameGrid.Activate(percentActive);
            gameGrid.PopulateNeighborValues();
            GameTimer.Start();

            // Iterate through the array
            for (int row = 0; row < BoardSize; row++)
            {
                for (int col = 0; col < BoardSize; col++)
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
                        gameMode = 2;
                    }
                    else
                    {
                        // if cell is not live, update has been visited, check win condition, then set gameMode to 1, and update display
                        cell.HasBeenVisited = true;
                        CheckWinCondition();

                        if (gameMode == 1)
                        {
                            if (cell.NumLiveNeighbors == 0)   // if there are no live neighbors,
                                Cascade(cell.Row, cell.Col);  // send this cell's row and col to the cascade method
                        }
                    }
                    ShowBoard();
                    break;
                    case MouseButtons.Right:
                    // code for flagging the unchecked cell and marking it as flagged
                    if (cell.IsFlagged)
                    {
                        // if it is flagged, unflag it, clear the image, and mark cell as not visited
                        cell.BackgroundImage = null;
                        cell.IsFlagged = false;
                        cell.HasBeenVisited = false;
                    }
                    else
                    {
                        // if it is not flagged, flag it, add the image, mark the visited flag and check the win condition.
                        cell.BackgroundImageLayout = ImageLayout.Stretch;
                        cell.BackgroundImage = fantasticOctoWaddle.Resources.mineSweeperFlag;
                        cell.IsFlagged = true;
                        cell.HasBeenVisited = true;
                    }
                    // checking win condition so if the last unvisited cell is flagged, the game doesnt stall.
                    CheckWinCondition();
                    ShowBoard();
                    break;
                }
        }

        // Check the win condition and change gameMode as necessary
        // win condition is all non live cells have been visited
        public void CheckWinCondition()
        {
            for (int row = 0; row < gameGrid.board.GetLength(0); row++)
            {
                for (int col = 0; col < gameGrid.board.GetLength(1); col++)
                {
                    // Checks all non live cells for visitation
                    if(gameGrid.board[row,col].IsLive == false && gameGrid.board[row,col].HasBeenVisited == false)
                    {
                        gameMode = 1;
                        return;
                    }
                }
            }
            gameMode = 0;
        }

        // checks surrounding cells for cells with no live neighbors and set hasbeenvisited to true
        public void Cascade(int row, int col)
        {
            gameGrid.board[row, col].HasBeenVisited = true;
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

        // stop the timer
        public void StopTimer()
        {
            GameTimer.Stop();
        }

        // this method checks the gameMode (0=win, 1=still playing, 2=dead) and displays the grid accordingly
        public void ShowBoard()
        {
            switch (gameMode)
            {
                case 0: // WinRAR.  Stop the timer, and display all mines with flags.  give winning message
                    StopTimer();
                    for (int row = 0; row < gameGrid.board.GetLength(0); row++)
                    {
                        for (int col = 0; col < gameGrid.board.GetLength(1); col++)
                        {
                            Controls.Add(gameGrid.board[row, col]);

                            // Unsubscribe from the GameBoard_Click event since you won.
                            gameGrid.board[row, col].MouseUp -= GameBoard_Click;

                            if (gameGrid.board[row, col].IsLive)
                            {
                                gameGrid.board[row, col].BackgroundImageLayout = ImageLayout.Stretch;
                                gameGrid.board[row, col].BackgroundImage = fantasticOctoWaddle.Resources.mineSweeperFlag;
                            }
                        }
                    }
                    MessageBox.Show("YOU WIN! \nClose the window to play again.\nTime Elapsed: " + GameTimer.Elapsed.ToString("mm\\:ss"));
                    break;

                case 1: //  Still Alive.  display the board again with proper values if the cells have been visited and arent flagged or 0 or live.
                    for (int row = 0; row < gameGrid.board.GetLength(0); row++)
                    {
                        for (int col = 0; col < gameGrid.board.GetLength(1); col++)
                        {
                            Controls.Add(gameGrid.board[row, col]);
                            if(gameGrid.board[row,col].HasBeenVisited == true && gameGrid.board[row,col].IsLive == false && gameGrid.board[row,col].IsFlagged == false)
                            {
                                gameGrid.board[row, col].BackColor = System.Drawing.Color.AliceBlue;
                                if (gameGrid.board[row, col].NumLiveNeighbors > 0)
                                    gameGrid.board[row, col].Text = gameGrid.board[row, col].NumLiveNeighbors.ToString();
                            }
                        }
                    }
                            break;

                case 2: // Dead.  stop timer. Display all live cells with bomb icon, give dead message and time.
                    StopTimer();
                    for (int row = 0; row < gameGrid.board.GetLength(0); row++) 
                    {
                        for(int col=0; col < gameGrid.board.GetLength(1); col++)
                        {
                            Controls.Add(gameGrid.board[row, col]);

                            // Unsubscribe from the GameBoard_Click event since you lost
                            gameGrid.board[row, col].MouseUp -= GameBoard_Click;

                            if (gameGrid.board[row, col].IsLive)
                            {
                                gameGrid.board[row, col].BackgroundImageLayout = ImageLayout.Stretch;
                                gameGrid.board[row, col].BackgroundImage = fantasticOctoWaddle.Resources.bomb;
                            }
                        }
                    }
                    MessageBox.Show("BOOM!  YOU LOSE! \nClose this window to play again.\nTime Elapsed: " + GameTimer.Elapsed.ToString("mm\\:ss"));
                    break;
            }

        }
    } 
}
