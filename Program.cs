// CST 227 - Enterprise Application Development II
// Jackie A. Adair
// T3 - Milestone 3
// This is my original work

// Rubric Map
// Write a recursive definition for a given problem
// MineSweeperGame.cs Lines 96, 210-239
// Implement a recursive solution
// Program.cs Line 60, MineSweeperGame.cs Line 230
// Coding Standards
// Lines 1-4

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST227_Milestones
{
    class Program
    {
        public static void Play()
        {
            try
            {
                Console.Clear();
                // Declare Grid object
                MineSweeperGame myGame;

                // Get the size of the board.  Must be greater than 9
                Console.WriteLine("Enter Game Difficulty:\n1-Easy (10)\n2-Normal (20)\n3-Hard (30)");

                // Check for valid input.
                string input = Console.ReadLine();
                int.TryParse(input, out int difficulty);
                int boardSize = 0;

                // Check for proper boardsize and instantiate the Grid object.
                // change "boardSize > 3" to test the winner scenario.  Hint: it does work...
                if (difficulty == 1)
                    boardSize = 10;
                else if (difficulty == 2)
                    boardSize = 20;
                else if (difficulty == 3)
                    boardSize = 30;
                else
                {
                    // if bad input, instantiate a 10x10 board.
                    Console.WriteLine("Please Choose a number 1-3");
                    Console.ReadKey();
                    Play();
                }
                    myGame = new MineSweeperGame(boardSize);

                    // start the game
                    myGame.PlayGame();

                // Ask to play again
                Console.WriteLine("Would you like to play again?");
                string userChoice = Console.ReadLine();

                if (userChoice.ToUpper() == "Y" || userChoice.ToUpper() == "YES")
                    Play();
            }
            catch(Exception ex)
            {
                Console.WriteLine("There was an error: {0}", ex.Message);
            }

        }
        static void Main(string[] args)
        {
            Play();
        }
    }
}
