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
            bool inDoubleQuotes = false;
            bool inSingleQuotes = false;

            List<string> variables = new List<string>();


            using (StreamReader reader = new StreamReader("../../test.txt"))
            {
                while (true)
                {
                    //string inputLine = Console.ReadLine();
                    string inputLine = reader.ReadLine();
                    if (inputLine == "{!}")
                    {
                        break;
                    }
                    else if (inputLine.StartsWith("//") ||
                             inputLine.StartsWith("#"))
                    {
                        continue;
                    }
                    if (inputLine.Contains("//")) // trim end after //...
                    {
                        inputLine = inputLine.Remove(inputLine.IndexOf("//"),
                                inputLine.Length - inputLine.IndexOf("//"));
                    }

                    for (int i = 0; i < inputLine.Length - 3; i++)
                    {

                        switch (inputLine.Substring(i, 2))
                        {
                            // Comments start & end
                            case "/*":
                                isComment = true;
                                break;
                            case "*/":
                                isComment = false;
                                break;
                            // String start & end
                            case "\"":
                                inDoubleQuotes = !inDoubleQuotes;
                                break;
                            case "\'":
                                inSingleQuotes = !inSingleQuotes;
                                break;
                            default:
                                break;
                        }

                        if (inputLine[i] == '@')
                        {

                        }

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
                "?", "[", "]", "^", "{", "|", "}", "~", "-", " * "}; // "-" " * "added - fixed runtime error #8

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
                {       // Check vars in strings
                    if (word.StartsWith("@") ||
                        (word.StartsWith("\\@") && !inDoubleQuotes && !inSingleQuotes) ||
                        (word.StartsWith("\'@") && !inDoubleQuotes) ||
                        (word.StartsWith("\"@") && !inSingleQuotes))
                    {
                        variables.Add(word
                            .TrimStart('\\')
                            .TrimStart('\'')
                            .TrimStart('\"')
                            .TrimStart('@')
                            .TrimEnd('\'')
                            .TrimEnd('\"')
                            .TrimEnd('\''));
                    }

                    #region Quotes Check
                    if (word.StartsWith("\"") && word.EndsWith("\""))
                    {
                        //No change in inQuotes
                    }
                    else if (word.StartsWith("\'") && word.EndsWith("\'"))
                    {
                        //No change in inQuotes
                    }
                    else if (word.StartsWith("\""))
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
                    #endregion
                }
            }
        }
    }
}
