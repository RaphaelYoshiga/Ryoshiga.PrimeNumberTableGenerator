using System;
using System.Collections;
using System.Collections.Generic;

namespace RYoshiga.PrimeNumbersTableGenerator
{
    internal class SieveOfSundaram
    {
        internal static List<int> GeneratePrimesSieveOfSundaram(int n)
        {
            var limit = ApproximateNthPrime(n);
            var bits = GeneratePrimesTo(limit);
            var primes = new List<int>();
            primes.Add(2);
            for (int i = 1, found = 1; 2 * i + 1 <= limit && found < n; i++)
            {
                if (bits[i])
                {
                    primes.Add(2 * i + 1);
                    found++;
                }
            }
            return primes;
        }

        private static int ApproximateNthPrime(int nn)
        {
            double n = nn;
            double p;
            if (nn >= 7022)
            {
                p = n * Math.Log(n) + n * (Math.Log(Math.Log(n)) - 0.9385);
            }
            else if (nn >= 6)
            {
                p = n * Math.Log(n) + n * Math.Log(Math.Log(n));
            }
            else if (nn > 0)
            {
                p = new int[] { 2, 3, 5, 7, 11 }[nn - 1];
            }
            else
            {
                p = 0;
            }
            return (int)p;
        }

        private static BitArray GeneratePrimesTo(int limit)
        {
            limit /= 2;
            var bits = new BitArray(limit + 1, true);
            for (int i = 1; 3 * i + 1 < limit; i++)
            {
                for (int j = 1; i + j + 2 * i * j <= limit; j++)
                {
                    bits[i + j + 2 * i * j] = false;
                }
            }
            return bits;
        }

    }
}