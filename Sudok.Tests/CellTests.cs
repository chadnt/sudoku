using System.Collections.Generic;
using System.Linq;
using Sudoku.Common;
using Xunit;

namespace Sudoku.Tests
{
    public class CellTests
    {
        [Fact]
        public void PeerValuesA0()
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
            var expectedA0 = new List<int> { 2, 3, 5, 6, 7, 8 };
            var peerValuesA0 = puzzle.Grid["A0"].PeerValues.OrderBy(v => v);

            // assert
            Assert.Equal(expectedA0, peerValuesA0);
        }

        [Fact]
        public void PeerValuesI8()
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
            var expectedI8 = new List<int> { 1, 3, 4, 6, 7, 8, 9 };
            var peerValuesI8 = puzzle.Grid["I8"].PeerValues.OrderBy(v => v);

            // assert
            Assert.Equal(expectedI8, peerValuesI8);
        }

        [Fact]
        public void CandidatesA0()
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
            var expectedA0 = new List<int> { 1, 4, 9 };
            var peerValuesA0 = puzzle.Grid["A0"].Candidates.OrderBy(v => v);

            // assert
            Assert.Equal(expectedA0, peerValuesA0);
        }

        [Fact]
        public void CandidatesI8()
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
            var expectedI8 = new List<int> { 7 };
            var peerValuesI8 = puzzle.Grid["I8"].Candidates.OrderBy(v => v);

            // assert
            Assert.Equal(expectedI8, peerValuesI8);
        }

        [Fact]
        public void CandidatesF4()
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
            var expectedF4 = new List<int> { 3, 8 };
            var peerValuesF4 = puzzle.Grid["F4"].Candidates.OrderBy(v => v);

            // assert
            Assert.Equal(expectedF4, peerValuesF4);
        }
    }
}
