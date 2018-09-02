namespace Sudoku.Common
{
    public class Solver
    {
        public Solver(int?[] puzzle)
        {
            Puzzle = puzzle;
        }

        public int?[] Puzzle { get; private set; }
    }
}