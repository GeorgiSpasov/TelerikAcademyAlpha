using System;

namespace _10404.SubstringInText
{
    class SubstringInText
    {
        static void Main(string[] args)
        {
            string pattern = Console.ReadLine();
            string text = Console.ReadLine();
            int occurrence = 0;
            int index = text.Length - 1;

            while (index > -1)
            {
                index = text.LastIndexOf(pattern, index,StringComparison.InvariantCultureIgnoreCase);
                if (index > -1)
                {
                    occurrence++;
                }
            }
            Console.WriteLine(occurrence);
        }
    }
}
