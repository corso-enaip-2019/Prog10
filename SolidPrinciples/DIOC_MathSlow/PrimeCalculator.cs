using DIOC_Contracts;
using System;

namespace DIOC_MathSlow
{
    public class PrimeCalculator : IMath
    {
        public bool IsPrime(int number)
        {
            if (number < 2)
                return false;

            for (int i = 2; i < number; i++)
                if (number % i == 0)
                    return false;

            return true;
        }
    }
}
