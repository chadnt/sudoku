using System;
using System.Collections.Generic;
using System.Text;
using Sudoku.Common;
using Xunit;

namespace Sudoku.Tests
{
    public class GroupTests
    {
        [Fact]
        public void IsValidTrue()
        {
            // arrange / act
            var group = new Group
            {
                new Cell { Value = 1 },
                new Cell { Value = 2 },
                new Cell { Value = null },
                new Cell { Value = 3 }
            };

            // asert
            Assert.True(group.IsValid);
        }

        [Fact]
        public void IsValidDuplicate()
        {
            // arrange / act
            var group = new Group
            {
                new Cell { Value = 1 },
                new Cell { Value = 1 }
            };

            // asert
            Assert.False(group.IsValid);
        }

        [Fact]
        public void IsValidOutOfRangeLow()
        {
            // arrange / act
            var group = new Group
            {
                new Cell { Value = 0 },
            };

            // asert
            Assert.False(group.IsValid);
        }

        [Fact]
        public void IsValidOutOfRangeHi()
        {
            // arrange / act
            var group = new Group
            {
                new Cell { Value = 10 },
            };

            // asert
            Assert.False(group.IsValid);
        }

        [Fact]
        public void IsValidNulls()
        {
            // arrange / act
            var group = new Group
            {
                new Cell { Value = 1 },
                new Cell { Value = 2 },
                new Cell { Value = null },
                new Cell { Value = null },
                new Cell { Value = null },
                new Cell { Value = null }
            };

            // asert
            Assert.True(group.IsValid);
        }
    }
}
