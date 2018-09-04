using System;
using Sudoku.Common;

namespace Sudoku.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var viewModel = new SudokuConsoleViewModel();
            var array = new TestHelper().GetTestArray();
            var puzzle = new Puzzle(array);

            viewModel.Display(puzzle, Console.Out);
            viewModel.DisplayCandidates(puzzle);

            Console.ReadKey();
        }
    }
}
