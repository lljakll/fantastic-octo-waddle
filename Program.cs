// Jackie A. Adair
// CST-227 Enterprise Application Development II
// Topic 5 Milestone 6 
// git clone -b Milestone-6 https://github.com/lljakll/fantastic-octo-waddle.git
// This is my own work


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
            Application.Run(new frmMain());
        }
    }
}
