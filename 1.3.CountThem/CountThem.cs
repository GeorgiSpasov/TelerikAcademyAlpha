using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _1._3.CountThem
{
    class CountThem
    {
        static void Main(string[] args)
        {
            bool isComment = false;
            List<string> variables = new List<string>();


            //using (StreamReader reader = new StreamReader("../../test.txt"))
            {
                while (true)
                {
                    string inputLine = Console.ReadLine();
                    //string inputLine = reader.ReadLine();
                    if (inputLine == "{!}")
                    {
                        break;
                    }
                    else if (inputLine.StartsWith("//") ||
                             inputLine.StartsWith("#"))
                    {
                        continue;
                    }
                    GetVariables(inputLine, variables, ref isComment);
                }
            }

            #region Print Result
            variables = variables.Distinct().ToList();
            variables.Sort();
            Console.WriteLine(variables.Count);
            variables.ForEach(Console.WriteLine);
            #endregion
        }

        public static void GetVariables(string inputLine, List<string> variables, ref bool isComment)
        {
            string[] splitters = {" ", "%", "&", "(", ")",
                "+", ".", ",", " / ", ":", ";", "<", "=", ">",
                "?", "[", "]", "^", "{", "|", "}", "~"};

            string[] words = inputLine.Split(splitters, StringSplitOptions.RemoveEmptyEntries);

            bool inDoubleQuotes = false;
            bool inSingleQuotes = false;


            foreach (string word in words)
            {
                switch (word)
                {
                    case "/*":
                        isComment = true;
                        break;
                    case "*/":
                        isComment = false;
                        break;
                    case "//":
                        return;
                    default:
                        break;
                }

                if (isComment)
                {
                    continue;
                }
                else
                {
                    //Console.Write(word + " ");

                    if (word.StartsWith("\""))
                    {
                        inDoubleQuotes = true;
                    }
                    else if (word.EndsWith("\""))
                    {
                        inDoubleQuotes = false;
                    }
                    else if (word.StartsWith("\'"))
                    {
                        inSingleQuotes = true;
                    }
                    else if (word.EndsWith("\'"))
                    {
                        inSingleQuotes = false;
                    }

                    if ((word.StartsWith("@") &&
                        !char.IsNumber(word[1]) &&
                        !word.Contains("-") &&
                        !word.Contains("/")) &&
                        //check string
                        ((!inSingleQuotes && !inDoubleQuotes) ||
                        (word.StartsWith("\\@") ||
                            (!inSingleQuotes ||
                             !inDoubleQuotes)) ||
                        (word.StartsWith("\"@") ||
                               !inSingleQuotes) ||
                        (word.StartsWith("\'@") ||
                               !inDoubleQuotes)))
                    {
                        variables.Add(word
                            .TrimStart('\\')
                            .TrimStart('@')
                            .TrimEnd('\'')
                            .TrimEnd('\"'));
                    }
                }
            }
        }
    }
}
