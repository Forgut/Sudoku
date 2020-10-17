using Sudoku.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.Logic.FillMethods
{
    public abstract class BaseFillator : IFillator
    {
        protected Board _board;

        public BaseFillator(Board board)
        {
            _board = board;
        }
        public abstract void Fill();

        private bool _valueWasFilled;

        public bool ValueWasFilled
        {
            get
            {
                return _valueWasFilled;
            }
            set
            {
                if (!_valueWasFilled)
                    _valueWasFilled = value;
            }
        }
    }
}
