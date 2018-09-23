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
                    board[row, col] = new Cell();
                    board[row, col].Row = row;
                    board[row, col].Col = col;

                    board[row, col].Font = new Font("Microsoft Sans Serif",6.5F);
                    board[row, col].Text = "";
                    board[row,col].Name = "R" + board[row, col].Row.ToString() + "C" + board[row, col].Col.ToString();

                    board[row, col].Location = new Point(row * 25, col * 25);


                }
            }


        }
    }
}
