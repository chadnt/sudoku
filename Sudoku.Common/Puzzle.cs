using System;
using System.Collections.Generic;

namespace Sudoku.Common
{
    public class Puzzle
    {
        private const int ArrayLength = 81;
        private readonly int?[] array;

        public Puzzle(int?[] array)
        {
            if (array.Length != ArrayLength)
            {
                throw new ArgumentException($"array length must be {ArrayLength}", "array");
            }

            this.array = array;
            Initialize();
        }

        public IDictionary<string, int?[]> Columns { get; private set; }
        public IDictionary<string, int?[]> Groups { get; private set; }
        public IDictionary<string, int?[]> Rows { get; private set; }

        private void Initialize()
        {
            Rows = PuzzleHelper.GetRows(array);
            Columns = PuzzleHelper.GetColumns(array);
            Groups = PuzzleHelper.GetGroups(array);
        }
    }
}