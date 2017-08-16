using System;
using System.Collections.Generic;
using System.Linq;

namespace _20203.SortList
{
    class SortList
    {
        static void Main(string[] args)
        {
            List<int> ints = new List<int>();
            int input;

            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out input))
                {
                    break;
                }
                ints.Add(input);
            }

            Console.WriteLine("Sorted: " + string.Join(" ", ints.OrderBy(c => c)));
        }
    }
}
