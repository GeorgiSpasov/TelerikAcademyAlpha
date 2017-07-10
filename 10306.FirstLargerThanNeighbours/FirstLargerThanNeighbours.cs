using System;
using System.Linq;

namespace _10306.FirstLargerThanNeighbours
{
    class FirstLargerThanNeighbours
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int index = FindeFirst(numbers);
            Console.WriteLine(index);
        }

        public static int FindeFirst(int[] numbers)
        {
            int index = -1;
            for (int i = 1; i < numbers.Length - 1; i++)
            {
                if (numbers[i - 1] < numbers[i] && numbers[i] > numbers[i + 1])
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
    }
}
