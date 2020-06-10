using System;
using Shouldly;
using Xunit;

namespace RYoshiga.PrimeNumbersTableGenerator.UnitTests
{
    public class MultiplicationTableFormatterShould
    {
        private readonly MultiplicationTableFormatter _formatter;

        public MultiplicationTableFormatterShould()
        {
            _formatter = new MultiplicationTableFormatter();
        }

        [Fact]
        public void FormatTable()
        {
            var multiplicationTableBuilder = new MultiplicationTableBuilder();
            multiplicationTableBuilder.Add(2);
            multiplicationTableBuilder.Add(5);
            var multiplicationTable = multiplicationTableBuilder.Build();

            var formattedString = _formatter.Format(multiplicationTable);

            var expectedString = $"|    | 2  | 5  |{Environment.NewLine}" +
                                 $"| 2  | 4  | 10 |{Environment.NewLine}" +
                                 $"| 5  | 10 | 25 |{Environment.NewLine}";
            formattedString.ShouldBe(expectedString);
        }

        [Fact]
        public void FormatTableLargerColumns()
        {
            var multiplicationTableBuilder = new MultiplicationTableBuilder();
            multiplicationTableBuilder.Add(10);
            multiplicationTableBuilder.Add(100);
            var multiplicationTable = multiplicationTableBuilder.Build();

            var formattedString = _formatter.Format(multiplicationTable);

            var expectedString = $"|       | 10    | 100   |{Environment.NewLine}" +
                                 $"| 10    | 100   | 1000  |{Environment.NewLine}" +
                                 $"| 100   | 1000  | 10000 |{Environment.NewLine}";
            formattedString.ShouldBe(expectedString);
        }
    }
}
