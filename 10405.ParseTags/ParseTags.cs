using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10405.ParseTags
{
    class ParseTags
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder result = new StringBuilder(text);
            string open = "<upcase>";
            string close = "</upcase>";
            int openIndex = text.Length - 1;
            int closeIndex = text.Length - 1;
            int stringLength = 0;
            string modString = "";

            while (openIndex > -1)
            {
                openIndex = text.LastIndexOf(open, openIndex);
                closeIndex = text.LastIndexOf(close, closeIndex);
                stringLength = openIndex - closeIndex;
                modString = 


            result.Replace();
            }

            text.

            text.Substring()
            text.ToUpper()
        }
    }
}
