using System;
using System.Globalization;
using System.Text;

namespace _10701.Defining_Classes_Part_1
{
    public class Display
    {
        private double size;
        private int colors;

        public Display(double size)
        {
            this.Size = size;

        }
        public Display(double size, int colors) : this(size)
        {
            this.Colors = colors;
        }
        public double Size
        {
            get
            {
                return this.size;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid size entered!");
                }
                this.size = value;
            }
        }
        public int Colors
        {
            get
            {
                return this.colors;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid color's number entered!");
                }
                this.colors = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder($"Display: {this.Size}\"");
            if (this.Colors != 0)
            {
                result.Append($". {this.Colors.ToString("#,#", CultureInfo.InvariantCulture)} colors");
            }
            return result.ToString();
        }
    }
}
