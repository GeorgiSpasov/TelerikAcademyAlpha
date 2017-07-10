using System;
using System.Linq;

namespace _10304.AppearanceCount
{
    class AppearanceCount
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int x = int.Parse(Console.ReadLine());
            int count = Counter(x, numbers);
            Console.WriteLine(count);

        }

        public static int Counter(int num, int[] numbers)
        {
            int counter = 0;
            foreach (int item in numbers)
            {
                if (item == num)
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
