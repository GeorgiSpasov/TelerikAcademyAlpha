using System;
using System.Linq;

namespace _1._2.MovingBackAndForward
{
    class MovingBackAndForward
    {
        static void Main(string[] args)
        {
            int currentIndex = int.Parse(Console.ReadLine());
            int[] array = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
            int sumForward = 0;
            int sumBackward = 0;
            int steps = 0;
            int stepSize = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "exit")
                {
                    break;
                }

                steps = int.Parse(input.Split(' ')[0]);
                stepSize = int.Parse(input.Split(' ')[2]) % array.Length;

                //FORWARD
                if (input.Split(' ')[1] == "forward")
                {
                    for (int i = 0; i < steps; i++)
                    {
                        sumForward += array[currentIndex = (currentIndex + stepSize) % array.Length];
                    }
                }
                else //BACKWARD
                {
                    for (int i = 0; i < steps; i++)
                    {
                        if (currentIndex - stepSize < 0)
                        {
                            currentIndex += array.Length;
                        }

                        sumBackward += array[currentIndex = (currentIndex - stepSize) % array.Length];
                    }
                }
            }

            Console.WriteLine("Forward: " + sumForward);
            Console.WriteLine("Backwards: " + sumBackward);
        }
    }
}
