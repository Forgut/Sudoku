using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.Logic.FillMethods
{
    interface IFillator
    {
        void Fill();
        bool ValueWasFilled { get; set; }
        void ResetValueWasFilled();
    }
}
