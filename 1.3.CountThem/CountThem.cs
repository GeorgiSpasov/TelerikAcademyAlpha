using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1._3.CountThem
{
    public class CountThem
    {
        static void Main(string[] args)
        {
            List<string> variables = new List<string>();
            bool isComment = false;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "{!}")
                {
                    break;
                }
                else if (input.StartsWith("//") || input.StartsWith("#"))
                {
                    continue;
                }

                //ProcessLine(input, variables);

                #region v.2 80/100
                bool inDoubleQuotes = false; //No multi-line strings
                bool inSingleQuotes = false;

                if (input == "{!}")
                {
                    break;
                }
                else if (input.StartsWith("//") || input.StartsWith("#"))
                {
                    continue;
                }

                for (int i = 0; i < input.Length; i++)
                {
                    //Comment start & end
                    if (input[i] == '/' && i < input.Length - 1 && input.Substring(i, 2) == "/*")
                    {
                        isComment = true;
                        i++;
                    }
                    else if (input[i] == '*' && i < input.Length - 1 && input.Substring(i, 2) == "*/")
                    {
                        isComment = false;
                        i++;
                    }
                    else if (input[i] == '\"' && !isComment) //String start & end + check for escaping -> && input[i-1] != '\\'
                    {
                        //if (inSingleQuotes == true && i < input.Length - 1 && !isComment && input[i + 1] == '@')
                        {
                            inDoubleQuotes = !inDoubleQuotes;
                        }
                        //else if (inSingleQuotes == false)
                        //{
                        //    inDoubleQuotes = !inDoubleQuotes;
                        //}
                    }
                    else if (input[i] == '\'' && !isComment)
                    {
                        //if (inDoubleQuotes == true && i < input.Length - 1 && !isComment && input[i + 1] == '@')
                        {
                            inSingleQuotes = !inSingleQuotes;
                        }
                        //else if (inDoubleQuotes == false)
                        //{
                        //    inSingleQuotes = !inSingleQuotes;
                        //}
                    }
                    else if (input[i] == '/' && !inSingleQuotes && !inDoubleQuotes && i < input.Length - 1 && input[i + 1] == '/') //The start of line is handled above
                    {
                        break;
                    }
                    else if (!isComment && input[i] == '@')
                    {
                        if ((inSingleQuotes ^ inDoubleQuotes) && input[i - 1] == '\\') // \@var in string -> "Tom's \@hardware" - works with ||
                        {
                            continue;
                        }
                        else if ((inSingleQuotes && input[i - 1] == '\"') || (inDoubleQuotes && input[i - 1] == '\'')) // " or ' escaping
                        {
                            continue;
                        }

                        StringBuilder variable = new StringBuilder();
                        i++;
                        while (i < input.Length && (char.IsLetterOrDigit(input[i]) || input[i] == '_'))
                        {
                            variable.Append(input[i]);
                            i++;
                        }
                        i--;

                        if (variable.Length > 0)
                        {
                            variables.Add(variable.ToString());
                        }
                    }
                }
                #endregion
            }

            variables = variables.Distinct().ToList();
            variables.Sort();
            Console.WriteLine(variables.Count);
            variables.ForEach(Console.WriteLine);
        }


        public static void ProcessLine(string inputLine, List<string> variables, bool isComment = false)
        {
            if (inputLine.StartsWith("//") || inputLine.StartsWith("#"))
            {
                return;
            }

            int searchIndex = 0;

            if (isComment && inputLine.IndexOf("*/") == -1)
            {
                ProcessLine(Console.ReadLine(), variables, true);
                return;
            }
            else if (isComment && inputLine.IndexOf("*/") != -1)
            {
                isComment = false;
                searchIndex = inputLine.IndexOf("*/") + "*/".Length;
            }

            int[] indices = new int[] {
                            inputLine.IndexOf("/*", searchIndex),
                            inputLine.IndexOf("*/", searchIndex),
                            inputLine.IndexOf("\'", searchIndex),
                            inputLine.IndexOf("\"", searchIndex),
                            inputLine.IndexOf("//", searchIndex),
                            inputLine.IndexOf("@", searchIndex)
            };

            bool inSingleQuotes = false;
            bool inDoubleQuotes = false;

            while (indices.Max() > -1)
            {
                searchIndex = indices.OrderBy(a => a).First(a => a > -1);
                char currentSymbol = inputLine[searchIndex];

                switch (currentSymbol)
                {
                    case '/':
                        if (searchIndex < inputLine.Length - 1 && inputLine[searchIndex + 1] == '/')
                        {
                            return;
                        }
                        else
                        {
                            isComment = true;
                            searchIndex += "/*".Length;
                            if (inputLine.IndexOf("*/", searchIndex) == -1)
                            {
                                ProcessLine(Console.ReadLine(), variables, true);
                                return;
                            }
                        }
                        break;
                    case '*':
                        isComment = false;
                        searchIndex += "*/".Length;
                        break;
                    case '\'':
                        if (!isComment)
                        {
                            if (inDoubleQuotes == true && searchIndex < inputLine.Length - 1 && inputLine[searchIndex + 1] == '@')
                            {
                                inSingleQuotes = !inSingleQuotes;
                            }
                            else if (inDoubleQuotes == false)
                            {
                                inSingleQuotes = !inSingleQuotes;
                            }
                        }
                        searchIndex++;
                        break;
                    case '\"':
                        if (!isComment && searchIndex < inputLine.Length - 1 && inputLine[searchIndex + 1] != '@')
                        {
                            inDoubleQuotes = !inDoubleQuotes;
                        }
                        searchIndex++;
                        break;
                    case '@':
                        if (isComment)
                        {
                            searchIndex++;
                        }
                        else if ((inSingleQuotes ^ inDoubleQuotes) && inputLine[searchIndex - 1] == '\\')
                        {
                            searchIndex++;
                        }
                        else if ((inSingleQuotes && inputLine[searchIndex - 1] == '\"') || (inDoubleQuotes && inputLine[searchIndex - 1] == '\''))
                        {
                            searchIndex++;
                        }
                        else
                        {
                            StringBuilder variable = new StringBuilder();
                            searchIndex++;
                            while (searchIndex < inputLine.Length && (char.IsLetterOrDigit(inputLine[searchIndex]) || inputLine[searchIndex] == '_'))
                            {
                                variable.Append(inputLine[searchIndex]);
                                searchIndex++;
                            }
                            //searchIndex--; - difference with previous --- 80/100

                            if (variable.Length > 0)
                            {
                                variables.Add(variable.ToString());
                            }
                        }
                        break;
                    default:
                        break;
                }

                indices = new int[] {
                            inputLine.IndexOf("/*", searchIndex),
                            inputLine.IndexOf("*/", searchIndex),
                            inputLine.IndexOf("\'", searchIndex),
                            inputLine.IndexOf("\"", searchIndex),
                            inputLine.IndexOf("//", searchIndex),
                            inputLine.IndexOf("@", searchIndex)
                };
            }
        }
    }
}