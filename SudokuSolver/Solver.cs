using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class Solver
    {
        /// <summary>
        /// Solves the game
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        public bool Solve(Game game)
        {
            int numBacktracks = 0;
            bool success = DepthFirstSolver(game, ref numBacktracks);
            return success;
        }

        private bool DepthFirstSolver(Game game, ref int numBacktracks)
        {
            var moves = GetListOfCandidateMoves(game.Board);

            foreach (var move in moves)
            {
                game.MakeMove(move);
                if (DepthFirstSolver(game, ref numBacktracks))
                    return true;
                numBacktracks++;
                game.Undo();
            }
            return game.Board.IsSolved();
        }

        private List<Move> GetListOfCandidateMoves(Board board)
        {
            var candidates = new List<Move>();
            foreach (var space in board.OpenSpaces())
            {
                bool hasValidMoves = false;
                for (int val = 1; val <= 9; val++)
                {
                    var move = new Move() { Space = space, Value = val };
                    if (board.IsValidMove(move))
                    {
                        candidates.Add(move);
                        hasValidMoves = true;
                    }
                }
                if (!hasValidMoves)
                    return new List<Move>();
            }

            return candidates.GroupBy(m => m.Space).OrderBy(m => m.Count()).FirstOrDefault()?.ToList() ?? new List<Move>();
        }
    }
}
