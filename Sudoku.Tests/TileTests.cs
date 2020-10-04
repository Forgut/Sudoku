using NUnit.Framework;
using NUnit.Framework.Constraints;
using Sudoku.Entities;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace Sudoku.Tests
{
    public class TileTests
    {
        [Test]
        public void TileTooMuchPossibilitiesTest()
        {
            var tile = new Tile(0, 0, possibilities: new List<int>() { 1, 2, 3 });
            Assert.AreEqual(tile.Value, null);
            tile.SetValueIfOnlyOnePossible();
            Assert.AreEqual(tile.Value, null);
        }

        [Test]
        public void TileWithOnePossibilityTest()
        {
            var tile = new Tile(0, 0, possibilities: new List<int>() { 2 });
            Assert.AreEqual(tile.Value, null);
            tile.SetValueIfOnlyOnePossible();
            Assert.AreEqual(tile.Value, 2);
        }
        [Test]
        public void TileSetValueNoPossibilitiesTest()
        {
            var tile = new Tile(0, 0);
            Assert.AreEqual(tile.Possibilites, new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            tile.SetValue(4);
            Assert.AreEqual(tile.Possibilites, new List<int>());
        }
    }
}