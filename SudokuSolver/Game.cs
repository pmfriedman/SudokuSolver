using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class Game
    {
        private Stack<Move> _moves;

        public Board Board { get; private set; }

        /// <summary>
        /// Initializes a new game, with optional spaces filled in initially.
        /// </summary>
        /// <param name="setup"></param>
        public Game(IEnumerable<Move> setup = null)
        {
            _moves = new Stack<Move>();
            Board = new Board();
            if (setup != null)
            {
                foreach (var setupMove in setup)
                    Board.MakeMove(setupMove);
            }
        }

        public void MakeMove(Move move)
        {
            Board.MakeMove(move);
            _moves.Push(move);
        }

        public void Undo()
        {
            var move = _moves.Pop();
            Board.ClearSpace(move.Space);
        }
    }
}
