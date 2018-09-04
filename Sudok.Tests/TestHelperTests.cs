using Sudoku.Common;
using Xunit;

namespace Sudoku.Tests
{
    public class TestHelperTests
    {
        [Fact]
        public void GetTestPuzzleSize()
        {
            // arrange
            var expectedSize = 81;
            var helper = new TestHelper();

            // act
            int?[] puzzle = helper.GetTestArray();

            // assert
            Assert.Equal(expectedSize, puzzle.Length);
        }

        [Fact]
        public void GetTestPuzzleNullOrBewteen1and9()
        {
            // arrange
            int min = 1;
            int max = 9;
            var helper = new TestHelper();

            // act
            int?[] puzzle = helper.GetTestArray();

            // assert
            void areNullOrBewteen1and9(int? item) => Assert.True(item == null || (item >= min && item <= max));
            Assert.All(puzzle, areNullOrBewteen1and9);
        }
    }
}
