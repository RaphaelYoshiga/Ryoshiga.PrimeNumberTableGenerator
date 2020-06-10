using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace RYoshiga.PrimeNumbersTableGenerator
{
    public class PrimeNumbersProvider
    {
        private List<int> _primes;

        public PrimeNumbersProvider()
        {
            NaivePrimeGeneration();
        }

        private void NaivePrimeGeneration()
        {
            _primes = new List<int>(new[] {2, 3});
            for (int n = 5; _primes.Count < 1000; n += 2)
            {
                if (IsPrime(n))
                    _primes.Add(n);
            }
        }

        private bool IsPrime(int n)
        {
            foreach (var prime in _primes)
            {
                if (n % prime == 0)
                    return false;
            }

            return true;
        }

        public int GetPrimeAt(in int index)
        {
            return _primes[index];
        }
    }
}