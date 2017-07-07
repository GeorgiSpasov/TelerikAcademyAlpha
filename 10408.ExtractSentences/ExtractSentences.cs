using System;
using System.Collections.Generic;
using System.Text;

namespace _10408.ExtractSentences
{
    class ExtractSentences
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string text = Console.ReadLine();

            int startIndex = 0;
            int endIndex = 0;
            string sentence;
            StringBuilder result = new StringBuilder();

            List<char> nonChars = new List<char>();
            for (int i = 0; i < 127; i++)
            {
                if (!Char.IsLetter((char)i))
                {
                    nonChars.Add((char)i);
                }
            }
            char[] splitters = nonChars.ToArray();
            //Console.WriteLine(string.Join(" ",splitters));

            while (true)
            {
                if (endIndex == text.Length)
                {
                    break;
                }
                endIndex = text.IndexOf('.', startIndex + 1);

                sentence = text.Substring(startIndex, endIndex - startIndex + 1);
                //Console.WriteLine(sentence);

                if (CheckPresence(word, sentence, splitters))
                {
                    result.Append(sentence);
                }
                startIndex = endIndex + 1;
                endIndex++;
            }
            Console.WriteLine(result);
        }

        public static bool CheckPresence(string word, string sentence, char[] splitters)
        {
            bool result = false;
            string[] words = sentence.Split(splitters);
            foreach (string item in words)
            {
                if (item == word)
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
