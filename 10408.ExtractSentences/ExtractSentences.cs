using System;
using System.Linq;
using System.Text;

namespace _10408.ExtractSentences
{
    class ExtractSentences
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string text = Console.ReadLine();

            string[] sentences = text.Split('.');

            char[] splitChars = text.ToList()
                .Where(ch => !Char.IsLetter(ch))
                .Distinct()
                .ToArray();

            StringBuilder result = new StringBuilder();

            foreach (string sentence in sentences)
            {
                string[] words = sentence.Split(splitChars);
                if (words.Contains(word))
                {
                    result.Append(sentence.Trim() + ". ");
                }
            }
            Console.WriteLine(result.ToString().TrimEnd());
        }
    }
}
