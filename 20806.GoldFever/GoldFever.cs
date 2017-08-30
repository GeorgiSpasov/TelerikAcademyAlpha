using System;
using System.Linq;

namespace _20806.GoldFever
{
    class GoldFever
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] prices = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            long sum = 0;

            int max = 0;
            for (int i = prices.Length - 1; i >= 0; i--)
            {
                if (prices[i] >= max)
                {
                    max = prices[i];
                }
                else
                {
                    sum += max;
                    sum -= prices[i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}
