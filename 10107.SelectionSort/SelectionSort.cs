using System;
using System.Collections.Generic;

namespace _10107.SelectionSort
{
    class SelectionSort
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> intList = new List<int>(n); ;
            int[] finalArray = new int[n];
            int min = int.MaxValue;

            for (int i = 0; i < n; i++)
            {
                intList.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - i; j++)
                {
                    if (min > intList[j])
                    {
                        min = intList[j];
                    }
                }
                intList.Remove(min);
                finalArray[i] = min;
                min = int.MaxValue;
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(finalArray[i]);
            }

        }
    }
}
