using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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
            }

            //Console.WriteLine();
            //Console.WriteLine(cleanText);

            GetVariables(cleanText, variables);

            #region Print Result
            variables = variables.Distinct().Select(v => v.TrimStart('@')).ToList();
            variables.Sort();
            Console.WriteLine(variables.Count);
            variables.ForEach(Console.WriteLine);
            #endregion
        }

        public static void RemoveComments(string inputLine, StringBuilder cleanText, bool isMultiLine = false)
        {
            int commentStart = inputLine.IndexOf("/*");
            int commentEnd = inputLine.IndexOf("*/");

            if (inputLine.StartsWith(@"//") || inputLine.StartsWith("#"))
            {
                return;
            }
            else if (inputLine.Contains(@"//"))
            {
                commentStart = inputLine.IndexOf(@"//");
                cleanText.Append(" " + inputLine.Remove(commentStart, inputLine.Length - commentStart));
            }
            else if (commentStart > -1 && commentEnd > -1) // Comment ends on the same line
            {
                cleanText.Append(" " + inputLine.Remove(commentStart, commentEnd + "*/".Length - commentStart));
            }
            else if (commentStart > -1 && commentEnd < 0) // Starts on this line and ends on next
            {
                cleanText.Append(" " + inputLine.Remove(commentStart, inputLine.Length - commentStart));
                RemoveComments(Console.ReadLine(), cleanText, true); // Search comment's end - isMultiLine = true
            }
            else if (commentStart < 0 && commentEnd < 0 && isMultiLine) // Starts on previous line and ends on next line
            {
                RemoveComments(Console.ReadLine(), cleanText, true);
            }
            else if (commentStart < 0 && commentEnd > -1 && isMultiLine) // Starts on previous line and ends on this line
            {
                cleanText.Append(" " + inputLine.Remove(0, commentEnd + "*/".Length - commentStart));
            }
            else if (commentStart < 0 && commentEnd < 0 && !isMultiLine) // Line without comments
            {
                cleanText.Append(" " + inputLine);
            }
        }

        public static void GetVariables(StringBuilder cleanText, List<string> variables)
        {
            string text = cleanText.ToString();
            char[] splitters = text.ToArray().Where(c =>
                        c != '@' &&
                        c != '_' &&
                        c != '\\' &&
                        c != '-' &&
                        !char.IsLetterOrDigit(c)).ToArray();

            variables.AddRange(text.Split(splitters, StringSplitOptions.RemoveEmptyEntries)
                .Where(w =>
                w.StartsWith("@") &&
                !w.StartsWith(@"\@") &&
                !w.Contains("-") &&
                !w.Contains("\\")).ToArray());
        }
    }
}
