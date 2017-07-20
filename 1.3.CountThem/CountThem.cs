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
            bool isComment = false;
            bool inDoubleQuotes = false;
            bool inSingleQuotes = false;

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
                    if (inputLine.Contains("//")) // trim end after //...
                    {
                        inputLine = inputLine.Remove(inputLine.IndexOf("//"), inputLine.Length - inputLine.IndexOf("//"));
                    }

                    for (int i = 0; i < inputLine.Length; i++)
                    {
                        // Comments start & end
                        if (inputLine[i] == '/' && i < inputLine.Length - 1 && inputLine.Substring(i, 2) == "/*")
                        {
                            isComment = true;
                            i++;
                        }
                        else if (inputLine[i] == '*' && i < inputLine.Length - 1 && inputLine.Substring(i, 2) == "*/")
                        {
                            isComment = false;
                            i++;
                        }

                        // String start & end
                        switch (inputLine[i])
                        {
                            case '\"':
                                inDoubleQuotes = !inDoubleQuotes;
                                break;
                            case '\'':
                                inSingleQuotes = !inSingleQuotes;
                                break;
                            default:
                                break;
                        }

                        if (isComment == false && inputLine[i] == '@')
                        {
                            if (inSingleQuotes && inDoubleQuotes)
                            {
                                continue;
                            }
                            else if ((inSingleQuotes || inDoubleQuotes) && inputLine[i - 1] == '\\') // \@var in string
                            {
                                continue;
                            }
                            else
                            {
                                //extract var
                                StringBuilder variable = new StringBuilder();
                                i++; //start check from next char
                                while (i < inputLine.Length && (char.IsLetterOrDigit(inputLine[i]) || inputLine[i] == '_'))
                                {
                                    variable.Append(inputLine[i]);
                                    i++;
                                }
                                i--;
                                variables.Add(variable.ToString()
                                    //.TrimStart('\\')
                                    .TrimStart('\'')
                                    .TrimStart('\"')
                                    //.TrimStart('@')
                                    .TrimEnd('\'')
                                    .TrimEnd('\"')
                                    .TrimEnd('\''));
                            }
                        }
                    }
                }
            }



            #region Print Result
            variables = variables.Distinct().ToList();
            variables.Sort();
            Console.WriteLine(variables.Count);
            variables.ForEach(Console.WriteLine);
            #endregion
        }
    }
}
