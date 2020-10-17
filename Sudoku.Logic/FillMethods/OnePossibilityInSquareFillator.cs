using Sudoku.Entities;
using Sudoku.Logic.EliminationMetods;
using System.Linq;

namespace Sudoku.Logic.FillMethods
{
    public class OnePossibilityInSquareFillator : BaseFillator
    {
        public OnePossibilityInSquareFillator(Board board) : base(board)
        {

        }

        public override void Fill()
        {
            var squares = _board.Tiles
                .Where(x => !x.HasValue)
                .GroupBy(x => x.Square);
            foreach (var square in squares)
            {
                foreach (var possibility in Tile.AllPossibilities)
                {
                    var fieldsWithOnlyOnePossibilityInSquare = square.Where(x => x.Possibilites.Any(y => y == possibility));
                    if (fieldsWithOnlyOnePossibilityInSquare.Count() == 1)
                    {
                        fieldsWithOnlyOnePossibilityInSquare.First().SetValue(possibility);
                        ValueWasFilled = true;
                    }
                }
            }
        }
    }
}
