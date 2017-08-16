using System;
using System.Collections.Generic;
using System.Linq;

namespace _20201.ListInts
{
    class ListInts
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

            Console.WriteLine("Sum = " + ints.Sum());
            Console.WriteLine("Average = " + ints.Average());
        }
    }
}
