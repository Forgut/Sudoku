using Microsoft.VisualStudio.TestPlatform.Utilities;
using NUnit.Framework;
using Sudoku.Entities;
using Sudoku.Logic.EliminationMetods;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

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

        [Test]
        public void RowsAndColumnsDoubleValueEliminatorColumnTest()
        {
            var board = Board.GetEmptyBoard();
            var tilesToRemovePossibility1 = board.Tiles
                 .Where(x => x.Square == 0)
                 .Where(x => !(x.X == 0 && x.Y == 0))
                 .Where(x => !(x.X == 1 && x.Y == 0));
            foreach (var tile in tilesToRemovePossibility1)
                tile.RemovePossibility(1);
            //after this in first square possibility of 1 should look like this:
            // 1 0 0
            // 1 0 0 
            // 0 0 0 
            Assert.IsTrue(board[0, 0].Possibilites.Contains(1));
            Assert.IsTrue(board[1, 0].Possibilites.Contains(1));
            Assert.IsTrue(board[4, 0].Possibilites.Contains(1));
            Assert.IsTrue(board[7, 0].Possibilites.Contains(1));
            var eliminator = new RowsAndColumnsDoublePossibilityEliminator(board);
            eliminator.Eliminate();
            Assert.IsTrue(board[0, 0].Possibilites.Contains(1));
            Assert.IsTrue(board[1, 0].Possibilites.Contains(1));
            Assert.IsFalse(board[4, 0].Possibilites.Contains(1));
            Assert.IsFalse(board[7, 0].Possibilites.Contains(1));
            Assert.IsFalse(!board.Tiles.Where(x => x.X != 0).Any(x => x.Possibilites.Contains(1)));
        }

        [Test]
        public void RowsAndColumnsDoubleValueEliminatorRowTest()
        {
            var board = Board.GetEmptyBoard();
            var tilesToRemovePossibility1 = board.Tiles
                 .Where(x => x.Square == 0)
                 .Where(x => !(x.X == 0 && x.Y == 0))
                 .Where(x => !(x.X == 0 && x.Y == 1));
            foreach (var tile in tilesToRemovePossibility1)
                tile.RemovePossibility(1);
            //after this in first square possibility of 1 should look like this:
            // 1 1 0
            // 0 0 0 
            // 0 0 0 
            Assert.IsTrue(board[0, 0].Possibilites.Contains(1));
            Assert.IsTrue(board[0, 1].Possibilites.Contains(1));
            Assert.IsTrue(board[0, 4].Possibilites.Contains(1));
            Assert.IsTrue(board[0, 7].Possibilites.Contains(1));
            var eliminator = new RowsAndColumnsDoublePossibilityEliminator(board);
            eliminator.Eliminate();
            Assert.IsTrue(board[0, 0].Possibilites.Contains(1));
            Assert.IsTrue(board[0, 1].Possibilites.Contains(1));
            Assert.IsFalse(board[0, 4].Possibilites.Contains(1));
            Assert.IsFalse(board[0, 7].Possibilites.Contains(1));
            Assert.IsFalse(!board.Tiles.Where(x => x.Y != 0).Any(x => x.Possibilites.Contains(1)));
        }
    }
}
