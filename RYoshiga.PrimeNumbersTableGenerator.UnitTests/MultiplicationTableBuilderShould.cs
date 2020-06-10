using System.Linq;
using Shouldly;
using Xunit;

namespace RYoshiga.PrimeNumbersTableGenerator.UnitTests
{
    public class MultiplicationTableBuilderShould
    {
        private readonly MultiplicationTableBuilder _builder;

        public MultiplicationTableBuilderShould()
        {
            _builder = new MultiplicationTableBuilder();
        }

        [Fact]
        public void GenerateMultiplicationTable3x3()
        {
            _builder.Add(2);
            _builder.Add(3);

            var multiplicationTable = _builder.Build();

            var expected = new[]
            {
                new int?[] { null, 2, 3},
                new int?[] { 2, 4, 6},
                new int?[] { 3, 6, 9}
            };
            AssertAgainstExpectedMatrix(expected, multiplicationTable);
        }

        [Fact]
        public void GenerateMultiplicationTable4x4()
        {
            _builder.Add(2);
            _builder.Add(3);
            _builder.Add(5);

            var multiplicationTable = _builder.Build();

            var expected = new[]
            {
                new int?[] { null, 2, 3, 5},
                new int?[] { 2, 4, 6, 10},
                new int?[] { 3, 6, 9, 15},
                new int?[] { 5, 10, 15, 25}
            };
            AssertAgainstExpectedMatrix(expected, multiplicationTable);
        }

        private static void AssertAgainstExpectedMatrix(int?[][] expected, MultiplicationTable multiplicationTable)
        {
            var enumeratedTable = multiplicationTable.ToArray();
            for (int i = 0; i < expected.Length; i++)
            {
                enumeratedTable[i].Count.ShouldBe(expected[i].Length);
                for (int y = 0; y < expected[i].Length; y++)
                {
                    enumeratedTable[i][y].ShouldBe(expected[i][y]);
                }
            }
        }
    }
}

