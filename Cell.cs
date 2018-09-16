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
    // Cell Class
    public class Cell
    {
        // Propterties with Auto Implemented Properties
        public int Row { get; set; }
        public int Col { get; set; }
        public bool HasBeenVisited { get; set; }
        public bool IsLive { get; set; }
        public int NumLiveNeighbors { get; set; }

        // Constructor
        public Cell()
        {
            Row = -1;
            Col = -1;
            HasBeenVisited = false;
            IsLive = false;
            NumLiveNeighbors = 0;
        }
    }
}
