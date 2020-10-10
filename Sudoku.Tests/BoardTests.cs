using NUnit.Framework;
using Sudoku.Entities;
using System.Globalization;

namespace Sudoku.Tests
{
    public class BoardTests
    {
        [Test]
        public void BoardSetValueTest()
        {
            var board = Board.GetEmptyBoard();
            Assert.AreEqual(null, board[3, 3].Value);
            board.SetValueAtPosition(9, 3, 3);
            Assert.AreEqual(9, board[3, 3].Value);
        }

        [Test]
        public void FullBoardTest()
        {
            var board = Board.GetEmptyBoard();
            Assert.IsFalse(board.IsFull());
            for (int i = 0; i < Board.SIZE; i++)
                for (int j = 0; j < Board.SIZE; j++)
                    board.SetValueAtPosition(1, i, j);
            Assert.IsTrue(board.IsFull());
        }
        [Test]
        public void NotFullBoardTest()
        {
            var board = Board.GetEmptyBoard();
            Assert.IsFalse(board.IsFull());
            for (int i = 0; i < Board.SIZE; i++)
                for (int j = 0; j < Board.SIZE; j++)
                    board.SetValueAtPosition(1, i, j);
            board.ClearPosition(4, 5);
            board.ClearPosition(1, 2);
            board.ClearPosition(4, 3);
            Assert.IsFalse(board.IsFull());
        }

    }
}
