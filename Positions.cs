using System;
using System.Collections.Generic;
using System.Text;
 
namespace TicTacToe
{
        public class Positions
        {
            public int Row { get; set; }
            public int Column { get; set; }
            public Positions(int row, int column)
            {
                Row = row;
                Column = column;
            }
        }
}