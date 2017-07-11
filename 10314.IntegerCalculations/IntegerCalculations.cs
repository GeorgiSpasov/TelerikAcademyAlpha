using System;
using System.Linq;
using System.Numerics;

namespace _10314.IntegerCalculations
{
    class IntegerCalculations
    {
        static void Main(string[] args)
        {
            int[] intArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int a = intArray[0];
            int b = intArray[1];
            int c = intArray[2];
            int d = intArray[3];
            int e = intArray[4];

            Console.WriteLine(CalcMin(a, b, c, d, e));
            Console.WriteLine(CalcMax(a, b, c, d, e));
            Console.WriteLine("{0:f2}", CalcAvg(a, b, c, d, e));
            Console.WriteLine(CalcSum(a, b, c, d, e));
            Console.WriteLine(CalcProd(a, b, c, d, e));

        }

        public static int CalcMin(params int[] args)
        {
            int min = int.MaxValue;
            for (int i = 0; i < args.Length; i++)
            {
                if (min > args[i])
                {
                    min = args[i];
                }
            }
            return min;
        }
        public static int CalcMax(params int[] args)
        {
            int max = int.MinValue;
            for (int i = 0; i < args.Length; i++)
            {
                if (max < args[i])
                {
                    max = args[i];
                }
            }
            return max;
        }
        public static double CalcAvg(params int[] args)
        {
            double avg = 0.0;
            double sum = 0.0;
            for (int i = 0; i < args.Length; i++)
            {
                sum += args[i];
            }
            avg = sum / args.Length;
            return avg;

        }
        public static int CalcSum(params int[] args)
        {
            int sum = 0;
            for (int i = 0; i < args.Length; i++)
            {
                sum += args[i];
            }
            return sum;
        }
        public static BigInteger CalcProd(params int[] args)
        {
            BigInteger product = 1;
            for (int i = 0; i < args.Length; i++)
            {
                product *= args[i];
            }
            return product;
        }
    }
}
