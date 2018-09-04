using System.Collections.Generic;
using System.Linq;

namespace Sudoku.Common
{
    public class Cell
    {
        public Group Column { get; set; }
        public int ColumnIndex { get; set; }
        public string ColumnName { get; set; }
        public Group Group { get; set; }
        public string GroupName { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public Group Row { get; set; }
        public int RowIndex { get; set; }
        public string RowName { get; set; }
        public int? Value { get; set; }

        public IEnumerable<int> PeerValues
        {
            get
            {
                var rowValues = Row.Where(r => r.Value != null).Select(r => r.Value.Value);
                var columnVaues = Column.Where(r => r.Value != null).Select(r => r.Value.Value);
                var groupValues = Group.Where(r => r.Value != null).Select(r => r.Value.Value);

                return rowValues.Union(columnVaues).Union(groupValues);
            }
        }

        public IEnumerable<int> Candidates
        {
            get
            {
                if (Value != null)
                {
                    return new List<int> { Value.Value };
                }
                else
                {
                    var validValues = Enumerable.Range(1, 9);
                    return validValues.Except(PeerValues);
                }
            }
        }
    }
}