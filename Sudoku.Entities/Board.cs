using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku.Entities
{
    public class Board
    {
        [JsonIgnore]
        public static int SIZE = 9;
        [JsonIgnore]
        private static int SUM_IN_ROW = 45;
        public IEnumerable<Tile> Tiles { get; private set; }
        [JsonIgnore]
        public Tuple<int, int, int> LastInsertedTile { get; private set; }

        [JsonConstructor]
        public Board()
        {

        }

        public Board(int?[,] input)
        {
            var tiles = new List<Tile>();
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    if (input[i, j].HasValue)
                        tiles.Add(new Tile(i, j, input[i, j].Value));
                    else
                        tiles.Add(new Tile(i, j));
                }
            }
            Tiles = tiles;
        }

        public static Board GetEmptyBoard()
        {
            var board = new Board();
            var tiles = new List<Tile>();
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    tiles.Add(new Tile(i, j));
                }
            }
            board.Tiles = tiles;
            return board;
        }

        public static Board GetBoardFromJson(string jsonSerializedBoard)
        {
            return JsonConvert.DeserializeObject<Board>(jsonSerializedBoard);
        }

        public string SaveToJson()
        {
            return JsonConvert.SerializeObject(this);
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

        public void SetLastInsertedTile(Tile tile)
        {
            LastInsertedTile = new Tuple<int, int, int>(tile.X, tile.Y, tile.Value ?? 0);
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

        public bool IsCorrect()
        {
            if (!IsFull())
                return false;
            for (int index = 0; index < SIZE; index++)
            {
                if (GetTilesInColumn(index).Sum(x => x.Value) != SUM_IN_ROW)
                    return false;
                if (GetTilesInRow(index).Sum(x => x.Value) != SUM_IN_ROW)
                    return false;
            }
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
                    result = string.Concat(result, this[i, j].Value.HasValue ? this[i, j].Value.ToString() : " ", LastInsertedTile?.Item1 == i && LastInsertedTile?.Item2 == j ? "!" : " ");
                }
                result = string.Concat(result, "\n");
            }
            return result;
        }

        public static bool AreEqual(Board board1, Board board2)
        {
            for (int i = 0; i < board1.Tiles.Count(); i++)
            {
                if (board1.Tiles.ElementAt(i).Value != board2.Tiles.ElementAt(i).Value
                    || board1.Tiles.ElementAt(i).Possibilites.Count != board2.Tiles.ElementAt(i).Possibilites.Count)
                    return false;
            }
            return true;
        }
    }
}
