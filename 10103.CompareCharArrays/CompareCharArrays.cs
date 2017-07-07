using System;

namespace _10103.CompareCharArrays
{
    class CompareCharArrays
    {
        static void Main(string[] args)
        {
            string arrayA = Console.ReadLine();
            string arrayB = Console.ReadLine();
            int result = 0;

            int minLength = arrayA.Length < arrayB.Length ? arrayA.Length : arrayB.Length;
            for (int i = 0; i < minLength; i++)
            {
                if (arrayA[i]!=arrayB[i])
                {
                    result = arrayA[i] - arrayB[i];
                    break;
                }
            }
            if (result==0)
            {
                result = arrayA.Length - arrayB.Length;
            }
            Console.WriteLine(result < 0 ? "<" : result > 0 ? ">" : "=");

        }
    }
}
