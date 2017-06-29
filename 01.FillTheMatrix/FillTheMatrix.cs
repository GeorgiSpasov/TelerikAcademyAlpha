using System;
using System.Text;

namespace _01.FillTheMatrix
{
    class FillTheMatrix
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char choice = char.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];
            int counter = 1;

            switch (choice)
            {
                case 'a':
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            matrix[j, i] = counter++;
                        }
                    }
                    break;

                case 'b':
                    for (int i = 0; i < n; i++)
                    {
                        if (i % 2 == 0)
                        {
                            for (int j = 0; j < n; j++)
                            {
                                matrix[j, i] = counter++;
                            }
                        }
                        else
                        {
                            for (int j = n - 1; j >= 0; j--)
                            {
                                matrix[j, i] = counter++;
                            }
                        }

                    }
                    break;

                case 'c':
                    // TODO
                    
                    break;

                default:
                    break;
            }

            for (int i = 0; i < n; i++)
            {
                StringBuilder row = new StringBuilder();
                for (int j = 0; j < n; j++)
                {
                    row.Append(matrix[i, j] + " ");
                }
                Console.WriteLine(row.ToString().TrimEnd(' '));
            }

        }
    }
}
