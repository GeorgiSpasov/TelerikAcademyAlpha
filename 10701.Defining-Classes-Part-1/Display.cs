namespace _10701.Defining_Classes_Part_1
{
    public class Display
    {
        public int Size { get; set; }
        public int Colors { get; set; }

        public Display(int size, int colors)
        {
            this.Size = size;
            this.Colors = colors;
        }

        public override string ToString()
        {
            return string.Format($"Display\nSize: {this.Size}. Colors: {this.Colors}");
        }
    }
}
