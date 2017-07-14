namespace _10702.Defining_Classes_Part_2.Space3D
{
    public struct Point3D
    {
        public static Point3D o = new Point3D(0, 0, 0);

        public Point3D(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public override string ToString()
        {
            return string.Format($"[x:{this.X} y:{this.Y} z:{this.Z}]");
        }
    }
}
