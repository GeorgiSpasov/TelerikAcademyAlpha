using System;
using System.Linq;

namespace _10307.ReverseNumber
{
    class ReverseNumber
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            string reversed = Reverser(number);
            Console.WriteLine(reversed);
        }
        public static string Reverser(string number)
        {
            string reversed = String.Join("", number.ToArray().Reverse());
            return reversed;
        }
    }
}
