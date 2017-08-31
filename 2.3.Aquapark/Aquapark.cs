using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._3.Aquapark
{
    public class Aquapark
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int> queue = new Queue<int>();

            string[] commandParams;
            string command;
            int currentId;
            int k;
            for (int i = 0; i < n; i++)
            {
                commandParams = Console.ReadLine().Split(' ');
                command = commandParams[0];
                switch (command)
                {
                    case "add":
                        currentId = int.Parse(commandParams[1]);
                        queue.Enqueue(currentId);
                        Console.WriteLine("Added " + currentId);
                        break;

                    case "slide":
                        k = int.Parse(commandParams[1]);
                        for (int j = 0; j < k % queue.Count; j++)
                        {
                            int buffer = queue.Dequeue();
                            queue.Enqueue(buffer);
                        }
                        Console.WriteLine("Slided " + k);
                        break;

                    case "print":

                        Console.WriteLine(string.Join(" ", queue.Reverse()));
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
