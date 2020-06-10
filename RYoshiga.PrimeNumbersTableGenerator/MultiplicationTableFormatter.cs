using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RYoshiga.PrimeNumbersTableGenerator
{
    public class MultiplicationTableFormatter
    {
        public string Format(MultiplicationTable multiplicationTable)
        {
            var sb = new StringBuilder();
            var enumeratedTable = multiplicationTable.ToArray();

            var maxNumberSize = MaxNumberSize(enumeratedTable);
            foreach (var row in enumeratedTable)
            {
                var line = GenerateLine(row, maxNumberSize);
                sb.AppendLine(line);
            }

            return sb.ToString();
        }

        private static int MaxNumberSize(List<int?>[] enumeratedTable)
        {
            var lastNumber = enumeratedTable[^1].Last();
            return lastNumber.ToString().Length;
        }

        private string GenerateLine(List<int?> row, int maxNumberSize)
        {
            var lineBuilder = new StringBuilder("|");
            foreach (var n in row)
                lineBuilder.AppendFormat(" {0} |", n.ToString().PadRight(maxNumberSize));

            return lineBuilder.ToString();
        }
    }
}