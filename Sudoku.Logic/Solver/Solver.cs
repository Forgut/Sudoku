using Sudoku.Entities;
using Sudoku.Enums;
using Sudoku.Logic.EliminationMetods;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Sudoku.Logic.Solver
{
    public class Solver
    {
        private Board _board { get; set; }
        private IEnumerable<IEliminator> Eliminators;
        public Solver(Board board)
        {
            _board = board;
            Eliminators = new List<IEliminator>()
            {
                new RowsAndColumnsEliminator(_board),
                new SquareEliminator(_board),
            };
        }
        public ESearchResult FindNextNumber()
        {
            if (_board.IsFull())
                return ESearchResult.SudokuSolved;
            foreach (var eliminator in Eliminators)
                eliminator.Eliminate();
            FillTilesWithOnePossibility(quitAfterFirstOne: false);
            return ESearchResult.FoundNumber;
        }

        private void FillTilesWithOnePossibility(bool quitAfterFirstOne = false)
        {
            foreach (var tile in _board.Tiles)
                if (tile.SetValueIfOnlyOnePossible())
                {
                    _board.SetLastInsertedTile(tile);
                    if (quitAfterFirstOne)
                        return;
                }
        }
    }
}
