using System;

namespace _10108.MaximalSum
{
    class MaximalSum
    {
        static void Main(string[] args)
        {
            // Kadane's algorithm
            // https://en.wikipedia.org/wiki/Maximum_subarray_problem

            int n = int.Parse(Console.ReadLine());
            int[] intArray = new int[n];
            int maxSoFar = 0;
            int maxEndingHere = 0;

            for (int i = 0; i < n; i++)
            {
                intArray[i] = int.Parse(Console.ReadLine());
            }
            
            foreach (int num in intArray)
            {
                int x = num;
                maxEndingHere = Math.Max(x, maxEndingHere + x);
                maxSoFar = Math.Max(maxSoFar, maxEndingHere);
            }
            Console.WriteLine(maxSoFar);
        }
    }
}
