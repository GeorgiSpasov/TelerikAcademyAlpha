using System;
using System.Text;

namespace _10406.StringLength
{
    class StringLength
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder(20);
            string input = Console.ReadLine();
            result.Append(input)
                  .Append(new string('*', 20 - input.Length));
            Console.WriteLine(result.ToString());
        }
    }
}
