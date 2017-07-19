using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._3.CountThem
{
    public static class CommentsCleaner
    {
        public static void RemoveComments(string inputLine, StringBuilder cleanText, bool isMultiLine = false)
        {
            int commentStart = inputLine.IndexOf("/*");
            int commentEnd = inputLine.IndexOf("*/");

            if (inputLine.StartsWith(@"//") || inputLine.StartsWith("#"))
            {
                return;
            }
            else if (inputLine.Contains(@"//") && inputLine.IndexOf(@"//") < commentStart) // words //comments...
            {
                commentStart = inputLine.IndexOf(@"//");
                cleanText.Append(" " + inputLine.Remove(commentStart, inputLine.Length - commentStart));
            }
            else if (commentStart > -1 && commentEnd > -1) // ==============================================================================
            {
                if (inputLine.Contains(@"//")) // comment */ words // comments.... ???
                {

                }
                else if (commentStart < commentEnd) // Comment ends on the same line ???????????? */ words // comments.... ???
                {
                    // words /* start */ more words /* second */ words /* to second line



                    while (commentStart > -1 || commentStart < commentEnd) // till commentEnd =-1
                    {
                        inputLine = inputLine.Remove(0, commentEnd + "*/".Length);
                        commentStart = inputLine.IndexOf("/*");

                        if (commentStart < commentEnd)
                        {

                        }
                    }



                    cleanText.Append(" " + inputLine.Remove(commentStart, commentEnd + "*/".Length - commentStart));
                }
                else if (commentStart > commentEnd) // First ends and than starts
                {
                    // some text*/ not comment /*start of new comment
                    inputLine = inputLine.Remove(0, commentEnd + "*/".Length);
                    commentStart = inputLine.IndexOf("/*");

                    cleanText.Append(" " + inputLine.Remove(commentStart, inputLine.Length - commentStart));
                    RemoveComments(Console.ReadLine(), cleanText, true); // Search comment's end - isMultiLine = true
                }
            }//=============================================================================================================================
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
                cleanText.Append(" " + inputLine.Remove(0, commentEnd + "*/".Length));
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
