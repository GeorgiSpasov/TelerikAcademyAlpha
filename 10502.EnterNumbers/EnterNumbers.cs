using System;

namespace _10502.EnterNumbers
{
    class EnterNumbers
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[12];
            numbers[0] = 1;
            numbers[11] = 100;

            try
            {
                for (int i = 1; i < numbers.Length - 1; i++)
                {
                    int number = int.Parse(Console.ReadLine());

                    if (numbers[i - 1] < number && number < 100)
                    {
                        numbers[i] = number;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
                Console.WriteLine(string.Join(" < ", numbers));
            }
            catch (SystemException)
            {
                Console.WriteLine("Exception");
            }
        }
    }
}
