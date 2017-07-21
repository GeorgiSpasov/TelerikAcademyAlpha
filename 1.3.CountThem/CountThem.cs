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
            //bool isComment = false;

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

                ProcessLine(input, variables); //===================================================

                #region v.2 100/100
                //bool inDoubleQuotes = false; //No multi-line strings
                //bool inSingleQuotes = false;

                //if (input == "{!}")
                //{
                //    break;
                //}
                //else if (input.StartsWith("//") || input.StartsWith("#"))
                //{
                //    continue;
                //}

                //for (int i = 0; i < input.Length; i++)
                //{
                //    //Comment start & end
                //    if (input[i] == '/' && i < input.Length - 1 && input.Substring(i, 2) == "/*")
                //    {
                //        isComment = true;
                //        i++;
                //    }
                //    else if (input[i] == '*' && i < input.Length - 1 && input.Substring(i, 2) == "*/")
                //    {
                //        isComment = false;
                //        i++;
                //    }
                //    else if (input[i] == '\'' && !isComment)
                //    {
                //        inSingleQuotes = !inSingleQuotes;
                //    }
                //    else if (input[i] == '\"' && !isComment) //String start & end 
                //    {
                //        inDoubleQuotes = !inDoubleQuotes;
                //    }
                //    else if (input[i] == '/' && !inSingleQuotes && !inDoubleQuotes && i < input.Length - 1 && input.Substring(i, 2) == "//") //The start of line is handled above && "https://someUrl.com" @varAfterURL
                //    {
                //        break;
                //    }
                //    else if (!isComment && input[i] == '@')
                //    {
                //        if ((inSingleQuotes ^ inDoubleQuotes) && input[i - 1] == '\\' && input[i - 2] != '\\')
                //        {
                //            continue;
                //        }
                //        else if ((inSingleQuotes && input[i - 1] == '\"') || (inDoubleQuotes && input[i - 1] == '\'')) // " or ' escaping
                //        {
                //            continue;
                //        }

                //        StringBuilder variable = new StringBuilder();
                //        i++;
                //        while (i < input.Length && (char.IsLetterOrDigit(input[i]) || input[i] == '_'))
                //        {
                //            variable.Append(input[i]);
                //            i++;
                //        }
                //        i--;

                //        if (variable.Length > 0)
                //        {
                //            variables.Add(variable.ToString());
                //        }
                //    }
                //}
                #endregion
            }

            variables = variables.Distinct().ToList();
            variables.Sort();
            Console.WriteLine(variables.Count);
            variables.ForEach(Console.WriteLine);
        }

        //v.3
        public static void ProcessLine(string input, List<string> variables, bool isComment = false)
        {
            int searchIndex = 0;

            if (isComment && input.IndexOf("*/") == -1)
            {
                ProcessLine(Console.ReadLine(), variables, true);
                return;
            }
            else if (isComment && input.IndexOf("*/") != -1)
            {
                isComment = false;
                searchIndex = input.IndexOf("*/") + "*/".Length;
            }

            int[] indices = new int[] {
                            input.IndexOf("/*", searchIndex),
                            input.IndexOf("*/", searchIndex),
                            input.IndexOf("\'", searchIndex),
                            input.IndexOf("\"", searchIndex),
                            input.IndexOf("//", searchIndex),
                            input.IndexOf("@", searchIndex)
            };

            bool inSingleQuotes = false;
            bool inDoubleQuotes = false;

            while (indices.Max() > -1)
            {
                searchIndex = indices.OrderBy(a => a).First(a => a > -1);
                char currentSymbol = input[searchIndex];

                switch (currentSymbol)
                {
                    case '/':
                        if (!inSingleQuotes && !inDoubleQuotes && searchIndex < input.Length - 1 && input.Substring(searchIndex, 2) == "//")
                        {
                            return;
                        }
                        else
                        {
                            isComment = true;
                            searchIndex += "/*".Length;

                            if (input.IndexOf("*/", searchIndex) == -1)
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
                            inSingleQuotes = !inSingleQuotes;
                        }
                        searchIndex++;
                        break;
                    case '\"':
                        if (!isComment)
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
                        else if ((inSingleQuotes ^ inDoubleQuotes) && input[searchIndex - 1] == '\\' && input[searchIndex - 2] != '\\')
                        {
                            searchIndex++;
                        }
                        else if ((inSingleQuotes && input[searchIndex - 1] == '\"') || (inDoubleQuotes && input[searchIndex - 1] == '\''))
                        {
                            searchIndex++;
                        }
                        else
                        {
                            StringBuilder variable = new StringBuilder();
                            searchIndex++;
                            while (searchIndex < input.Length && (char.IsLetterOrDigit(input[searchIndex]) || input[searchIndex] == '_'))
                            {
                                variable.Append(input[searchIndex]);
                                searchIndex++;
                            }

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
                            input.IndexOf("/*", searchIndex),
                            input.IndexOf("*/", searchIndex),
                            input.IndexOf("\'", searchIndex),
                            input.IndexOf("\"", searchIndex),
                            input.IndexOf("//", searchIndex),
                            input.IndexOf("@", searchIndex)
                };
            }
        }
    }
}