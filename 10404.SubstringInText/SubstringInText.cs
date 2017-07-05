using System;
using System.Text.RegularExpressions;

namespace _10404.SubstringInText
{
    class SubstringInText
    {
        static void Main(string[] args)
        {
            int occurrence;
            string pattern = Console.ReadLine();
            string text = Console.ReadLine();
            occurrence = Regex.Matches(text, pattern).Count;

            Console.WriteLine(occurrence);
        }
    }
}
