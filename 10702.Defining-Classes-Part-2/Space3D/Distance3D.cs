using System;

namespace _10702.Defining_Classes_Part_2.Space3D
{
    public static class Distance3D
    {
        public static double Calculate(Point3D a, Point3D b)
        {
            double distance = Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2) + Math.Pow(b.Z - a.Z, 2));
            return distance;
        }
    }
}
