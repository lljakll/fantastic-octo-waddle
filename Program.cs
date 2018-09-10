// CST 227 - Enterprise Application Development II
// Jackie A. Adair
// T2 - Milestone 2
// This is my original work

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST227_Milestones
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                // Declare Grid object
                MineSweeperGame myGame;

                // Get the size of the board.  Must be greater than 9
                Console.WriteLine("Enter the Board Size (Must be 10 or greater). ");

                // Check for valid input.
                string input = Console.ReadLine();
                bool isString = int.TryParse(input, out int boardSize);

                // Check for proper boardsize and instantiate the Grid object.
                // change "boardSize > 3" to test the winner scenario.  Hint: it does work...
                if (boardSize > 3)
                {
                    myGame = new MineSweeperGame(boardSize);
                }
                else
                {
                    // if bad input, instantiate a 10x10 board.
                    Console.WriteLine("Size must be at least 10.  Generating a 10x10 board.  Press any key.");
                    Console.ReadKey();
                    myGame = new MineSweeperGame(10);
                }

                // start the game
                myGame.PlayGame();
            }
            catch(Exception ex)
            {
                Console.WriteLine("There was an error: {0}", ex.Message);
            }

        }
    }
}
