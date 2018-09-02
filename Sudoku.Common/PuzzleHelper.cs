using System;
using System.Collections.Generic;

namespace Sudoku.Common
{
    public class PuzzleHelper
    {
        private const int ColumnSize = Size;
        private const int GroupSize = Size;
        private const int RowSize = Size;
        private const int Size = 9;
        private static string[] columnNames = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I" };

        public static IDictionary<string, int?[]> GetColumns(int?[] array)
        {
            var columns = InitializeColumns();
            for (int i = 0; i < array.Length; i++)
            {
                var rowIndex = i / RowSize;
                var columnIndex = i % RowSize;
                string key = columnNames[columnIndex];
                var column = columns[key];
                column[rowIndex] = array[i];
            }

            return columns;
        }

        public static IDictionary<string, int?[]> GetGroups(int?[] array)
        {
            throw new NotImplementedException();
        }

        public static IDictionary<string, int?[]> GetRows(int?[] array)
        {
            var rows = new Dictionary<string, int?[]>();
            for (int i = 0; i < RowSize; i++)
            {
                string key = i.ToString();
                int?[] row = GetRow(array, i);
                rows.Add(key, row);
            }

            return rows;
        }

        private static int?[] GetRow(int?[] array, int i)
        {
            var row = new int?[ColumnSize];
            for (int c = 0; c < ColumnSize; c++)
            {
                var index = i * ColumnSize + c;
                if (index < array.Length)
                {
                    row[c] = array[i * ColumnSize + c];
                }
                else
                {
                    throw new IndexOutOfRangeException($"array.Length:{array.Length}, index:{index}, i:{i}, c:{c}");
                }
            }

            return row;
        }

        private static IDictionary<string, int?[]> InitializeColumns() => new Dictionary<string, int?[]>
            {
                {columnNames[0], new int?[RowSize] },
                {columnNames[1], new int?[RowSize] },
                {columnNames[2], new int?[RowSize] },
                {columnNames[3], new int?[RowSize] },
                {columnNames[4], new int?[RowSize] },
                {columnNames[5], new int?[RowSize] },
                {columnNames[6], new int?[RowSize] },
                {columnNames[7], new int?[RowSize] },
                {columnNames[8], new int?[RowSize] },
            };
    }
}