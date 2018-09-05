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
        public bool IsValid
        {
            get
            {
                // Rows, columns, and groups valid
                var columnsValid = Columns.All(g => g.Value.IsValid);
                var groupsValid = Groups.All(g => g.Value.IsValid);
                var rowsValid = Rows.All(g => g.Value.IsValid);
                // and at least one candidate value for each cell.
                var cellValid = Cells.All(c => c.Candidates.Count() > 0);

                return columnsValid && groupsValid && rowsValid && cellValid;
            }
        }
        public IDictionary<string, Group> Rows { get; set; }

        private void Initialize()
        {
            PuzzleHelper.Initialize(this);
        }
    }
}