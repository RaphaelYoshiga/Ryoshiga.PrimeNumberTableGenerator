using System;

namespace RYoshiga.PrimeNumbersTableGenerator
{
    class Program
    {
        private static readonly MultiplicationTableFormatter _tableFormatter;
        private static readonly PrimeNumbersProvider _providerGenerator;
        private static readonly MultiplicationTableBuilder _multiplicationTableBuilder;

        static Program()
        {
            _tableFormatter = new MultiplicationTableFormatter();
            _providerGenerator = new PrimeNumbersProvider();
            _multiplicationTableBuilder = new MultiplicationTableBuilder();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Choose N numbers to generate a multiplication table of prime numbers");
            string input = Console.ReadLine();

            int.TryParse(input, out int n);

            var primeMultiplicationTable = GeneratePrimesTableFor(n);
            var formattedTable = _tableFormatter.Format(primeMultiplicationTable);

            Console.WriteLine("Enjoy your prime multiplication table:");
            Console.Write(formattedTable);
            Console.ReadLine();
        }

        private static MultiplicationTable GeneratePrimesTableFor(int n)
        {
            for (int i = 0; i < n; i++)
            {
                var prime = _providerGenerator.GetPrimeAt(i);
                _multiplicationTableBuilder.Add(prime);
            }

            return _multiplicationTableBuilder.Build();
        }
    }
}
