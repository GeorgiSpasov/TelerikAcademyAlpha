using System;

namespace _10106.MaximalKSum
{
    class MaximalKSum
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int[] intArray = new int[n];
            int maxSum = 0;
            for (int i = 0; i < n; i++)
            {
                intArray[i] = int.Parse(Console.ReadLine());
            }
            Array.Sort(intArray);
            for (int i = 0; i < k; i++)
            {
                maxSum += intArray[intArray.Length - 1 - i];
            }
            Console.WriteLine(maxSum);
        }
    }
}
