using System;
using System.Linq;

namespace _10302.GetLargestNumber
{
    class GetLargestNumber
    {
        static void Main(string[] args)
        {
            int max = int.MinValue;
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            foreach (int num in numbers)
            {
                max = GetMax(num, max);
            }
            Console.WriteLine(max);
        }
        public static int GetMax(int current, int max)
        {
            int result;
            result = Math.Max(current, max);
            return result;
        }
    }
}
