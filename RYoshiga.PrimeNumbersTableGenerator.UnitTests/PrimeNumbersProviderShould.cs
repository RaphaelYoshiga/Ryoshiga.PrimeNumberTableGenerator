using Shouldly;
using Xunit;

namespace RYoshiga.PrimeNumbersTableGenerator.UnitTests
{
    public class PrimeNumbersProviderShould
    {
        private readonly PrimeNumbersProvider _primeNumbersProvider;

        public PrimeNumbersProviderShould()
        {
            _primeNumbersProvider = new PrimeNumbersProvider();
        }

        [Theory]
        [InlineData(0, 2)]
        [InlineData(1, 3)]
        [InlineData(2, 5)]
        [InlineData(3, 7)]
        [InlineData(9, 29)]
        [InlineData(10, 31)]
        public void ProvidePrimeNumberAt(int index, int expected)
        {
            var number = _primeNumbersProvider.GetPrimeAt(index);

            number.ShouldBe(expected);
        }
    }
}
