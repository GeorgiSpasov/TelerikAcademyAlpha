using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20806.GoldFever
{
    class GoldFever
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] prices = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            long sum = 0;

            int boughtOunzes = 0;
            int money = 0;


            for (int i = prices.Length - 1; i > 1; i--)
            {

            }

            Console.WriteLine(sum);
        }
    }
}
