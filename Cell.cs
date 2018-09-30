using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fantasticOctoWaddle
{
    public class Cell : Button
    {

        public int Row { get; set; }
        public int Col { get; set; }
        public bool HasBeenVisited {get; set;}
        public bool IsLive { get; set; }
        public int NumLiveNeighbors { get; set; }
        public bool IsFlagged { get; set; }

        public Cell()
        {
            Row = -1;
            Col = -1;
            HasBeenVisited = false;
            IsLive = false;
            NumLiveNeighbors = 0;
            this.Width = 25;
            this.Height = 25;
            IsFlagged = false;
        }
    }
}
