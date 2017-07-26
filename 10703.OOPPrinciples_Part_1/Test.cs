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
            Console.WriteLine(string.Join("\n", studentsOrdered) + "\n");

            List<Worker> workers = new Worker[]
            {
                new Worker("Strabard", "Trasgard", 1200, 10),
                new Worker("Tristan", "Sgasgard", 1000, 7),
                new Worker("Jimm", "Casta", 2300, 12),
                new Worker("Droty", "Rosy", 1350, 10),
                new Worker("Casty", "Lasty", 2250, 11),
                new Worker("Standan", "Ragnard", 980, 5),
                new Worker("Roody", "Dooty", 350, 2),
                new Worker("Tarnan", "Rass", 3500, 12),
                new Worker("Zero", "Hero", 3200, 11),
                new Worker("Doroty", "Casy", 2100, 8)
            }.ToList();

            var workersRank = workers.OrderByDescending(w => w.MoneyPerHour());
            Console.WriteLine(string.Join("\n", workersRank) + "\n");

            IEnumerable<Human> humans = students.Concat<Human>(workers)
                .OrderBy(h => h.FirstName)
                .ThenBy(h => h.LastName);
            Console.WriteLine(string.Join("\n", humans) + "\n");
        }
    }
}
