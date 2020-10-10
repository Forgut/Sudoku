using Microsoft.VisualStudio.TestPlatform.Utilities;
using NUnit.Framework;
using Sudoku.Entities;
using Sudoku.Logic.EliminationMetods;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku.Tests
{
    public class EliminatorsTests
    {
        [Test]
        public void RowsAndColumnsEliminatorPossibilitiesTest()
        {
            var board = Board.GetEmptyBoard();
            int insertedValue = 5;
            board.SetValueAtPosition(insertedValue, 4, 4);
            Assert.IsTrue(board[4, 3].Possibilites.Contains(insertedValue));
            var eliminator = new RowsAndColumnsEliminator(board);
            Assert.IsFalse(eliminator.ValueWasEliminated);
            eliminator.Eliminate();
            Assert.IsTrue(eliminator.ValueWasEliminated);
            Assert.AreEqual(board[4, 4].Possibilites, new List<int>());
            Assert.IsFalse(board[4, 3].Possibilites.Contains(insertedValue));
            Assert.IsFalse(board[4, 2].Possibilites.Contains(insertedValue));
            Assert.IsFalse(board[1, 4].Possibilites.Contains(insertedValue));
            Assert.IsTrue(board[4, 3].Possibilites.Any());
            Assert.IsTrue(board[4, 2].Possibilites.Any());
            Assert.IsTrue(board[1, 4].Possibilites.Any());
        }

        [Test]
        public void SquareEliminatorTest()
        {
            var board = Board.GetEmptyBoard();
            int insertedValue = 5;
            board.SetValueAtPosition(insertedValue, 4, 4);
            Assert.IsTrue(board[4, 3].Possibilites.Contains(insertedValue));
            var eliminator = new SquareEliminator(board);
            Assert.IsFalse(eliminator.ValueWasEliminated);
            eliminator.Eliminate();
            Assert.IsTrue(eliminator.ValueWasEliminated);
            Assert.AreEqual(board[4, 4].Possibilites, new List<int>());
            Assert.IsFalse(board[3, 3].Possibilites.Contains(insertedValue));
            Assert.IsFalse(board[5, 5].Possibilites.Contains(insertedValue));
            Assert.IsTrue(board[2, 2].Possibilites.Contains(insertedValue));
            Assert.IsTrue(board[3, 3].Possibilites.Any());
            Assert.IsTrue(board[5, 5].Possibilites.Any());
            Assert.IsTrue(board[2, 2].Possibilites.Any());

        }
    }
}
