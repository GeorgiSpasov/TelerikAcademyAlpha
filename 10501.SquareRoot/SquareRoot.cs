using System;

namespace _10501.SquareRoot
{
    class SquareRoot
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            try
            {
                double number = double.Parse(input);
                if (number<0)
                {
                    throw new SystemException();
                }
                double squareRoot = Math.Sqrt(number);
                Console.WriteLine(squareRoot.ToString("0.000"));

            }
            catch (SystemException)
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
