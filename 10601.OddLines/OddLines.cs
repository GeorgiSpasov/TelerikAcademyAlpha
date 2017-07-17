using System;
using System.IO;

namespace _10601.OddLines
{
    public class OddLines
    {
        static void Main(string[] args)
        {
            using (StreamWriter writer = new StreamWriter("../../test.txt", false))
            {
                for (int i = 0; i < 10; i++)
                {
                    writer.WriteLine($"Line #{i}");
                }
            }

            using (StreamReader reader = new StreamReader("../../test.txt"))
            {
                int lineCounter = 0;
                while (!reader.EndOfStream)
                {
                    if (lineCounter % 2 != 0)
                    {
                        Console.WriteLine(reader.ReadLine());
                    }
                    else
                    {
                        reader.ReadLine();
                    }
                    lineCounter++;
                }
            }
        }
    }
}
