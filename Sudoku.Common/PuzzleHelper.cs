using System;
using System.Linq;
using System.Collections.Generic;

namespace Sudoku.Common
{
    public class PuzzleHelper
    {
        private const int Size = 9;

        public static int ColumnSize => Size;
        public static int GroupSize => Size;
        public static int RowSize => Size;

        public static string[] ColumnNames { get; } = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I" };
        public static string[] RowNames { get; } = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8" };
        public static string[] CellNames { get; } = new string[]
        {
            "A0", "B0", "C0", "D0", "E0", "F0", "G0", "H0", "I0",
            "A1", "B1", "C1", "D1", "E1", "F1", "G1", "H1", "I1",
            "A2", "B2", "C2", "D2", "E2", "F2", "G2", "H2", "I2",
            "A3", "B3", "C3", "D3", "E3", "F3", "G3", "H3", "I3",
            "A4", "B4", "C4", "D4", "E4", "F4", "G4", "H4", "I4",
            "A5", "B5", "C5", "D5", "E5", "F5", "G5", "H5", "I5",
            "A6", "B6", "C6", "D6", "E6", "F6", "G6", "H6", "I6",
            "A7", "B7", "C7", "D7", "E7", "F7", "G7", "H7", "I7",
            "A8", "B8", "C8", "D8", "E8", "F8", "G8", "H8", "I8",
        };
        public static string[] GroupNames { get; } = new string[]
        {
            "Group1", "Group2", "Group3",
            "Group4", "Group5", "Group6",
            "Group7", "Group8", "Group9",
        };
        public static IDictionary<string, string[]> GroupCellNames { get; } = new Dictionary<string, string[]>
        {
            {GroupNames[0], new string[] { "A0", "A1", "A2", "B0", "B1", "B2", "C0", "C1", "C2" } },
            {GroupNames[1], new string[] { "D0", "D1", "D2", "E0", "E1", "E2", "F0", "F1", "F2" } },
            {GroupNames[2], new string[] { "G0", "G1", "G2", "H0", "H1", "H2", "I0", "I1", "I2" } },
            {GroupNames[3], new string[] { "A3", "A4", "A5", "B3", "B4", "B5", "C3", "C4", "C5" } },
            {GroupNames[4], new string[] { "D3", "D4", "D5", "E3", "E4", "E5", "F3", "F4", "F5" } },
            {GroupNames[5], new string[] { "G3", "G4", "G5", "H3", "H4", "H5", "I3", "I4", "I5" } },
            {GroupNames[6], new string[] { "A6", "A7", "A8", "B6", "B7", "B8", "C6", "C7", "C8" } },
            {GroupNames[7], new string[] { "D6", "D7", "D8", "E6", "E7", "E8", "F6", "F7", "F8" } },
            {GroupNames[8], new string[] { "G6", "G7", "G8", "H6", "H7", "H8", "I6", "I7", "I8" } },
        };

        internal static void Initialize(Puzzle puzzle)
        {
            puzzle.Cells = new List<Cell>();
            puzzle.Rows = new Dictionary<string, Group>();
            puzzle.Columns = new Dictionary<string, Group>();
            puzzle.Groups = new Dictionary<string, Group>();
            puzzle.Grid = new Dictionary<string, Cell>();


            for (var i = 0; i < puzzle.Array.Length; i++)
            {
                int rowIndex = i / Size;
                int columnIndex = i % Size;
                string rowName = RowNames[rowIndex];
                string columnName = ColumnNames[columnIndex];
                var cellName = CellNames[i];
                string groupName = GetGroupName(cellName);
                CheckKeys(puzzle, rowName, columnName, groupName);
                var row = puzzle.Rows[rowName];
                var column = puzzle.Columns[columnName];
                var group = puzzle.Groups[groupName];
                var cell = new Cell
                {
                    Id = i,
                    Name = cellName,
                    RowIndex = rowIndex,
                    RowName = rowName,
                    Row = row,
                    ColumnIndex = columnIndex,
                    ColumnName = columnName,
                    Column = column,
                    GroupName = groupName,
                    Group = group,
                    Value = puzzle.Array[i],
                };

                row.Add(cell);
                column.Add(cell);
                group.Add(cell);
                puzzle.Cells.Add(cell);
                puzzle.Grid.Add(cell.Name, cell);
            }
        }

        private static void CheckKeys(Puzzle puzzle, string rowName, string columnName, string groupName)
        {
            if (!puzzle.Rows.ContainsKey(rowName))
            {
                puzzle.Rows.Add(rowName, new Group());
            }

            if (!puzzle.Columns.ContainsKey(columnName))
            {
                puzzle.Columns.Add(columnName, new Group());
            }

            if (!puzzle.Groups.ContainsKey(groupName))
            {
                puzzle.Groups.Add(groupName, new Group());
            }
        }

        private static string GetGroupName(string cellName)
        {
            return GroupCellNames
                .Where(g => g.Value.Contains(cellName))
                .Select(g => g.Key)
                .Single();
        }

        private static int?[] GetGroupForCell(IDictionary<string, int?[]> groups, string cellName)
        {
            var groupName = GroupCellNames
                .Where(g => g.Value.Contains(cellName))
                .Select(g => g.Key)
                .Single();

            return groups[groupName];
        }
    }
}