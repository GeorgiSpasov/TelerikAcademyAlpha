using System;
using System.Numerics;

namespace _10310.NFactorial
{
    class NFactorial
    {
        static void Main(string[] args)
        {
            BigInteger n = BigInteger.Parse(Console.ReadLine());
            Console.WriteLine(Factorial(n));
        }

        public static BigInteger Factorial(BigInteger n)
        {
            if (n <= 1)
            {
                return 1;
            }
            return n * Factorial(n - 1);
        }
    }
}
