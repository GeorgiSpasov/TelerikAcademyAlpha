using System;
using System.Collections.Generic;
using System.Linq;

namespace _10308.NumberAsArray
{
    class NumberAsArray
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] arrayOne = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] arrayTwo = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            List<int> result = SumArrays(arrayOne, arrayTwo, sizes);
            Console.WriteLine(string.Join(" ", result));
        }

        public static List<int> SumArrays(int[] arrayOne, int[] arrayTwo, int[] sizes)
        {
            int[] shortArray;
            int[] longArray;
            if (sizes[0] > sizes[1])
            {
                shortArray = arrayTwo;
                longArray = arrayOne;
            }
            else
            {
                shortArray = arrayOne;
                longArray = arrayTwo;
            }

            List<int> sum = new List<int>(longArray);

            for (int i = 0; i < sizes.Min(); i++)
            {
                sum[i] += shortArray[i];

                int shifter = i;
                while (sum.Capacity - 1 > shifter && sum[shifter] > 9)
                {
                    sum[shifter] -= 10;
                    sum[shifter + 1] += 1;
                    shifter++;
                }

                if (sum[sum.Capacity - 1] > 9)
                {
                    sum[sum.Capacity - 1] -= 10;
                    sum.Add(1);
                }
            }
            return sum;
        }
    }
}
