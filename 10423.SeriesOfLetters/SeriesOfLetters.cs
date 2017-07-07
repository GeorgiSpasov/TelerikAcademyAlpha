using System;
using System.Text;

namespace _10423.SeriesOfLetters
{
    class SeriesOfLetters
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] != input[i + 1] || i == input.Length - 2)
                {
                    result.Append(input[i]);
                }
            }
            if (input[input.Length - 1] != input[input.Length - 2])
            {
                result.Append(input[input.Length - 1]);
            }

            Console.WriteLine(result);
        }
    }
}
