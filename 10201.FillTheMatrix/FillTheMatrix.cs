using System;
using System.Text;

namespace _10201.FillTheMatrix
{
    class FillTheMatrix
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string choice = Console.ReadLine();

            int[,] matrix = new int[n, n];
            int counter = 1;

            switch (choice)
            {
                case "a":
                    for (int col = 0; col < n; col++)
                    {
                        for (int row = 0; row < n; row++)
                        {
                            matrix[row, col] = counter++;
                        }
                    }
                    break;

                case "b":
                    for (int col = 0; col < n; col++)
                    {
                        if (col % 2 == 0)
                        {
                            for (int row = 0; row < n; row++)
                            {
                                matrix[row, col] = counter++;
                            }
                        }
                        else
                        {
                            for (int row = n - 1; row >= 0; row--)
                            {
                                matrix[row, col] = counter++;
                            }
                        }

                    }
                    break;

                case "c":
                    int i = 0;
                    while (counter <= n * n)
                    {
                        int row = (n - 1) - (i < n ? i : n - 1);
                        int col = 0 + (i < n ? 0 : i % n + 1);
                        while (row < n && col < n)
                        {
                            matrix[row++, col++] = counter++;
                        }
                        i++;
                    }
                    break;

                case "d":
                    int r = 0;
                    int c = 0;
                    int padding = 0;

                    while (counter <= n * n)
                    {
                        //Down
                        for (r = 0 + padding; r < n - padding; r++)
                        {
                            matrix[r, c] = counter++;
                        }
                        r--;

                        //Right
                        for (c = 1 + padding; c < (n - 1) - padding; c++)
                        {
                            matrix[r, c] = counter++;
                        }

                        //Up
                        for (r = (n - 1) - padding; r > 0 + padding; r--)
                        {
                            matrix[r, c] = counter++;
                        }

                        //Left
                        for (c = (n - 1) - padding; c > 0 + padding; c--)
                        {
                            matrix[r, c] = counter++;
                        }
                        c++;
                        padding++;
                    }
                    break;
                default:
                    break;
            }

            PrintMatrix(matrix);
        }

        public static void PrintMatrix<T>(T[,] matrix)
        {
            StringBuilder sb = new StringBuilder(matrix.Length);
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    sb.Append(matrix[row, col] + " ");
                }
                sb.Append(matrix[row, matrix.GetLength(1) - 1] + "\n");
            }
            Console.Write(string.Format(sb.ToString()));
        }
    }
}
