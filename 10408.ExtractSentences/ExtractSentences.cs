using System;
using System.Collections.Generic;
using System.Text;

namespace _10408.ExtractSentences
{
    class ExtractSentences
    {
        // 20 / 100

        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string text = Console.ReadLine();

            //string word = "in";
            //string text = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";

            int startIndex = text.Length - 2;
            int endIndex = text.Length - 1;
            string sentence;
            StringBuilder result = new StringBuilder();

            List<char> nonChars = new List<char>();
            for (int i = 0; i < 127; i++)
            {
                if (Char.IsLetter((char)i))
                {
                    continue;
                }
                else
                {
                    nonChars.Add((char)i);
                }
            }
            char[] splitters = nonChars.ToArray();
            //Console.WriteLine(string.Join(" ",splitters));

            while (true)
            {
                startIndex = text.LastIndexOf('.', startIndex);
                if (startIndex < 0)
                {
                    sentence = text.Substring(startIndex + 1, endIndex - startIndex);
                    if (CheckPresence(word, sentence, splitters))
                    {
                        result.Insert(0, sentence);
                    }
                    break;
                }

                sentence = text.Substring(startIndex + 1, endIndex - startIndex);
                //Console.WriteLine(sentence);
                if (CheckPresence(word, sentence, splitters))
                {
                    result.Insert(0, sentence);
                }
                endIndex = startIndex;
                startIndex--;
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
