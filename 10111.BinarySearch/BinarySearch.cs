using System;

namespace _10111.BinarySearch
{
    class BinarySearch
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] intArray = new int[n];
            for (int i = 0; i < n; i++)
            {
                intArray[i] = int.Parse(Console.ReadLine());
            }
            int x = int.Parse(Console.ReadLine());
            int index = n / 2;

            for (int i = 0; i < n; i++)
            {
                if (x == intArray[index])
                {
                    break;
                }
                else if (x < intArray[index])
                {
                    index--;
                }
                else if (x > intArray[index])
                {
                    index++;
                }
                if (i + 1 == n)
                {
                    index = -1;
                }
            }
            Console.WriteLine(index);
        }
    }
}
