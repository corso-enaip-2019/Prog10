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

            int max = _uInterface.GetNumber("Quanti numeri primi vuoi? ");
            int primeCandidate = 0;
            int primeCounter = 0;
            while(primeCounter < max)
            {
                if (IsPrime(primeCandidate))
                {
                    _uInterface.WriteMessage($"{++primeCounter}: {primeCandidate}");
                }
                primeCandidate++;
            }
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
