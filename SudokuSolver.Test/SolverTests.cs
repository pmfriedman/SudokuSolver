using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace SudokuSolver.Test
{
    [TestFixture]
    public class SolverTests
    {
        [Test]
        public void EmptyBoard_Succeeds()
        {
            var solver = new Solver();
            var game = new Game();
            var isSolved = solver.Solve(game);
            Assert.That(isSolved, Is.True);
        }

        [Test]
        public void MostDifficultPuzzleEverCreated_Succeeds()
        {
            var solver = new Solver();
            var game = new Game(new List<Move>
            {
                // This is allegedly the most difficult sudoku puzzle ever created
                // https://punemirror.indiatimes.com/pune/cover-story/mirror-report-on-illegal-laying-of-cables-raises-heat-in-pmc-meet/articleshow/32299745.cms
                new Move(0, 2, 5),
                new Move(0, 3, 3),

                new Move(1, 0, 8),
                new Move(1, 7, 2),

                new Move(2, 1, 7),
                new Move(2, 4, 1),
                new Move(2, 6, 5),

                new Move(3, 0, 4),
                new Move(3, 5, 5),
                new Move(3, 6, 3),

                new Move(4, 1, 1),
                new Move(4, 4, 7),
                new Move(4, 8, 6),

                new Move(5, 2, 3),
                new Move(5, 3, 2),
                new Move(5, 7, 8),

                new Move(6, 1, 6),
                new Move(6, 3, 5),
                new Move(6, 8, 9),

                new Move(7, 2, 4),
                new Move(7, 7, 3),

                new Move(8, 5, 9),
                new Move(8, 6, 7),

            });
            var isSolved = solver.Solve(game);
            Assert.That(isSolved, Is.True);
        }
    }
}
