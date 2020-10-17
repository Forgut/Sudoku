using System.Collections.Generic;
using System.Linq;

namespace Sudoku.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Except<T>(this IEnumerable<T> collection, T element)
        {
            return collection.Except(new List<T>() { element });
        }
        public static IEnumerable<T> Except<T>(this IEnumerable<T> collection, params T[] elements)
        {
            return collection.Except(elements.ToList());
        }
    }
}
