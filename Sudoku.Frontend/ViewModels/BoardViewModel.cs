using Sudoku.Entities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Sudoku.Frontend.ViewModels
{
    public class BoardViewModel
    {
        public IEnumerable<TileViewModel> Tiles { get; set; }
        public BoardViewModel(Board board)
        {
            Tiles = board.Tiles.Select(x => new TileViewModel(x));
        }
        public TileViewModel this[int i, int j]
        {
            get => Tiles.FirstOrDefault(x => x.X == i && x.Y == j);
        }
    }
}
