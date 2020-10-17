using Sudoku.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.Frontend.ViewModels
{
    public class TileViewModel
    {
        public int? Value { get; set; }
        public bool HasValue => Value.HasValue;
        public int X { get; set; }
        public int Y { get; set; }
        public IEnumerable<int> Possibilities { get; private set; }
        public TileViewModel(Tile tile)
        {
            Value = tile.Value;
            Possibilities = tile.Possibilites;
            X = tile.X;
            Y = tile.Y;
        }
    }
}
