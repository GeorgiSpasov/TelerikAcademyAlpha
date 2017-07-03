using System;

namespace _10202.MaximalSum
{
    class MaximalSum
    {
        static void Main(string[] args)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int n = input[0];
            int m = input[1];
            int[,] matrix = new int[input[0], input[1]];
            int currentSum = 0;
            int maxSum = int.MinValue;

            for (int row = 0; row < n; row++)
            {
                int[] inputRow = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = inputRow[col];
                }
            }

            for (int row = 0; row < n - 2; row++)
            {
                for (int col = 0; col < m - 2; col++)
                {
                    currentSum = Sum3x3(row, col, matrix);
                    maxSum = maxSum < currentSum ? currentSum : maxSum;
                }
            }
            Console.WriteLine(maxSum);
        }

        public static int Sum3x3(int row, int col, int[,] matrix)
        {
            int sum = 0;
            for (int i = row; i < row + 3; i++)
            {
                for (int j = col; j < col + 3; j++)
                {
                    sum += matrix[i, j];
                }
            }
            return sum;
        }
    }
}
