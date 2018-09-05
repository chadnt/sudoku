using System.Collections.Generic;
using System.Linq;
using Sudoku.Common;
using Xunit;

namespace Sudoku.Tests
{
    public class PuzzleTests
    {
        [Fact]
        public void PuzzleRows()
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
            var puzzle = new Puzzle(array);
            var values = puzzle.Rows.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Select(v => v.Value));
            var expected = new Dictionary<string, IEnumerable<int?>>
            {
                {"0",  new List<int?> {null, null, null, null,    6, null, null,    3, null,} },
                {"1",  new List<int?> {   2, null,    7,    3,    8, null, null,    4, null,} },
                {"2",  new List<int?> {   6, null, null, null, null, null, null,    2, null,} },
                {"3",  new List<int?> {   3, null, null,    1,    4,    5,    2, null, null,} },
                {"4",  new List<int?> {   5,    6,    1,    2,    9, null, null,    7, null,} },
                {"5",  new List<int?> {null, null,    9, null,    7, null, null, null,    1,} },
                {"6",  new List<int?> {   8, null,    2,    5,    1, null,    6, null,    4,} },
                {"7",  new List<int?> {null,    4, null,    9,    3,    6,    8, null, null,} },
                {"8",  new List<int?> {null,    9, null, null, null,    4,    3, null,    7,} },
            };

            // assert
            Assert.Equal(expected, values);
        }

        [Fact]
        public void PuzzleColumns()
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
            var puzzle = new Puzzle(array);
            var values = puzzle.Columns.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Select(v => v.Value));
            var expected = new Dictionary<string, IEnumerable<int?>>
            {
                {"A", new List<int?>{ null,    2,    6,    3,    5, null,    8, null, null, } },
                {"B", new List<int?>{ null, null, null, null,    6, null, null,    4,    9, } },
                {"C", new List<int?>{ null,    7, null, null,    1,    9,    2, null, null, } },
                {"D", new List<int?>{ null,    3, null,    1,    2, null,    5,    9, null, } },
                {"E", new List<int?>{    6,    8, null,    4,    9,    7,    1,    3, null, } },
                {"F", new List<int?>{ null, null, null,    5, null, null, null,    6,    4, } },
                {"G", new List<int?>{ null, null, null,    2, null, null,    6,    8,    3, } },
                {"H", new List<int?>{    3,    4,    2, null,    7, null, null, null, null, } },
                {"I", new List<int?>{ null, null, null, null, null,    1,    4, null,    7, } },
            };

            // assert
            Assert.Equal(expected, values);
        }

        [Fact]
        public void GridCellsIds()
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
            var puzzle = new Puzzle(array);
            var ids = puzzle.Grid.Select(c => c.Value.Id);
            var expected = Enumerable.Range(0, 81);

            // assert
            Assert.Equal(expected, ids);
        }

        [Fact]
        public void GridCellsNames()
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
            var puzzle = new Puzzle(array);
            var names = puzzle.Grid.Select(c => c.Value.Name);
            var expected = PuzzleHelper.CellNames;

            // assert
            Assert.Equal(expected, names);
        }

        [Fact]
        public void GridCellsValues()
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
            var puzzle = new Puzzle(array);
            var values = puzzle.Grid.Select(c => c.Value.Value);
            var expected = array;

            // assert
            Assert.Equal(expected, values);
        }

        [Fact]
        public void IsValidTrue()
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
            var puzzle = new Puzzle(array);

            // assert
            Assert.True(puzzle.IsValid);
        }
    }
}
