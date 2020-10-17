using Sudoku.Entities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Sudoku.Frontend.ViewModels
{
    public class BoardViewModel
    {
        private IEnumerable<TileViewModel> _tiles { get; set; }
        public BoardViewModel(Board board)
        {
            _tiles = board.Tiles.Select(x => new TileViewModel(x));
        }
        public TileViewModel this[int i, int j]
        {
            get => _tiles.FirstOrDefault(x => x.X == i && x.Y == j);
        }
    }
}
