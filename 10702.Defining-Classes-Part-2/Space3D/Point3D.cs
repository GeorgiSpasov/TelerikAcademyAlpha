using System;

namespace _10702.Defining_Classes_Part_2.Space3D
{
    public struct Point3D : IComparable<Point3D>
    {
        private static readonly Point3D o = new Point3D(0, 0, 0);

        public Point3D(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public static Point3D O { get { return o; } }

        public override string ToString()
        {
            return string.Format($"[x:{this.X} y:{this.Y} z:{this.Z}]");
        }

        public int CompareTo(Point3D other)
        {
            int result = 0;
            if ((this.X + this.Y + this.Z) < (other.X + other.Y + other.Z))
            {
                result = -1;
            }
            else if ((this.X + this.Y + this.Z) == (other.X + other.Y + other.Z))
            {
                result = 0;
            }
            else
            {
                result = (this.X + this.Y + this.Z) - (other.X + other.Y + other.Z);
            }

            return result;
            throw new NotImplementedException();
        }
    }
}
