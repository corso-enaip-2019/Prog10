using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recap4
{
    class NumeriPrimi
    {
        UInterface _uInterface = null;

        public void Run(UInterface uInterface)
        {
            _uInterface = uInterface ?? throw new ArgumentNullException(nameof(uInterface));

            int max = _uInterface.GetPositiveInt("Quanti numeri primi vuoi? ");

            PrintPrimes(GetPrimeNumbers(max));
        }

        private void PrintPrimes(List<int> primes)
        {
            _uInterface.WriteMessage($"I primi {primes.Count} numeri primi sono:");
            int counter = 1;
            foreach (var prime in primes)
            {
                Console.ForegroundColor = counter % 2 == 0 ? ConsoleColor.Gray : ConsoleColor.White;
                _uInterface.WriteMessage($"{counter++}: {prime}");
            }
        }

        private List<int> GetPrimeNumbers(int max)
        {
            int primeCandidate = 0;
            List<int> primeCounter = new List<int>();
            while (primeCounter.Count < max)
            {
                if (IsPrime(primeCandidate))
                {
                    primeCounter.Add(primeCandidate);                    
                }
                primeCandidate++;
            }
            return primeCounter;
        }

        public bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }
    }
}
