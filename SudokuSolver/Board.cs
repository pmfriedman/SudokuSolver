using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuSolver
{
    public class Board
    {
        private int?[] _spaces;

        public Board()
        {
            _spaces = new int?[81];
        }

        public IEnumerable<int> OpenSpaces()
        {
            return Enumerable.Range(0, 81).Where(s => !_spaces[s].HasValue);
        }

        public bool IsValidMove(Move move)
        {
            return 
                !_spaces[move.Space].HasValue &&
                IsValidMoveForSquare(move) && 
                IsValidMoveForRow(move) && 
                IsValidMoveForColumn(move);
        }

        public void MakeMove(Move move)
        {
            _spaces[move.Space] = move.Value;
        }

        public void ClearSpace(int ix)
        {
            _spaces[ix] = null;
        }

        public bool IsSolved()
        {
            return _spaces.All(s => s.HasValue);
        }

        public override string ToString()
        {
            char vert = '|';
            char horiz = '-';

            var sb = new StringBuilder();
            for (int row = 0; row < 9; row++)
            {
                if (row == 0)
                    sb.AppendLine(new string(horiz, 24));

                for (int col = 0; col < 9; col++)
                {
                    if (col == 0)
                        sb.Append(vert + " ");

                    var val = GetValue(row, col);
                    if (val.HasValue)
                        sb.Append(val.ToString());
                    else
                        sb.Append(" ");

                    sb.Append(" ");
                    if (col % 3 == 2)
                        sb.Append(vert + " ");
                }

                sb.AppendLine();
                if (row % 3 == 2)                    
                    sb.AppendLine(new string(horiz, 24));
            }

            return sb.ToString();
        }

        private int? GetValue(int row, int col)
        {
            return _spaces[row * 9 + col];
        }

        public static int GetSpace(int row, int col)
        {
            return row * 9 + col;
        }

        private int RowOf(int ix)
        {
            return ix / 9;
        }

        private int ColOf(int ix)
        {
            return ix % 9;
        }

        private (int col, int row) SquareOriginOf(int ix)
        {
            return (ColOf(ix) / 3 * 3, RowOf(ix) / 3 * 3);
        }

        private bool IsValidMoveForSquare(Move move)
        {
            var squareOrigin = SquareOriginOf(move.Space);
            for (int col = squareOrigin.col; col < squareOrigin.col + 3; col++)
            {
                for (int row = squareOrigin.row; row < squareOrigin.row + 3; row++)
                {
                    if (GetValue(row, col) == move.Value)
                        return false;
                }
            }
            return true;
        }

        private bool IsValidMoveForRow(Move move)
        {
            int row = RowOf(move.Space);
            for(int col = 0; col < 9; col++)
            {
                if (GetValue(row, col) == move.Value)
                    return false;
            }
            return true;
        }

        private bool IsValidMoveForColumn(Move move)
        {
            int col = ColOf(move.Space);
            for (int row = 0; row < 9; row++)
            {
                if (GetValue(row, col) == move.Value)
                    return false;
            }
            return true;
        }
    }
}
