using Sudoku.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.Frontend.ViewModels
{
    public class TileViewModel
    {
        public int? Value { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public TileViewModel(Tile tile)
        {
            Value = tile.Value;
            X = tile.X;
            Y = tile.Y;
        }
    }
}
