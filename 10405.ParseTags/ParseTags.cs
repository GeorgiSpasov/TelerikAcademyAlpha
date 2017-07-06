using System;
using System.Text;

namespace _10405.ParseTags
{
    class ParseTags
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder result = new StringBuilder(text);
            string openingTag = "<upcase>";
            string closingTag = "</upcase>";
            int openIndex = text.Length - 1;
            int closeIndex = text.Length - 1;
            int selectionLength = 0;
            string selection = "";

            while (true)
            {
                openIndex = text.LastIndexOf(openingTag, openIndex);
                if (openIndex == -1)
                {
                    break;
                }
                closeIndex = text.LastIndexOf(closingTag, closeIndex);
                selectionLength = closeIndex - openIndex - openingTag.Length;
                if (selectionLength == 0)
                {
                    continue;
                }
                selection = text.Substring(openIndex + openingTag.Length, selectionLength);
                result.Replace(selection, selection.ToUpper(), openIndex + openingTag.Length, selectionLength);
            }
            result.Replace(openingTag, "");
            result.Replace(closingTag, "");

            Console.WriteLine(result.ToString());
        }
    }
}
