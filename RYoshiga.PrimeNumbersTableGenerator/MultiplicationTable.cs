using System.Collections;
using System.Collections.Generic;

namespace RYoshiga.PrimeNumbersTableGenerator
{
    public class MultiplicationTable : IEnumerable<List<int?>>
    {
        private readonly List<List<int?>> _list;

        public MultiplicationTable(List<List<int?>> list)
        {
            _list = list;
        }

        public IEnumerator<List<int?>> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}