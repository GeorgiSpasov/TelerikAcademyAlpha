using System;
using System.Linq;

namespace _10203.SequenceInMatrix
{
    class SequenceInMatrix
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);
            string[,] matrix = new string[n, m];
            int maxSequence = 1;

            for (int row = 0; row < n; row++)
            {
                string[] inputRow = Console.ReadLine().Split();
                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = inputRow[col];
                }
            }

            maxSequence = new int[] { RowMaxSequance(matrix),
                                      ColMaxSequance(matrix),
                                      RightDiagonalMaxSequance(matrix),
                                      LeftDiagonalMaxSequance(matrix) }
                                      .Max();
            Console.WriteLine(maxSequence);
        }

        public static int RowMaxSequance<T>(T[,] matrix)
        {
            int currentSequence = 1;
            int maxSequence = 1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row, col].Equals(matrix[row, col + 1]))
                    {
                        currentSequence++;
                        maxSequence = maxSequence < currentSequence ? currentSequence : maxSequence;
                    }
                    else
                    {
                        currentSequence = 1;
                    }
                }
            }
            return maxSequence;
        }

        public static int ColMaxSequance<T>(T[,] matrix)
        {
            int currentSequence = 1;
            int maxSequence = 1;
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                for (int row = 1; row < matrix.GetLength(0) - 1; row++)
                {
                    if (matrix[row, col].Equals(matrix[row + 1, col]))
                    {
                        currentSequence++;
                        maxSequence = maxSequence < currentSequence ? currentSequence : maxSequence;
                    }
                    else
                    {
                        currentSequence = 1;
                    }
                }
            }
            return maxSequence;
        }

        public static int RightDiagonalMaxSequance<T>(T[,] matrix)
        {
            int currentSequence = 1;
            int maxSequence = 1;
            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            int i = 0;
            while (i < rowLength + colLength)
            {
                int row = (rowLength - 2) - (i < rowLength - 1 ? i : rowLength - 2);
                int col = 0 + (i < colLength - 1 ? 0 : i % colLength + 1);

                while (row < rowLength - 1 && col < colLength - 1)
                {
                    if (matrix[row, col].Equals(matrix[row + 1, col + 1]))
                    {
                        currentSequence++;
                        maxSequence = maxSequence < currentSequence ? currentSequence : maxSequence;
                    }
                    else
                    {
                        currentSequence = 1;
                    }
                    row++;
                    col++;
                }
                i++;
            }
            return maxSequence;
        }

        public static int LeftDiagonalMaxSequance<T>(T[,] matrix)
        {
            int currentSequence = 1;
            int maxSequence = 1;
            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            int i = 0;
            while (i < rowLength + colLength)
            {
                int row = (rowLength - 2) - (i < rowLength - 1 ? i : rowLength - 2);
                int col = (colLength - 1) - (i < colLength - 1 ? 0 : i % colLength + 1);

                while (row < rowLength - 1 && col > 0)
                {
                    if (matrix[row, col].Equals(matrix[row + 1, col - 1]))
                    {
                        currentSequence++;
                        maxSequence = maxSequence < currentSequence ? currentSequence : maxSequence;
                    }
                    else
                    {
                        currentSequence = 1;
                    }
                    row++;
                    col--;
                }
                i++;
            }
            return maxSequence;
        }
    }
}
