using System;

namespace _1._1.SendMeTheCode
{
    class SendMeTheCode
    {
        static void Main(string[] args)
        {
            int[] digits = Array.ConvertAll(Console.ReadLine()
                .TrimStart('-')
                .ToCharArray()
                , n => n - '0');
            int result = 0;

            for (int i = 1; i < digits.Length + 1; i++)
            {
                if (i % 2 != 0)
                {
                    result += digits[digits.Length - i] * (int)Math.Pow(i, 2);
                }
                else if (i % 2 == 0)
                {
                    result += (int)Math.Pow(digits[digits.Length - i], 2) * i;
                }
            }

            int lastDigit = result.ToString()[result.ToString().Length - 1] - '0';
            if (lastDigit == 0)
            {
                Console.WriteLine(result);
                Console.WriteLine("Big Vik wins again!");
            }
            else
            {
                int messageLength = lastDigit;
                char[] message = new char[messageLength];
                int asciiStartIndex = result % 26 + 1 + 64;

                for (int i = 0; i < messageLength; i++)
                {
                    if (asciiStartIndex > 90)
                    {
                        asciiStartIndex -= 26;
                    }
                    message[i] = ((char)asciiStartIndex);
                    asciiStartIndex++;
                }

                Console.WriteLine(result);
                Console.WriteLine(string.Join("", message));
            }
        }
    }
}
