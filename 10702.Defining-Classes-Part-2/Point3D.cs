namespace _10702.Defining_Classes_Part_2
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
        public static Point3D O
        {
            get
            {
                return o;
            }
        }
        public override string ToString()
        {
            return string.Format($"X = {this.X}. Y = {this.Y}. Z = {this.Z}");
        }
    }
}
