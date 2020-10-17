using NUnit.Framework;
using Sudoku.Entities;
using Sudoku.Logic.Solver;

namespace Sudoku.Tests
{
    public class SolverTests
    {
        [Test]
        public void FindNumber7()
        {
            int?[,] boardArray = new int?[,]
            {
                { null, null, null, 5, 6, null, null, 7, null },
                { 4, 5, null, null, 9, 7, null, null, null },
                { null, null, 6, null, null, null, null, null, 1 },

                { 5, 4, null, 9, null, null, null, null, 7 },
                { null, null, null, null, null, null, null, 9, 4 },
                { 1, 9, null, null, 7, 3, null, null, null },

                { null, 7, 4, null, null, null, 1, null, 3 },
                { 2, null, null, null, null, null, null, null, 9 },
                { null, null, null, 2, 1, null, null, null, 6 },

            };
            var board = new Board(boardArray);
            var solver = new Solver(board);
            solver.FindNextNumber();
            Assert.AreEqual(board[2, 0].Value, 7);

        }
    }
}
