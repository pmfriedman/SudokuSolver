using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public struct Move
    {
        public int Space;
        public int Value;

        public Move(int space, int val)
        {
            Space = space;
            Value = val;
        }
        public Move(int row, int col, int val)
        {
            Space = Board.GetSpace(row, col);
            Value = val;
        }
    }
}
