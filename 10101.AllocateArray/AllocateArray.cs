using System;

namespace _10101.AllocateArray
{
    class AllocateArray
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] intArray = new int[n];
            for (int i = 0; i < n; i++)
            {
                intArray[i] = i * 5;
                Console.WriteLine(intArray[i]);
            }
        }
    }
}
