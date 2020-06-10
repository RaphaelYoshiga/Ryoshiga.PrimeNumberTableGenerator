using System.Collections.Generic;

namespace RYoshiga.PrimeNumbersTableGenerator
{
    public class PrimeNumbersProvider
    {
        private readonly List<int> _primes;

        public PrimeNumbersProvider()
        {
            _primes = SieveOfSundaram.GeneratePrimesSieveOfSundaram(1000);
        }
   
        public int GetPrimeAt(in int index)
        {
            return _primes[index];
        }
    }
}