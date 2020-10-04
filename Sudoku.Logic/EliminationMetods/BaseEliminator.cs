using Sudoku.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.Logic.EliminationMetods
{
    public abstract class BaseEliminator : IEliminator
    {
        protected readonly Board _board;

        public BaseEliminator(Board board)
        {
            _board = board;
        }

        private bool _valueWasEliminated;
        public bool ValueWasEliminated
        {
            get => _valueWasEliminated;
            set
            {
                if (!_valueWasEliminated)
                    _valueWasEliminated = value;
            }
        }
        public abstract void Eliminate();
    }
}
