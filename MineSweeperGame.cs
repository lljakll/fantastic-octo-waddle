﻿// CST 227 - Enterprise Application Development II
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
    public class MineSweeperGame : Grid , IPlayable
    {
        // had to add a parameterless constructor because I kept
        // getting an error: There is no argument given that corresponds
        // to the required formal pararmeter...
        // https://stackoverflow.com/questions/30696006/inheritance-with-base-class-constructor-with-parameters

        // Constructor   
        public MineSweeperGame(int size) : base(size) // base constructor extends to derived constructor
        {
            // Activate 20% of the gameboard
            this.Activate();

            // Populate the neighbor values
            this.PopulateNeighborValues();

        }

        // Implemente PlayGame() as follows:
        // Prompt user for row and col
        // if valid, (on board and not already visited), mark cell as visited
        // if it has a mine, reveal grid, game over message, terminate/anykey press
        // loop until game is over or all cells except mined cells have been visited
        // Clear console after each play so only grid appears at a time.
        // dont forget to translate the human based numbering to 0 based before checking the cell....
        public void PlayGame()
        {
            // gamestate variable
            // 0 = Winner
            // 1 = Alive
            // 2 = Boom
            int gameState = 0;

            // array indexes used to check for live cells
            int userRow = 0;
            int userCol = 0;

            this.RevealGrid();
            do
            {
                try
                {
                    // converted user input row's and col's (1 based notation not 0 from string input.  
                    // gets converted prior to accessing the array becuase if not, errors and confusion will ensue
                    int inputRow = 0;
                    int inputCol = 0;
                    do
                    {
                        // users actual input...finally...just sayin, thats a lot of vairable layers.  Maybe i'll do something about that next week.
                        string userRowInput = null;
                        string userColInput = null;

                        // Update the gameboard


                        Console.WriteLine("Input a cell.");
                        // Get row input
                        Console.Write("Row: ");
                        userRowInput = Console.ReadLine();
                        // Get col input
                        Console.Write("Col: ");
                        userColInput = Console.ReadLine();

                        // determine if is an int by using TryParse.
                        // If not set the input ints to -1 so it forces the loop to iterate
                        if (!int.TryParse(userRowInput, out inputRow) || !int.TryParse(userColInput, out inputCol))
                        {
                            inputRow = inputCol = -1;
                        }

                        // check to see if user input is in bounds of the array
                        if (inputRow < 1 || inputRow > board.GetLength(0) || inputCol < 1 || inputCol > board.GetLength(1))
                        {
                            Console.WriteLine("Sorry, your input is not on the board or is invalid.  \nPress a key to retry.");
                            Console.ReadKey();
                        }
                    }
                    // keep 'doing' while row is > length of row or row is < 1 AND col is > length of col or col is < 1
                    // Remember we are using human readable number base...not 0 base yet.  that changes when we read the array
                    while (inputRow > board.GetLength(0) || inputRow < 1 && inputCol > board.GetLength(1) || inputCol < 1);

                    // adjust user input into 0 based notation <---SEE...I TOLD YOU!
                    // on a side note.  This is a bit dangerous even though i am sure the logic precludes a 0 from 
                    // getting to this point, when debuging I had that happen.  Never underestimate the ingenuity of a human to 
                    // force an array out of bounds.  Maybe next week I'll look into a better way...
                    userRow = inputRow - 1;
                    userCol = inputCol - 1;

                    // Show user what they selected
                    Console.WriteLine("you entered {0},{1}.", inputRow, inputCol);

                    // check to see if cell has been visited
                    if (!board[userRow, userCol].HasBeenVisited)
                    {
                        board[userRow, userCol].HasBeenVisited = true;

                        // if not live, display a message of what is in the cell and ask for a key
                        if (!board[userRow, userCol].IsLive)
                        {
                            RevealGrid();
                            Console.WriteLine();
                            Console.Write("The cell at ");
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("({0},{1})", inputRow, inputCol);
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write(" has ");
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(board[userRow, userCol].NumLiveNeighbors);
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write(" neighbors.");
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("That cell has already been visited and there were {0} neighbors.", board[userRow, userCol].NumLiveNeighbors);
                        Console.ReadKey();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An Error has occured: '{0}'. \nPress any key to exit", ex.Message);
                    Console.ReadKey();
                }

                // Check to see if all cells have been visited
                // Set the gamestate so if the loop doesnt find a false, it will exit the loop (winner)
                // gameState 0 = Winner
                // gameState 1 = Still Alive
                // gameState 2 = Boom

                gameState = 0;  // default to winner
                // Check for winner
                for (int i = 0; i < board.GetLength(0); i++) 
                {
                    for (int k = 0; k < board.GetLength(1); k++)
                    {
                        // Check if cells that are not live have been visited
                        // if any havent, gameState is set to 1
                        if (!board[i, k].IsLive)
                        {
                            if (board[i, k].HasBeenVisited == false) { gameState = 1; }
                        }

                    }
                }

                // check for boom
                if (board[userRow, userCol].IsLive) { gameState = 2; }

            }
            // Loop the whole thing until the gamestate is not 1
            while (gameState == 1);

            // Check gamestate and do the right thing.
            if (gameState == 2)
            {
                // Clear the console, explode the user and wait a keypress.
                base.RevealGrid();
                Console.WriteLine();
                Console.WriteLine("BOOOOMMMMM!!!!");
                Console.WriteLine();
                Console.WriteLine("You Exploded...\nPress a key.");
                Console.ReadKey();
            }
            else if (gameState == 0)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("YOU WIN!!!!!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("You seem to have broken the game.  Not sure how. Run it again and see if you can break it again.");
            }
        }


        // Override the RevealGrid() method from Grid.
        // (CW-jaa) TODO: Change to follow Milestone 2 Reveal Grid Criteria as follows:
        // (CW-jaa) display a ? if a cell has not been visited
        // (CW-jaa) if has been visited, display a ~ if no live neighbors and #  if more than 0
        public override void RevealGrid()
        {
            Console.Clear();
            // Array Iterators i and k move through the array.            
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int k = 0; k < board.GetLength(1); k++)
                {
                    if (board[i, k].HasBeenVisited == true)
                    {
                        // Display LiveNeighbor Number, unless 0 then ~
                        if (board[i, k].NumLiveNeighbors < 1)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(" {0}", "~");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else
                        {
                            // Dispaly num of live neighbors
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(" {0}", board[i, k].NumLiveNeighbors);
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    }
                    else
                    {
                        // display a '?' if the HasBeenVisited != true
                        Console.Write(" {0}", "?");
                    }
                }
                Console.WriteLine();
            }
            // Console.ReadKey();
        }

    }
}