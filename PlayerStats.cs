using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fantasticOctoWaddle
{
    public class PlayerStats : IComparable
    {
        public String PlayerName { get; set; }
        public int PlayerScore { get; set; }
        public int PlayerLevel { get; set; }

            public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
