using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace fantasticOctoWaddle
{
    public partial class Scores : Form
    {
        // This will contain a complete list of PlayerStat's from the file
        List<PlayerStats> scoreBoard;

        // This will contain only the top 5 PlayerStats from the difficulty selected
        List<PlayerStats> Top5Players;

        // The data file must be located in the same directory as the executable.
        // The executable will create it in its folder if it is not found
        // Format is one PlayerStat per line. - <name>,<difficulty (1-3)>, score in seconds.
        string file = "scores.dat";

        // Constructor
        public Scores()
        {
            InitializeComponent();

            scoreBoard = new List<PlayerStats>();
            Top5Players = new List<PlayerStats>();

        }

        // Write the PlayerStat object to the data file and add it to the List<>
        public void WriteScore(PlayerStats playerGame)
        {
            scoreBoard.Add(playerGame);
            StreamWriter scoreFile = File.AppendText(file);
            scoreFile.WriteLine(playerGame.PlayerName.ToString() + "," + playerGame.PlayerLevel.ToString() + "," + playerGame.PlayerScore.ToString());
            scoreFile.Close();
        }

        // Read scrores from the file into the List<> Collection
        public void ReadScoresToCollection()
        {
            // Make sure the collection is clear
            scoreBoard.Clear();
            // Create file if not exists
            StreamWriter scoreFile = File.AppendText(file);
            scoreFile.Close();

            string inputCatcher;
            StreamReader readScores = new StreamReader(file);

            // Read each line from the file until the end
            while((inputCatcher=readScores.ReadLine()) != null)
            {
                // Split the line into a temp string array then add it to the scoreBoard List<> as a PlayerStat object
                string[] temp = inputCatcher.Split(',');
                scoreBoard.Add(new PlayerStats() { PlayerName = temp[0], PlayerLevel = int.Parse(temp[1]), PlayerScore = int.Parse(temp[2]) });
            }

            readScores.Close();
            
        }

        // using LINQ, filter the scoreBoard List by difficulty, order it by socre then add the top 5 to the PopulateTop5 List<>
        public void PopulateTop5(int difficulty)
        {
            // Display the difficulty on the scoreboard
            switch (difficulty)
            {
                case 1:
                    TBDifficultyText.Text = "Easy";
                    break;
                case 2:
                    TBDifficultyText.Text = "Moderate";
                    break;
                case 3:
                    TBDifficultyText.Text = "Hard";
                    break;
            }

            // Presort the scoreBoard...Probably not necessary
            scoreBoard.Sort();

            // LINQ for getting the top 5 scores from the passed difficulty level
            var query = from x in scoreBoard
                        where x.PlayerLevel == difficulty
                        orderby x.PlayerScore ascending                        
                        select x;
            
            // grab the top 5
            foreach (var y in query.Take(5))
                Top5Players.Add(y);


        }

        // On Form Load actions here
        private void Scores_Load(object sender, EventArgs e)
        {
            // center the form and move to the left side of the GameBoard.  Needs tweaking
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Size.Width / 2) - (this.Size.Width / 2), (Screen.PrimaryScreen.Bounds.Size.Height / 2) - (this.Size.Height / 2));

            string scoreString = "";
            int seconds = 0;
            int minutes = 0;
            int hours = 0;
                        
            // iterate through the Top5Players list and display
            foreach (PlayerStats i in Top5Players)
            {
                // build the score
                if (i.PlayerScore < 60)
                {
                    seconds = i.PlayerScore;
                    minutes = 0;
                    hours = 0;
                }
                else if(i.PlayerScore >= 60 && i.PlayerScore < 3600)
                {
                    seconds = i.PlayerScore % 60;
                    minutes = i.PlayerScore / 60;
                    hours = 0;
                }
                else
                {
                    seconds = i.PlayerScore % 60;
                    minutes = (i.PlayerScore/60) % 60;
                    hours = i.PlayerScore / 3600;
                }

                scoreString = hours.ToString() + "h " + minutes.ToString() + "m " + seconds.ToString() + "s";

                // Populate the listviewwitem with names and scores
                //ListViewItem item = new ListViewItem(new[] { i.PlayerName, scoreString });
                // Populate the List view with ListViewItems
                //LVTop5Scores.Items.Add(item);

                // Datagridview population
                string[] row = new string[] { i.PlayerName, scoreString };
                DGTop5Scores.Rows.Add(row);
                

                // Autoresize the columns
                //this.LVTop5Scores.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            }

        }
        
        // Close button.  Will close the gameBoard too.
        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
