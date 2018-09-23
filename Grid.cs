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

                    // set each Cell Objects location
                    // Setting this now since we are already iterating through the array
                    board[row, col].Location = new Point(row * 25, col * 25);


                }
            }


        }
    }
}
