using System;
using System.Linq;

namespace _10309.SortingArray
{
    class SortingArray
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] intArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            SortArray(intArray);
            Console.WriteLine(string.Join(" ", intArray));
        }

        public static int FindMax(int[] intArray, int startIndex, out int switchIndex)
        {
            int max = int.MinValue;
            switchIndex = startIndex;
            for (int i = startIndex; i >= 0; i--)
            {
                if (max < intArray[i])
                {
                    max = intArray[i];
                    switchIndex = i;
                }
            }
            return max;
        }

        public static void SortArray(int[] intArray)
        {
            int switchdNum;
            int max;
            for (int i = intArray.Length - 1; i >= 0; i--)
            {
                int switchIndex;
                switchdNum = intArray[i];
                max = FindMax(intArray, i, out switchIndex);
                intArray[switchIndex] = switchdNum;
                intArray[i] = max;
            }
        }
    }
}
