using System;
using System.Linq;

namespace _10311.AddingPolynomials
{
    class AddingPolynomials
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] firstLine = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] secondLine = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] result = AddPols(firstLine, secondLine, n);
            Console.WriteLine(string.Join(" ", result));
        }
        public static int[] AddPols(int[]first, int[] second, int n)
        {
            int[] result = new int[n];
            for (int i = 0; i < n; i++)
            {
                result[i] = first[i] + second[i];
            }
            return result;
        }
    }
}
