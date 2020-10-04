using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.Logic.EliminationMetods
{
    public interface IEliminator
    {
        void Eliminate();
        bool ValueWasEliminated { get; set; }
    }
}
