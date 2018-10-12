using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasticOctoWaddle
{
    public class Grid
    {
        public Cell[,] board;

        // Constructors
        public Grid(int size)
        {
            board = new Cell[size, size];
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    // Initialize the array with Cell Objects
                    board[row, col] = new Cell();

                    // Set the Cell Row and Col Properties for the Cell 
                    // Object assigned to this element of the array
                    board[row, col].Row = row;
                    board[row, col].Col = col;

                    // Set the Cell Font, Text to blank, and Name to R<row>C<col>
                    board[row, col].Font = new Font("Microsoft Sans Serif",6.5F);
                    board[row, col].Text = "";
                    board[row,col].Name = "R" + board[row, col].Row.ToString() + "C" + board[row, col].Col.ToString();
                    board[row, col].ForeColor = System.Drawing.Color.Black;

                    // set each Cell Objects location
                    // Setting this now since we are already iterating through the array
                    // Add 25 to the column to move it down and allow for the Menu Strip
                    board[row, col].Location = new Point(row * 25, 25 + col * 25);
                }
            }


        }

        // Activate 20% of the cells (toggle the live randomly)
        public virtual void Activate(double percentActive)
        {
            Random rnd = new Random();

            // use this.length so it calc's 20% of ALL elements in 2d Array
            for (int i = 0; i < percentActive * board.Length; i++)
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

        // Calculate and populate each cell's naeighbor values
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
                                if (i + nei >= 0 && i + nei < board.GetLength(0) && k + nek >= 0 && k + nek < board.GetLength(1))
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
    }
}
