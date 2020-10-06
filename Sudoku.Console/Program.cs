using Newtonsoft.Json;
using Sudoku.Entities;
using Sudoku.Logic.Solver;
using System;
using System.Net.Sockets;

namespace Sudoku.Cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            int?[,] boardArray = new int?[,]
            {
                { 5, null, null, null, 2, null, null, null, null },
                { 8, 3, null, null, 4, 9, null, null, 7 },
                { 6, null, null, 5, null, 1, 9, 8, null },

                { null, 5, null, 4, null, 6, 8, 3, 2 },
                { null, null, 4, null, 5, 3, null, null, null },
                { null, null, 6, null, null, null, 7, null, 5 },

                { 4, null, 5, null, 6, null, 3, null, null },
                { 7, null, null, 1, null, null, null, 2, 9 },
                { 9, 2, 8, null, 7, 4, null, 6, null },
            };
            Board board = new Board(boardArray);
            Solver solver = new Solver(board);
            while(true)
            {
                var result = solver.FindNextNumber();
                Console.WriteLine(board.ToString());
                if (result == Enums.ESearchResult.SudokuSolved)
                    break;
                Console.ReadKey();
                Console.Clear();
            }
            Console.WriteLine("Sudoku solved!");
            Console.ReadKey();
        }
    }
}
