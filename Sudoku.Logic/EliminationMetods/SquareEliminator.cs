using Sudoku.Entities;
using System;
using System.Linq;

namespace Sudoku.Logic.EliminationMetods
{
    public class SquareEliminator : BaseEliminator
    {
        public SquareEliminator(Board board) : base(board)
        {
        }

        public override void Eliminate()
        {
            foreach (var tile in _board.Tiles.Where(t => t.HasValue))
                EliminateInSquare(tile);
        }

        private void EliminateInSquare(Tile originalTile)
        {
            if (!originalTile.HasValue)
                return;
            foreach (var tile in _board.GetTilesInSquare(originalTile.Square))
                ValueWasEliminated = tile.RemovePossibility(originalTile.Value.Value);
        }
    }
}
