namespace Sudoku.Common
{
    public class TestHelper
    {
        public int?[] GetTestArray() => new int?[]
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
    }
}