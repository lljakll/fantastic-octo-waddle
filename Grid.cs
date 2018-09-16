// CST 227 - Enterprise Application Development II
// Jackie A. Adair
// T3 - Milestone 3
// This is my original work

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST227_Milestones
{
    // Grid Class
    public abstract class Grid
    {
        // Properties
        public readonly Cell[,] board;

        // Constructor (Add parameterless constructor for inheritence)
        public Grid()
        {
            try
            {
                int size = 10;
                // initialize the board with Cells
                board = new Cell[size, size];
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        board[i, j] = new Cell();
                        // load the cell's row and col into its row/col properties
                        board[i, j].Row = i;
                        board[i, j].Col = j;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error initializing the game board: {0}", ex.Message);
            }
        }
        public Grid(int size)
        {
            try
            {
                // initialize the board with Cells
                board = new Cell[size, size];
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        board[i, j] = new Cell();
                        // load the cell's row and col into its row/col properties
                        board[i, j].Row = i;
                        board[i, j].Col = j;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error initializing the game board: {0}", ex.Message);
            }
        }
        // Methods

        // Activate 20% of the cells (toggle live)
        public virtual void Activate()
        {
            Random rnd = new Random();

            // use this.length so it calc's 20% of ALL elements in 2d Array
            for (int i = 0; i < .2 * board.Length; i++)
            {
                int rndRow = rnd.Next(0, board.GetLength(0));
                int rndCol = rnd.Next(0, board.GetLength(1));

                // check to see if the cell is already live.  If so, decrement so we
                // can repeat this instance of the for loop
                if (board[rndRow, rndCol].IsLive == false)
                {
                    board[rndRow, rndCol].IsLive = true;
                }
                else
                {
                    i--;
                }
            }

        }

        // Calculate and populate each cell's neighbor values
        public virtual void PopulateNeighborValues()
        {
            // iterate through the rows
            for (int i = 0; i < board.GetLength(0); i++)
            {
                // iterate through the columns
                for (int k = 0; k < board.GetLength(1); k++)
                {
                    // tally variable declaration
                    int tmpVal = 0;
                    // check to see if the cell is live.  if so...set the NumLiveNeighbors to 9
                    if (board[i, k].IsLive)
                    {
                        board[i, k].NumLiveNeighbors = 9;
                    }
                    else
                    {
                        // iterate through the cells around the active cell
                        for (int nei = -1; nei < 2; nei++)
                        {
                            for (int nek = -1; nek < 2; nek++)
                            {
                                // check to see if each cell around the active cell is live
                                // if it is, increment the tally variable
                                if(i+nei >=0 && i+nei < board.GetLength(0) && k+nek >=0 && k+nek < board.GetLength(1))
                                {
                                    if (board[i + nei, k + nek].IsLive) { tmpVal++; }
                                }                                                            
                            }
                        }
                    }
                    // assign the tally to the cell's property
                    board[i, k].NumLiveNeighbors = tmpVal;
                }
            }
        }


        // Display the Grid
        public virtual void RevealGrid()
        {
            Console.Clear();
            // add column ref system
            for (int i = 0; i <= board.GetLength(1); i++)
            {
                if (i == 0)
                    Console.Write("  ");
                else if (i < 10)
                    Console.Write(" {0}", i);
                else
                    Console.Write("{0}", i);
            }
            Console.WriteLine();


            // Iterate through the board and display the value if
            // the cell is not live, and an asterik if it is

            for (int i = 0; i < board.GetLength(0); i++)
            {
                // add row reference system
                if (i < 9)
                    Console.Write(" {0}", i + 1);
                else
                    Console.Write("{0}", i + 1);


                for (int k = 0; k < board.GetLength(1); k++)
                {
                    if (board[i, k].IsLive == true)
                    {
                        // if val is 9...asterisk
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" *");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        // LiveNeighbor if the val is not 9
                        Console.Write(" {0}", board[i, k].NumLiveNeighbors);

                        // Just to make sure the row/col were properly set.
                        //Console.Write(" {0},{1}", board[i, k].Row,board[i,k].Col);
                    }
                }
                Console.WriteLine();
            }
        }


    }

}
