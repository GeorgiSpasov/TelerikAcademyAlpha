using System;
using System.Linq;

namespace _10305.LargerThanNeighbours
{
    class LargerThanNeighbours
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int count = Counter(numbers);
            Console.WriteLine(count);
        }

        public static int Counter(int[] numbers)
        {
            int counter = 0;
            for (int i = 1; i < numbers.Length - 1; i++)
            {
                if (numbers[i - 1] < numbers[i] && numbers[i] > numbers[i + 1])
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
