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
    public partial class frmMain : Form
    {
        // Properties
        public int Difficulty { get; set; }
        public string PlayerName { get; set; }
        public Size FormSize { get; set; }
        public int HintPenalty { get; set; }
        public int BoardSize { get; set; }
        private Stopwatch GameTimer = new Stopwatch();
        private int gameMode = 1;
        Grid gameGrid;
        PlayerStats Player;
        Scores ScoreBrd;

        // Constructor.  Sets form size as well.
        public frmMain()
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(350, 375);


        }

        // MENU STRIP CLICK HANDLER METHODS
        // FILE MENU
        // New Game
        private void FileToolStripMenuNewGame_Click(object sender, EventArgs e)
        {
            // Calls LevelSelect and expects a return value.
            using (var form = new LevelSelect())
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    Difficulty = form.Difficulty;
                    PlayerName = form.PlayerName;

                    // Initialize the ScoreBoard Object
                    ScoreBrd = new Scores();

                    // Call method that reads scores into collection.  
                    ScoreBrd.ReadScoresToCollection();

                    // Instantiate the PlayerStats object for this game.  
                    // The score will be updated at win condition
                    Player = new PlayerStats();
                    Player.PlayerName = PlayerName;
                    Player.PlayerLevel = Difficulty;
                    HintPenalty = 0;

                    // Enable the Show Board option under the help menu
                    // now that there is a board to sho.
                    this.HelpToolStripHintShowTheBoard.Enabled = true;

                    double percentActive = 0;

                    // Changed difficulty to board size and % active.
                    // All 3 casees are as follows: Reset the board, set the size and percentActive,
                    // resize the window, then center the it.
                    switch (Difficulty)
                    {
                        case 1:
                            ResetBoard();
                            BoardSize = 10;
                            percentActive = .10;
                            this.ClientSize = new System.Drawing.Size(255, 280);
                            this.Location = new Point((Screen.PrimaryScreen.Bounds.Size.Width / 2) 
                                - (this.Size.Width / 2), (Screen.PrimaryScreen.Bounds.Size.Height / 2) 
                                - (this.Size.Height / 2));
                            break;
                        case 2:
                            ResetBoard();
                            BoardSize = 15;
                            percentActive = .25;
                            this.ClientSize = new System.Drawing.Size(380, 405);
                            this.Location = new Point((Screen.PrimaryScreen.Bounds.Size.Width / 2) 
                                - (this.Size.Width / 2), (Screen.PrimaryScreen.Bounds.Size.Height / 2) 
                                - (this.Size.Height / 2));
                            break;
                        case 3:
                            ResetBoard();
                            BoardSize = 20;
                            percentActive = .4;
                            this.ClientSize = new System.Drawing.Size(505, 530);
                            this.Location = new Point((Screen.PrimaryScreen.Bounds.Size.Width / 2) 
                                - (this.Size.Width / 2), (Screen.PrimaryScreen.Bounds.Size.Height / 2) 
                                - (this.Size.Height / 2));
                            break;
                    }

                    // create a gameBoard
                    gameGrid = new Grid(BoardSize);
                    gameGrid.Activate(percentActive);
                    gameGrid.PopulateNeighborValues();
                    GameTimer.Start();

                    // use Double Buffer and suspend the layout while the grid is being drawn
                    // helps with lag on Hard board.
                    DoubleBuffered = true;
                    SuspendLayout();

                    // Iterate through the array

                    for (int row = 0; row < BoardSize; row++)
                    {
                        for (int col = 0; col < BoardSize; col++)
                        {
                            // Add the Cell Objects individually to the board (Form) based
                            // on their location
                            PanelGamePanel.Controls.Add(gameGrid.board[row, col]);

                            // Click handler
                            gameGrid.board[row, col].MouseUp += GameBoard_Click;
                        }
                    }
                    // Resume the layout after grid is drawn
                    ResumeLayout();
                }
            }
        }

        // Exit
        private void FileToolStripExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // VIEW MENU
        // Show the Easy Scoreboard
        private void ViewToolStripScoreboardEasy_Click(object sender, EventArgs e)
        {
            // Display the scoreboard with easy setting
            Scores dispScore = new Scores();
            dispScore.ReadScoresToCollection();
            dispScore.PopulateTop5(1);
            dispScore.ShowDialog();
        }

        // Show the Moderate Scoreboard
        private void ViewToolStripScoreboardModerate_Click(object sender, EventArgs e)
        {
            // Display the scoreboard with moderate setting
            Scores dispScore = new Scores();
            dispScore.ReadScoresToCollection();
            dispScore.PopulateTop5(2);
            dispScore.ShowDialog();
        }

        // Show the Hard Scoreboard
        private void ViewToolStripScoreboardHard_Click(object sender, EventArgs e)
        {
            // Display the scoreboard with hard setting
            Scores dispScore = new Scores();
            dispScore.ReadScoresToCollection();
            dispScore.PopulateTop5(3);
            dispScore.ShowDialog();
        }

        // HELP MENU
        // How To Play
        private void HelpToolStripMenuHowToPlay_Click(object sender, EventArgs e)
        {
            Instructions instructions = new Instructions();
            instructions.ShowDialog();
        }

        // About 
        private void HelpToolStripMenuAbout_Click(object sender, EventArgs e)
        {
            FrmAbout about = new FrmAbout();
            about.ShowDialog();
        }

        // Show the Board
        private void HelpToolStripHintShowTheBoard_Click(object sender, EventArgs e)
        {
            // sets the game mode and show the board.
            DialogResult dialogResult = MessageBox.Show("Are you sure.  This will end the game.", "Confirm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                gameMode = 2;
                ShowBoard();
            }
        }

        // Game Cell Click Event Method
        private void GameBoard_Click(object sender, MouseEventArgs e)
        {

            // The passed object is assigned
            Cell cell = (Cell)sender;

            switch (e.Button)
            {
                // If Left Mouse Button Click
                case MouseButtons.Left:

                    // unsubscribe from Left click event.  Doesnt matter what the result.
                    cell.MouseUp -= GameBoard_Click;

                    // Code for checking isLive and responding to it appropriatley;
                    if (cell.IsLive)
                    {
                        // if cell is live, stop timer, set game mode to 2, update display and show game over with time.
                        gameMode = 2;
                    }
                    else
                    {
                        // if cell is not live, update has been visited, 
                        // check if flagged, unflag if it is and clear icon,
                        // check win condition, then set gameMode to 1, cascade
                        // if required.
                        cell.HasBeenVisited = true;
                        if (cell.IsFlagged)
                        {
                            cell.BackgroundImage = null;
                            cell.IsFlagged = false;
                        }
                        CheckWinCondition();

                        if (gameMode == 1)
                        {
                            // check for cascade reqmt and run
                            if (cell.NumLiveNeighbors == 0)
                                Cascade(cell.Row, cell.Col);
                        }
                    }
                    // update the board
                    ShowBoard();
                    break;

                // If Right Mouse button click
                case MouseButtons.Right:

                    // code for flagging the unchecked cell and marking it as flagged
                    if (cell.IsFlagged)
                    {
                        // if it is flagged, unflag it, clear the image, mark 
                        // cell as not visited, resubscribe to mouse click event
                        cell.BackgroundImage = null;
                        cell.IsFlagged = false;
                    }
                    else
                    {
                        // if it is not flagged, flag it, add the image, mark the visited flag,
                        // and check the win condition.
                        cell.BackgroundImageLayout = ImageLayout.Stretch;
                        cell.BackgroundImage = fantasticOctoWaddle.Resource.mineSweeperFlag;
                        cell.IsFlagged = true;
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
                    // Checks all non live cells for visitation or all live are flagged
                    if (gameGrid.board[row, col].IsLive == false && gameGrid.board[row, col].HasBeenVisited == false)
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

            // unsubscribe from Left click event
            gameGrid.board[row, col].MouseUp -= GameBoard_Click;

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

        public void ResetBoard()
        {
            // Reset window size
            this.ClientSize = new System.Drawing.Size(350, 375);
            // Reset window position
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Size.Width / 2) - 
                (this.Size.Width / 2), (Screen.PrimaryScreen.Bounds.Size.Height / 2) - 
                (this.Size.Height / 2));
            // clear cells from board
            PanelGamePanel.Controls.Clear();
        }

        // this method checks the gameMode (0=win, 1=still playing, 2=dead) and displays the grid accordingly
        public void ShowBoard()
        {
            switch (gameMode)
            {
                case 0: // WinRAR.  Stop the timer, and display all mines with flags.  give winning message
                    StopTimer();

                    // double buffered and suspend layout for population of board lag
                    DoubleBuffered = true;
                    SuspendLayout();
                    for (int row = 0; row < gameGrid.board.GetLength(0); row++)
                    {
                        for (int col = 0; col < gameGrid.board.GetLength(1); col++)
                        {
                            // add cells
                            PanelGamePanel.Controls.Add(gameGrid.board[row, col]);

                            // Unsubscribe from the GameBoard_Click event since you won.
                            gameGrid.board[row, col].MouseUp -= GameBoard_Click;

                            // show bombs
                            if (gameGrid.board[row, col].IsLive)
                            {
                                gameGrid.board[row, col].BackgroundImageLayout = ImageLayout.Stretch;
                                gameGrid.board[row, col].BackgroundImage = fantasticOctoWaddle.Resource.mineSweeperFlag;
                            }
                        }
                    }
                    // resume layout now that board is drawn
                    ResumeLayout();

                    // deactivate the show board menu item
                    this.HelpToolStripHintShowTheBoard.Enabled = false;

                    // assign player score.
                    Player.PlayerScore = GameTimer.Elapsed.Seconds;

                    // show win message
                    MessageBox.Show("YOU WIN! \nTime Elapsed: " + GameTimer.Elapsed.ToString("hh\\:mm\\:ss"));

                    // Write the player score to the data file and add to the scoreboard List<>
                    ScoreBrd.WriteScore(Player);

                    // Re-Reading the scores into the collection so the current game will be
                    // considered and displayed if it qualifies in the top 5.
                    ScoreBrd.ReadScoresToCollection();

                    // calls populatetop5 method to give this game a chance to be in the top 5
                    ScoreBrd.PopulateTop5(Player.PlayerLevel);

                    // shows the scoreboard
                    ScoreBrd.ShowDialog();
                    break;

                case 1: //  Still Alive.  display the board again with proper values if 
                        // the cells have been visited and arent flagged or 0 or live.

                    // double buffered and suspend layout for population of board lag
                    DoubleBuffered = true;
                    SuspendLayout();
                    for (int row = 0; row < gameGrid.board.GetLength(0); row++)
                    {
                        for (int col = 0; col < gameGrid.board.GetLength(1); col++)
                        {
                            // redraw the board with updated cells
                            PanelGamePanel.Controls.Add(gameGrid.board[row, col]);
                            if (gameGrid.board[row, col].HasBeenVisited == true 
                                && gameGrid.board[row, col].IsLive == false 
                                && gameGrid.board[row, col].IsFlagged == false)
                            {
                                gameGrid.board[row, col].BackColor = System.Drawing.Color.AliceBlue;
                                if (gameGrid.board[row, col].NumLiveNeighbors > 0)
                                    gameGrid.board[row, col].Text = gameGrid.board[row, col].NumLiveNeighbors.ToString();
                            }
                        }
                    }
                    // resume layout now that board is drawn
                    ResumeLayout();
                    break;

                case 2: // Dead.  stop timer. Display all live cells with bomb icon, give dead message and time.
                    StopTimer();
                    
                    // double buffered and suspend layout for population of board lag
                    DoubleBuffered = true;
                    SuspendLayout();
                    for (int row = 0; row < gameGrid.board.GetLength(0); row++)
                    {
                        for (int col = 0; col < gameGrid.board.GetLength(1); col++)
                        {
                            // redraw the board
                            PanelGamePanel.Controls.Add(gameGrid.board[row, col]);

                            // Unsubscribe from the GameBoard_Click event since you lost
                            gameGrid.board[row, col].MouseUp -= GameBoard_Click;

                            if (gameGrid.board[row, col].IsLive)
                            {
                                gameGrid.board[row, col].BackgroundImageLayout = ImageLayout.Stretch;
                                gameGrid.board[row, col].BackgroundImage = fantasticOctoWaddle.Resource.bomb;
                            }
                        }
                    }
                    // resume layout now that board is drawn
                    ResumeLayout();

                    // disable show the board menu item
                    this.HelpToolStripHintShowTheBoard.Enabled = false;

                    // assign player score.
                    Player.PlayerScore = GameTimer.Elapsed.Seconds;

                    // Show the lose message.
                    MessageBox.Show("BOOM!  YOU LOSE! \nTime Elapsed: " + GameTimer.Elapsed.ToString("hh\\:mm\\:ss"));
                    break;
            }

        }

    }
}
