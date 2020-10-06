using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Sudoku.Entities
{
    public class Tile
    {
        public int X { get; }
        public int Y { get; }
        public int Square { get; }
        public int? Value { get; private set; }
        [JsonIgnore]
        public bool HasValue => Value.HasValue;
        public List<int> Possibilites { get; private set; }
        [JsonConstructor]
        Tile(int x, int y, int? value, List<int> possibilities)
        {
            Possibilites = possibilities;
            Value = value;
            X = x;
            Y = y;
            Square = x / 3 * 3 + y / 3;
        }
        public Tile(int x, int y, int value) : this(x, y, value, new List<int>())
        {
        }
        public Tile(int x, int y, List<int> possibilities) : this(x, y, null, possibilities)
        {
        }
        public Tile(int x, int y) : this(x, y, null, new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 })
        {

        }
        public void SetValue(int value)
        {
            Value = value;
            Possibilites.Clear();
        }
        public void ClearValue()
        {
            Value = null;
            Possibilites = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        }
        public bool SetValueIfOnlyOnePossible()
        {
            if (Possibilites.Count != 1)
                return false;
            SetValue(Possibilites.Single());
            return true;
        }
        public bool RemovePossibility(int value)
        {
            if (!Possibilites.Contains(value))
                return false;
            Possibilites.Remove(value);
            return true;
        }
    }
}
