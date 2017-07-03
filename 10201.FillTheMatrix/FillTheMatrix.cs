using System;

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
                    int j = 0;

                    while (counter <= n * n)
                    {
                        //Down
                        for (r = 0 + j; r < (n - 1) - j; r++)
                        {
                            matrix[r, c] = counter++;
                        }

                        //Right
                        for (c = 0 + j; c < (n - 1) - j; c++)
                        {
                            matrix[r, c] = counter++;
                        }

                        //Up
                        for (r = (n - 1) - j; r > 0 + j; r--)
                        {
                            matrix[r, c] = counter++;
                        }

                        //Left
                        for (c = (n - 1) - j; c > 0 + j; c--)
                        {
                            matrix[r, c] = counter++;
                        }
                        c++;
                        j++;
                    }
                    break;
                default:
                    break;
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n - 1; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine(matrix[row, n - 1]);
            }
        }
    }
}
