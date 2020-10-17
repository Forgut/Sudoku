using Sudoku.Entities;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Sudoku.Logic.EliminationMetods
{
    public class RowsAndColumnsDoublePossibilityEliminator : BaseEliminator
    {

        public RowsAndColumnsDoublePossibilityEliminator(Board board) : base(board)
        {

        }
        public override void Eliminate()
        {
            var squares = _board.Tiles
                .GroupBy(x => x.Square);
            foreach (var square in squares)
            {
                foreach (var possibility in Tile.AllPossibilities)
                {
                    var tilesWithThisPossibilityInSquare = square
                        .Where(x => x.Possibilites.Contains(possibility));
                    if (tilesWithThisPossibilityInSquare.Count() == 2)
                    {
                        var tile1 = tilesWithThisPossibilityInSquare.ElementAt(0);
                        var tile2 = tilesWithThisPossibilityInSquare.ElementAt(1);
                        if (tile1.X == tile2.X)
                            foreach (var tile in _board.GetTilesInRow(tile1.X))
                                ValueWasEliminated = tile.RemovePossibility(possibility);
                        if (tile1.Y == tile2.Y)
                            foreach (var tile in _board.GetTilesInColumn(tile1.Y))
                                ValueWasEliminated = tile.RemovePossibility(possibility);
                    }
                }
            }
        }
    }
}
