using System;

namespace _10301.SayHello
{
    class SayHello
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            Greeting(name);
        }
        public static void Greeting(string name)
        {
            Console.WriteLine("Hello, {0}!", name);
        }
    }
}
