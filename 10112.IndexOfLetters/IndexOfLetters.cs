using System;
using System.Linq;

namespace _10112.IndexOfLetters
{
    class IndexOfLetters
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            char[] letters = new char[26];
            for (int i = 0; i < letters.Length; i++)
            {
                letters[i] = (char)(i + 97);
            }
            foreach (char letter in word)
            {
                Console.WriteLine(letters.ToList().IndexOf(letter));
            }

        }
    }
}
