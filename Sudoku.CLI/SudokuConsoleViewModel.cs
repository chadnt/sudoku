using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Sudoku.Common;

namespace Sudoku.CLI
{
    public class SudokuConsoleViewModel
    {
        public SudokuConsoleViewModel()
        {
        }

        internal void Display(Puzzle puzzle, TextWriter stream)
        {
            foreach(var row in puzzle.Rows)
            {
                DisplayValuesForRow(row.Value, stream);
            }
        }

        private void DisplayValuesForRow(IEnumerable<Cell> row, TextWriter stream)
        {
            foreach (var cell in row)
            {
                string value = cell.Value.ToString();
                if (string.IsNullOrWhiteSpace(value))
                {
                    value = "_";
                }
                stream.Write($" {cell.Name}:{value} ");
            }

            stream.WriteLine();
        }

        internal void DisplayCandidates(Puzzle puzzle)
        {
            var max = puzzle.Cells.Select(c => c.Candidates.Count()).Max();
            foreach (var row in puzzle.Rows)
            {
                DisplayCandidatesForRow(row.Value, max);
            }
        }

        private void DisplayCandidatesForRow(IEnumerable<Cell> row, int max)
        {
            var cellWidth = max + 4;
            foreach (var cell in row)
            {
                string valueText = $"{cell.Name}:{cell.Value}";
                var color = Console.ForegroundColor;
                Console.Write(valueText);
                var candidates = cell.Value == null ? string.Join(null, cell.Candidates) : string.Empty;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(candidates);
                Console.ForegroundColor = color;
                var padLength = cellWidth - (valueText.Length + candidates.Length);
                var padding = new string(' ', padLength);
                Console.Write(padding);
            }

            Console.WriteLine();
        }
    }
}