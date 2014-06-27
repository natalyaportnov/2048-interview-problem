using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048Implementation
{
    public class Cell
    {
        public int Value { get; set; }
        public int Row { get; private set; }
        public int Col { get; private set; }
        public bool Merged { get; set; }

        public Cell(int value, int row, int col)
        {
            Value = value;
            Row = row;
            Col = col;
            Merged = false;
        }

        public bool Empty
        {
            get { return Value == 0; }
        }
    }
}
