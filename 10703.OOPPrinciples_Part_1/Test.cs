using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10703.OOPPrinciples_Part_1
{
    public static class Test
    {
        public static void Main()
        {
            HumanTest();
        }

        public static void HumanTest()
        {
            List<Student> students = new Student[]
            {
                new Student("Johny", "Smith", 3),
                new Student("Tommy","Stark", 5),
                new Student("Judy","Collins", 4),
                new Student("Joe", "Bowers", 2),
                new Student("Max","Payne", 6),
                new Student("Tony", "Soprano", 1),
                new Student("Doroty", "Magwyer", 5),
                new Student("Don", "Ton", 7),
                new Student("Jessica", "Simpson", 8),
                new Student("Jimm", "Stanley", 4)
            }.ToList();

            var studentsOrdered = students.OrderBy(s => s.Grade);
            Console.WriteLine(string.Join("\n", studentsOrdered));

        }
    }
}
