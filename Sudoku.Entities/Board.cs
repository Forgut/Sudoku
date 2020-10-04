using System.Collections.Generic;
using System.Linq;

namespace Sudoku.Entities
{
    public class Board 
    {
        public static int SIZE = 9;
        public IEnumerable<Tile> Tiles { get; set; }
        public Board()
        {
            var tiles = new List<Tile>();
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    tiles.Add(new Tile(i, j));  
                }
            }
            Tiles = tiles;
        }

        public Board(Board oldBoard)
        {
            Tiles = oldBoard.Tiles;
        }

        public Tile this[int i, int j]
        {
            get => Tiles.FirstOrDefault(x => x.X == i && x.Y == j);
        }

        public void SetValueAtPosition(int value, int x, int y)
        {
            this[x, y].SetValue(value);
        }
        public void ClearPosition(int x, int y)
        {
            this[x, y].ClearValue();
        }

        public void AddPosibilityAtPosition(int possibility, int x, int y)
        {
            if (!this[x, y].Possibilites.Contains(possibility))
                this[x, y].Possibilites.Add(possibility);
        }

        public void RemovePossibilityAtPosition(int possibility, int x, int y)
        {
            if (this[x, y].Possibilites.Contains(possibility))
                this[x, y].Possibilites.Remove(possibility);
        }

        public bool IsFull()
        {
            foreach (var tile in Tiles)
                if (!tile.HasValue)
                    return false;
            return true;
        }

        public IEnumerable<Tile> GetTilesInColumn(int index)
        {
            return Tiles.Where(t => t.Y == index);
        }
        public IEnumerable<Tile> GetTilesInRow(int index)
        {
            return Tiles.Where(t => t.X == index);
        }
        public IEnumerable<Tile> GetTilesInSquare(int squareIndex)
        {
            return Tiles.Where(t => t.Square == squareIndex);
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < SIZE; i++)
            {
                if (i % 3 == 0 && i > 0)
                    result = string.Concat(result, "\n");
                for (int j = 0; j < SIZE; j++)
                {
                    if (j % 3 == 0 && j > 0)
                        result = string.Concat(result, " ");
                    //result = string.Concat(result, this[i, j].Value.HasValue ? this[i, j].Value.ToString() : "X", " ");
                    result = string.Concat(result, this[i, j].Square, " ");
                }
                result = string.Concat(result, "\n");
            }
            return result;
        }
    }
}
