// CST 227 - Enterprise Application Development II
// Jackie A. Adair
// T1 - Milestone 1
// This is my original work

// Rubric Map
// ---Utilize Object composition and encapsulation in a data model.
// Lines - 36-40 (cell properties declared privately)
// Lines - 52-79 (Get/Set)
// Lines - 42-50 (Constructor)
// Lines - 101,102,126,128,150,152,174,190,198 (Board Class utilizes Cell class methods to manipulate cell properties)
// Lines - 86,94 (Board Class has 2D array of Cells)
// ---Model data and manipulate data with a two-dimensional array
// Lines - 86,94 (2d Array of Cells)
// Lines - 161,-169 (Board Class ensures only valid cells are accessed) Used try/catch to prevent out of bounds errors
// Lines - 167,174 (Live cells are accurately counted)
// Lines - 95-104,119-133,150-174 (Cells are accessed and manipulated)
// ---Follows specification and course coding standards
// Lines - Multiple ( contains comments )
// Lines - 4 (statement of own work)
// Lines - 230,237,240,242,244 (Driver class behaves as specified)
// Lines - Multiple (variable names are self-documenting)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST227_Milestones
{
    // Cell Class
    public class Cell
    {
        // Propterties with Auto Implemented Properties
        private int _row;
        private int _col;
        private bool _hasBeenVisited;
        private bool _isLive;
        private int _numLiveNeighbors;

        // Constructor
        public Cell()
        {
            _row = -1;
            _col = -1;
            _hasBeenVisited = false;
            _isLive = false;
            _numLiveNeighbors = 0;
        }

        // getter:setters
        // had trouble figuring out how to access the auto impmlemented properties
        // if they are private.  More research needed.
        public int Row
        {
            get { return _row; }
            set { _row = value; }
        }
        public int Col
        {
            get { return _col; }
            set { _col = value; }
        }
        public bool HasBeenVisited
        {
            get { return _hasBeenVisited; }
            set { _hasBeenVisited = value; }
        }
        public bool IsLive
        {
            get { return _isLive; }
            set { _isLive = value; }
        }
        public int NumLiveNeighbors
        {
            get { return _numLiveNeighbors; }
            set { _numLiveNeighbors = value; }
        }
    }

    // GameBoard Class
    public class GameBoard
    {
        // Properties
        private readonly Cell[,] board;

        // Constructor
        public GameBoard(int size)
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
        public void Activate()
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
        public void PopulateNeighborValues()
        {
            // iterate through the rows
            for (int i = 0; i < board.GetLength(0); i++)
            {
                // iterate through the columns
                for(int k = 0; k < board.GetLength(1); k++)
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
                                // using error catching to prevent out of bounds from crashing the program
                                // not very efficient, but the 8 if/else statements was just as bad.
                                try
                                {
                                    // check to see if each cell around the active cell is live
                                    // if it is, increment the tally variable
                                    if (board[i + nei, k + nek].IsLive) { tmpVal++; }
                                }
                                catch { continue; }
                            }
                        }
                    }
                    // assign the tally to the cell's property
                    board[i, k].NumLiveNeighbors = tmpVal;
                }
            }
        }

        
        // Display the Grid
        public void DisplayGameBoard()
        {
            // Iterate through the board and display the value if
            // the cell is not live, and an asterik if it is

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int k = 0; k < board.GetLength(1); k++)
                {
                    if (board[i, k].IsLive == true)
                    {
                        // if val is 9...asterisk
                        Console.Write(" *");
                    }
                    else
                    {
                        // LiveNeighbor if the val is not 9
                        Console.Write(" {0}", board[i,k].NumLiveNeighbors);
                        
                        // Just to make sure the row/col were properly set.
                        //Console.Write(" {0},{1}", board[i, k].Row,board[i,k].Col);
                    }
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Declare GameBoard object
                GameBoard myGame;

                // Get the size of the board.  Must be greater than 9
                Console.WriteLine("Enter the Board Size (Must be 10 or greater). ");

                // Check for valid input.
                string input = Console.ReadLine();
                bool isString = int.TryParse(input, out int boardSize);

                // Check for proper boardsize and instantiate the GameBoard object.
                if (boardSize > 9)
                {
                    myGame = new GameBoard(boardSize);
                }
                else
                {
                    // if bad input, instantiate a 10x10 board.
                    Console.WriteLine("Size must be at least 10.  Generating a 10x10 board.  Press any key.");
                    Console.ReadKey();
                    myGame = new GameBoard(10);
                }
                // Activate 20% of the gameboard
                myGame.Activate();
                // Populate the neighbor values
                myGame.PopulateNeighborValues();
                // show the gameboard
                myGame.DisplayGameBoard();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
