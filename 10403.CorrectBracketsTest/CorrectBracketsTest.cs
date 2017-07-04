using System;

namespace _10403.CorrectBracketsTest
{
    class CorrectBracketsTest
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int check = 0;
            string isCorrect = "Incorrect";

            foreach (char item in input)
            {
                if (item == '(')
                {
                    check++;
                }
                else if (item == ')')
                {
                    check--;
                    if (check < 0)
                    {
                        break;
                    }
                }
            }
            if (check == 0)
            {
                isCorrect = "Correct";
            }
            Console.WriteLine(isCorrect);
        }
    }
}
