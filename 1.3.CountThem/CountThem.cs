using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _1._3.CountThem
{
    class CountThem
    {
        static void Main(string[] args)
        {
            string inputLine = null;
            StringBuilder cleanText = new StringBuilder();

            List<string> variables = new List<string>();


            while (inputLine != "{!}")
            {
                inputLine = Console.ReadLine();

                RemoveComments(inputLine, cleanText);

                GetVariables(cleanText.ToString(), variables);
            }

            //Console.WriteLine(cleanText);

            #region Print Result
            variables = variables.Distinct().Select(v => v.TrimStart('@')).ToList();
            variables.Sort();
            Console.WriteLine(variables.Count);
            variables.ForEach(Console.WriteLine);
            #endregion
        }

        public static StringBuilder RemoveComments(string inputLine, StringBuilder cleanText)
        {
            int commentStart = 0;
            int commentEnd = 0;
            commentStart = inputLine.IndexOf("/*");
            commentEnd = inputLine.IndexOf("*/");

            if (inputLine.StartsWith(@"//") || inputLine.StartsWith("#"))
            {
                return cleanText;
            }
            else if (inputLine.Contains(@"//"))
            {
                commentStart = inputLine.IndexOf(@"//");
                cleanText.Append(" " + inputLine.Remove(commentStart, inputLine.Length - commentStart));
            }
            else if (commentStart < 0 && commentEnd < 0) // Starts on previous line and end on next line
            {
                // Read next line
                cleanText.Append(" " + RemoveComments(Console.ReadLine(), cleanText));
            }
            else if (commentEnd < 0) // Ends on next line
            {
                cleanText.Append(" " + inputLine.Remove(commentStart, inputLine.Length - commentStart));
                cleanText.Append(" " + RemoveComments(Console.ReadLine(), cleanText)); // Search end of comment??? remove recursion
            }
            else if (commentStart < 0) // Starts on previous line and ends on this line
            {
                cleanText.Append(" " + inputLine.Remove(0, commentEnd + "*/".Length + commentStart)); // ¯\_(ツ)_/¯
            }
            else if (commentEnd > -1) // Comment ends on the same line
            {
                //inputLine.Remove(commentStart, commentEnd - commentStart);
                cleanText.Append(" " + inputLine.Remove(commentStart, commentEnd + "*/".Length - commentStart));
            }

            return cleanText;
        }

        public static void GetVariables(string inputLine, List<string> currentVars) // currentVars == variables
        {
            char[] splitters = inputLine.ToArray().Where(c =>
                        c != '@' &&
                        c != '_' &&
                        c != '\\' &&
                        c != '-' &&
                        !char.IsLetterOrDigit(c)).ToArray();

            currentVars.AddRange(
            inputLine.Split(splitters, StringSplitOptions.RemoveEmptyEntries).Where(w =>
                w.StartsWith("@") &&
                !w.StartsWith(@"\@") &&
                !w.Contains("-") &&
                !w.Contains("\\")).ToArray());

            //no return => currentVars is reference type
        }
    }
}
