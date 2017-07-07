using System;

namespace _10102.CompareArrays
{
    class CompareArrays
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arrayA = new int[n];
            int[] arrayB = new int[n];
            string areEqual = "Equal";
            for (int i = 0; i < n; i++)
            {
                arrayA[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < n; i++)
            {
                arrayB[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < n; i++)
            {
                if (arrayA[i]!=arrayB[i])
                {
                    areEqual = "Not equal";
                    break;
                }
            }

            Console.WriteLine(areEqual);
        }
    }
}
