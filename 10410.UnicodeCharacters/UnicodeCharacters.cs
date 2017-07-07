using System;

namespace _10410.UnicodeCharacters
{
    class UnicodeCharacters
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            foreach (char item in input)
            {
                Console.Write("\\u" + ((int)item).ToString("X").PadLeft(4, '0'));
            }
        }
    }
}
