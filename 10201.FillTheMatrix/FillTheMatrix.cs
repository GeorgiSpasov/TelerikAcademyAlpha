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
                    // TODO =========================================================





                    break; // =======================================================

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
