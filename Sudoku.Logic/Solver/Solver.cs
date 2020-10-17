using Sudoku.Entities;
using Sudoku.Enums;
using Sudoku.Logic.EliminationMetods;
using Sudoku.Logic.FillMethods;
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
        private IEnumerable<IFillator> Fillators;
        public Solver(Board board)
        {
            _board = board;
            Eliminators = new List<IEliminator>()
            {
                new RowsAndColumnsEliminator(_board),
                new SquareEliminator(_board),
                new RowsAndColumnsDoublePossibilityEliminator(_board),
            };
            Fillators = new List<IFillator>()
            {
                new OnlyOnePossibilityFillator(_board) {StopAfterFirstFound = true },
                new OnePossibilityInSquareFillator(_board) {StopAfterFirstFound = true },
            };
        }
        public ESearchResult FindNextNumber()
        {
            if (_board.IsFull())
                return ESearchResult.SudokuSolved;
            foreach (var eliminator in Eliminators)
                eliminator.Eliminate();
            foreach (var fillator in Fillators)
            {
                fillator.Fill();
                if (fillator.ValueWasFilled)
                    break;
            }
            return ESearchResult.FoundNumber;
        }
    }
}
