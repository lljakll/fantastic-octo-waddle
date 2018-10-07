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
        List<PlayerStats> scoreBoard;
        List<PlayerStats> Top5Players;
        string file = "scores.dat";

        public Scores()
        {
            InitializeComponent();

            scoreBoard = new List<PlayerStats>();
            Top5Players = new List<PlayerStats>();

        }

        public void WriteScore(PlayerStats playerGame)
        {
            scoreBoard.Add(playerGame);
            StreamWriter scoreFile = File.AppendText(file);
            scoreFile.WriteLine(playerGame.PlayerName.ToString() + "," + playerGame.PlayerLevel.ToString() + "," + playerGame.PlayerScore.ToString());
            scoreFile.Close();
        }

        public void ReadScoresToCollection()
        {
            scoreBoard.Clear();
            // Create file if not exists
            StreamWriter scoreFile = File.AppendText(file);
            scoreFile.Close();

            string inputCatcher;
            StreamReader readScores = new StreamReader(file);

            while((inputCatcher=readScores.ReadLine()) != null)
            {
                string[] temp = inputCatcher.Split(',');
                scoreBoard.Add(new PlayerStats() { PlayerName = temp[0], PlayerLevel = int.Parse(temp[1]), PlayerScore = int.Parse(temp[2]) });
            }

            readScores.Close();
            
        }

        public void PopulateTop5(int difficulty)
        {
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

            scoreBoard.Sort();

            var query = from x in scoreBoard
                        where x.PlayerLevel == difficulty
                        orderby x.PlayerScore ascending                        
                        select x;
            
            foreach (var y in query.Take(5))
                Top5Players.Add(y);


        }

        private void Scores_Load(object sender, EventArgs e)
        {
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Size.Width / 2) - (this.Size.Width / 2)-275, (Screen.PrimaryScreen.Bounds.Size.Height / 2) - (this.Size.Height / 2)-20);

            string scoreString = "";
            int seconds = 0;
            int minutes = 0;
            int hours = 0;
                        
            foreach (PlayerStats i in Top5Players)
            {
                seconds = i.PlayerScore % 60;
                minutes = i.PlayerScore / 60;
                hours = i.PlayerScore / 3600;
                scoreString = hours.ToString() + "h " + minutes.ToString() + "m " + seconds.ToString() + "s";
                ListViewItem item = new ListViewItem(new[] { i.PlayerName, scoreString });

                LVTop5Scores.Items.Add(item);

                this.LVTop5Scores.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            }

        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
