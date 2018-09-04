using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku.Common
{
    public class Group : IEnumerable<Cell>
    {
        private IList<Cell> list = new List<Cell>();

        public bool IsValid => 
            list.GroupBy(c => c.Value)
            .All(g => g.Count() == 1);

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
