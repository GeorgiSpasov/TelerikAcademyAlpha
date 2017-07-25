using System;
using System.Collections.Generic;
using System.IO;

namespace _10702.Defining_Classes_Part_2.Space3D
{
    public static class PathStorage
    {
        public static void StorePath(List<Point3D> path, string fileName)
        {
            using (StreamWriter writer = new StreamWriter($"../../{fileName}.txt", true))
            {
                foreach (Point3D point in path)
                {
                    writer.WriteLine(point);
                }
            }
        }

        public static List<Point3D> RestorePath(string address)
        {
            List<Point3D> result = new List<Point3D>();
            using (StreamReader reader = new StreamReader(address))
            {
                while (!reader.EndOfStream)
                {
                    string[] line = reader.ReadLine().Split(new char[] { ' ', ':', '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
                    result.Add(new Point3D(int.Parse(line[1]), int.Parse(line[3]), int.Parse(line[5])));

                }

                return result;
            }
        }
    }
}
