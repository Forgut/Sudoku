using Sudoku.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.Logic.FillMethods
{
    public class OnlyOnePossibilityFillator : BaseFillator
    {
        public OnlyOnePossibilityFillator(Board board) : base(board)
        {

        }
        public override void Fill()
        {
            foreach (var tile in _board.Tiles)
                if (tile.SetValueIfOnlyOnePossible())
                {
                    _board.SetLastInsertedTile(tile);
                    ValueWasFilled = true;
                    if (StopAfterFirstFound)
                        return;
                }
        }
    }
}
