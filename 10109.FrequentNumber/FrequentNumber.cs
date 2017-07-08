using System;

namespace _10109.FrequentNumber
{
    class FrequentNumber
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] intArray = new int[n];
            int currentOccurence = 0;
            int maxOccurence = 0;
            int frequentNumber = 0;

            for (int i = 0; i < n; i++)
            {
                intArray[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (intArray[i] == intArray[j])
                    {
                        currentOccurence++;
                    }
                }
                if (currentOccurence > maxOccurence)
                {
                    maxOccurence = currentOccurence;
                    frequentNumber = intArray[i];
                }
                currentOccurence = 0;
            }
            Console.WriteLine("{0} ({1} times)", frequentNumber, maxOccurence);
        }
    }
}
