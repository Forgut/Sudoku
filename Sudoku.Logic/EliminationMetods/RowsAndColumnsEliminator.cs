using Sudoku.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku.Logic.EliminationMetods
{
    public class RowsAndColumnsEliminator : BaseEliminator
    {

        public RowsAndColumnsEliminator(Board board) : base(board)
        {

        }
        public override void Eliminate()
        {
            foreach (var tile in _board.Tiles.Where(t => t.HasValue))
                EliminateForTile(tile);
        }

        private void EliminateForTile(Tile originalTile)
        {
            foreach (var tile in _board.GetTilesInColumn(originalTile.Y))
                ValueWasEliminated = tile.RemovePossibility(originalTile.Value.Value);
            foreach (var tile in _board.GetTilesInRow(originalTile.X))
                ValueWasEliminated = tile.RemovePossibility(originalTile.Value.Value);
        }
    }
}
