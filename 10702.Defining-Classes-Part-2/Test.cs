using System;
using _10702.Defining_Classes_Part_2.Generic;
using _10702.Defining_Classes_Part_2.Space3D;

namespace _10702.Defining_Classes_Part_2
{
    public class Test
    {
        static void Main(string[] args)
        {
            GenericList<Point3D> pointsArray = new GenericList<Point3D>(2);
            pointsArray.AddElement(Point3D.o); // Not printed (default value)
            pointsArray.AddElement(new Point3D(1, 1, 1));
            pointsArray.AddElement(new Point3D(2, 2, 2));
            pointsArray.AddElement(new Point3D(3, 3, 3));
            pointsArray.AddElement(new Point3D(4, 4, 4));
            pointsArray.AddElement(new Point3D(5, 5, 5));

            Console.WriteLine(pointsArray + "\n");
            Console.WriteLine(pointsArray.GetElement(2) + "\n");

            pointsArray.RemoveElement(2);
            Console.WriteLine(pointsArray + "\n");

            pointsArray.InsertElementAt(2, new Point3D(9, 9, 9));
            Console.WriteLine(pointsArray + "\n");

            Console.WriteLine(pointsArray.FindElement(new Point3D(7, 7, 7)));

            pointsArray.ClearList();
            Console.WriteLine(pointsArray + "\n");
        }
    }
}
