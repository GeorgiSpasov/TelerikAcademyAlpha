using System;

namespace _10203.SequenceInMatrix
{
    class SequenceInMatrix
    {
        static void Main(string[] args)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int n = input[0];
            int m = input[1];
            int[,] matrix = new int[input[0], input[1]];
            int maxSequence = 1;

            for (int row = 0; row < n; row++)
            {
                int[] inputRow = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = inputRow[col];
                }
            }

            maxSequence = maxSequence < RowMaxSequance(matrix) ? RowMaxSequance(matrix) : maxSequence;
            maxSequence = maxSequence < ColMaxSequance(matrix) ? ColMaxSequance(matrix) : maxSequence;
            maxSequence = maxSequence < RightDiagonalMaxSequance(matrix) ? RightDiagonalMaxSequance(matrix) : maxSequence;
            maxSequence = maxSequence < LeftDiagonalMaxSequance(matrix) ? LeftDiagonalMaxSequance(matrix) : maxSequence;

            Console.WriteLine(maxSequence);

        }

        public static int RowMaxSequance(int[,] matrix)
        {
            int currentSequence = 1;
            int maxSequence = 1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1])
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

        public static int ColMaxSequance(int[,] matrix)
        {
            int currentSequence = 1;
            int maxSequence = 1;
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                for (int row = 1; row < matrix.GetLength(0) - 1; row++)
                {
                    if (matrix[row, col] == matrix[row + 1, col])
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

        public static int RightDiagonalMaxSequance(int[,] matrix)
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
                    if (matrix[row, col] == matrix[row + 1, col + 1])
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

        public static int LeftDiagonalMaxSequance(int[,] matrix)
        {
            int currentSequence = 1;
            int maxSequence = 1;
            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            int i = 0;
            while (i < rowLength + colLength)
            {
                int row = 0 + (i < rowLength - 1 ? 0 : i % rowLength + 1);
                int col = (colLength - 2) - (i < colLength - 1 ? i : colLength - 2);
                while (row < rowLength - 1 && col < colLength - 1)
                {
                    if (matrix[row, col] == matrix[row + 1, col + 1])
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

        public static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
