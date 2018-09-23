// Jackie A. Adair
// CST-227 Enterprise Application Development II
// Topic 4 Milestone 4 
// git clone -b Milestone-4 https://github.com/lljakll/fantastic-octo-waddle.git
// This is my own work

// TODO: Add arrow key functionality to navigate.  Add hotkeys for flagging and selecting
// TODO: Add menu bar to select new game, exit, difficulty level, show board, high scores


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fantasticOctoWaddle
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Call the LevelSelect Form to start the application
            Application.Run(new LevelSelect());
        }
    }
}
