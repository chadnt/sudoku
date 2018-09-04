using System;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku.Common
{
    public class Puzzle
    {
        private const int ArrayLength = 81;

        public Puzzle(int?[] array)
        {
            if (array.Length != ArrayLength)
            {
                throw new ArgumentException($"array length must be {ArrayLength}", "array");
            }

            Array = array;
            Initialize();
        }

        public int?[] Array { get; private set; }
        public IList<Cell> Cells { get; set; }
        public IDictionary<string, Group> Columns { get; set; }
        public IDictionary<string, Cell> Grid { get; set; }
        public IDictionary<string, Group> Groups { get; set; }
        public bool IsValid { get; /* TODO: No duplicates in rows, columns, or groups.  At least one candidate value for each cell. */ }
        public IDictionary<string, Group> Rows { get; set; }

        private void Initialize()
        {
            PuzzleHelper.Initialize(this);
        }
    }
}