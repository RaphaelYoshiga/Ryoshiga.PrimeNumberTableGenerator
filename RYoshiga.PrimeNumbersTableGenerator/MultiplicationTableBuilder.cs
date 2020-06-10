using System.Collections.Generic;
using System.Linq;

namespace RYoshiga.PrimeNumbersTableGenerator
{
    public class MultiplicationTableBuilder
    {
        private readonly List<int> _numbers = new List<int>();

        public void Add(int i)
        {
            _numbers.Add(i);
        }

        public MultiplicationTable Build()
        {
            var firstRow = new List<int?> {null};
            foreach (var number in _numbers)
                firstRow.Add(number);

            var allRows = new List<List<int?>>() { firstRow };
            allRows.AddRange(_numbers.Select(GenerateRow).ToList());
            return new MultiplicationTable(allRows);
        }

        private List<int?> GenerateRow(int number)
        {
            var row = new List<int?> { number };
            foreach (var t in _numbers)
                row.Add(number * t);

            return row;
        }
    }
}