using System;

namespace _10105.MaximalIncreasingSequence
{
    class MaximalIncreasingSequence
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] intArray = new int[n];
            int currentSequence = 1;
            int maxSequence = 1;

            for (int i = 0; i < n; i++)
            {
                intArray[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 1; i < n; i++)
            {
                if (intArray[i - 1] < intArray[i])
                {
                    currentSequence++;
                    if (maxSequence < currentSequence)
                    {
                        maxSequence = currentSequence;
                    }
                }
                else
                {
                    currentSequence = 1;
                }
            }
            Console.WriteLine(maxSequence);
        }
    }
}
