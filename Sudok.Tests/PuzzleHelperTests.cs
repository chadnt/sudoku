using System.Collections.Generic;
using Sudoku.Common;
using Xunit;

namespace Sudok.Tests
{
    public class PuzzleHelperTests
    {
        [Fact]
        public void GetColumns()
        {
            // arrange
            var array = new int?[]
            { null, null, null, null,    6, null, null,    3, null,
                 2, null,    7,    3,    8, null, null,    4, null,
                 6, null, null, null, null, null, null,    2, null,
                 3, null, null,    1,    4,    5,    2, null, null,
                 5,    6,    1,    2,    9, null, null,    7, null,
              null, null,    9, null,    7, null, null, null,    1,
                 8, null,    2,    5,    1, null,    6, null,    4,
              null,    4, null,    9,    3,    6,    8, null, null,
              null,    9, null, null, null,    4,    3, null,    7,
            };

            // act
            var columns = PuzzleHelper.GetColumns(array);
            var expected = new Dictionary<string, int?[]>
            {
                {"A", new int?[]{ null,    2,    6,    3,    5, null,    8, null, null, } },
                {"B", new int?[]{ null, null, null, null,    6, null, null,    4,    9, } },
                {"C", new int?[]{ null,    7, null, null,    1,    9,    2, null, null, } },
                {"D", new int?[]{ null,    3, null,    1,    2, null,    5,    9, null, } },
                {"E", new int?[]{    6,    8, null,    4,    9,    7,    1,    3, null, } },
                {"F", new int?[]{ null, null, null,    5, null, null, null,    6,    4, } },
                {"G", new int?[]{ null, null, null,    2, null, null,    6,    8,    3, } },
                {"H", new int?[]{    3,    4,    2, null,    7, null, null, null, null, } },
                {"I", new int?[]{ null, null, null, null, null,    1,    4, null,    7, } },
            };

            // assert
            Assert.Equal(expected, columns);
        }

        [Fact]
        public void GetRows()
        {
            // arrange
            var array = new int?[]
            { null, null, null, null,    6, null, null,    3, null,
                 2, null,    7,    3,    8, null, null,    4, null,
                 6, null, null, null, null, null, null,    2, null,
                 3, null, null,    1,    4,    5,    2, null, null,
                 5,    6,    1,    2,    9, null, null,    7, null,
              null, null,    9, null,    7, null, null, null,    1,
                 8, null,    2,    5,    1, null,    6, null,    4,
              null,    4, null,    9,    3,    6,    8, null, null,
              null,    9, null, null, null,    4,    3, null,    7,
            };

            // act
            var rows = PuzzleHelper.GetRows(array);
            var expected = new Dictionary<string, int?[]>
            {
                {"0",  new int?[] {null, null, null, null,    6, null, null,    3, null,} },
                {"1",  new int?[] {   2, null,    7,    3,    8, null, null,    4, null,} },
                {"2",  new int?[] {   6, null, null, null, null, null, null,    2, null,} },
                {"3",  new int?[] {   3, null, null,    1,    4,    5,    2, null, null,} },
                {"4",  new int?[] {   5,    6,    1,    2,    9, null, null,    7, null,} },
                {"5",  new int?[] {null, null,    9, null,    7, null, null, null,    1,} },
                {"6",  new int?[] {   8, null,    2,    5,    1, null,    6, null,    4,} },
                {"7",  new int?[] {null,    4, null,    9,    3,    6,    8, null, null,} },
                {"8",  new int?[] {null,    9, null, null, null,    4,    3, null,    7,} },
            };

            // assert
            Assert.Equal(expected, rows);
        }
    }
}