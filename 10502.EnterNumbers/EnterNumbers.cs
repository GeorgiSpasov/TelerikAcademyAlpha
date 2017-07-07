using System;

namespace _10502.EnterNumbers
{
    class EnterNumbers
    {
        static void Main(string[] args)
        {
            int[] result = new int[12];
            result[0] = 1;
            result[11] = 100;
            try
            {
                for (int i = 1; i < result.Length; i++)
                {
                    int number = int.Parse(Console.ReadLine());

                    if (result[i - 1] < number && number < 100)
                    {
                        result[i] = number;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                Console.WriteLine(string.Join(" < ", result));
            }
            catch (Exception)
            {
                Console.WriteLine("Exception");
            }
        }
    }
}
