using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku.Common
{
    public class Group : IEnumerable<Cell>
    {
        private IList<Cell> list = new List<Cell>();

        public bool IsValid
        {
            get
            {
                // Valid if non-null values are unique
                var unique = list
                    .Where(c => c.Value != null)
                    .GroupBy(c => c.Value)
                    .All(g => g.Count() == 1);

                // and between 1 and 9
                var inRange = list.Where(c => c.Value != null)
                    .All(c => c.Value >= 1 && c.Value <= 9);

                return unique && inRange;
            }
        }

        public void Add(Cell item)
        {
            list.Add(item);
        }

        public int Count()
        {
            return list.Count;
        }

        public IEnumerator<Cell> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }
    }
}
