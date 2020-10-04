using Sudoku.Entities;
using System;

namespace Sudoku.Cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            Console.WriteLine(board.ToString());
        }
    }
}
