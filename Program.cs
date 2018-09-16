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
                // Declare Grid object
                MineSweeperGame myGame;

                // Get the size of the board.  Must be greater than 9
                Console.WriteLine("Enter the Board Size (Must be 10-50). ");

                // Check for valid input.
                string input = Console.ReadLine();
                bool isString = int.TryParse(input, out int boardSize);

                // Check for proper boardsize and instantiate the Grid object.
                // change "boardSize > 3" to test the winner scenario.  Hint: it does work...
                if (boardSize < 51 && boardSize > 9)
                {
                    myGame = new MineSweeperGame(boardSize);
                }
                else
                {
                    // if bad input, instantiate a 10x10 board.
                    Console.WriteLine("Size must be at least 10 but no more than 50.  Generating a 10x10 board.  Press any key.");
                    Console.ReadKey();
                    myGame = new MineSweeperGame(10);
                }

                // start the game
                myGame.PlayGame();

                // Ask to play again
                Console.WriteLine("Would you like to play again?");
                string userChoice = Console.ReadLine();

                if (userChoice == "y" || userChoice == "Y")
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
