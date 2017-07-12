using System;
using System.Globalization;

namespace _10701.Defining_Classes_Part_1
{
    public class Display
    {
        private double size;
        private int colors;

        public Display(double size, int colors)
        {
            this.Size = size;
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
            return string.Format($"Display: {this.Size}\". {this.Colors.ToString("#,#", CultureInfo.InvariantCulture)} colors");
        }
    }
}
