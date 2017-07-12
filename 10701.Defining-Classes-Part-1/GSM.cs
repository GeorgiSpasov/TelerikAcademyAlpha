using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10701.Defining_Classes_Part_1
{
    public class GSM
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
        public string Owner { get; set; }
        public Battery Battery { get; set; }
        public Display Display { get; set; }

        public GSM(string manufacturer, string model, int price = 0, string owner = null, Battery battery = null, Display display = null)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Price = price;
            this.Owner = owner;
            this.Battery = battery;
            this.Display = display;
        }

        public override string ToString()
        {
            return string.Format($"GSM\nManufacturer: {this.Manufacturer}. Model: {this.Model} \nPrice: {this.Price}. Owner: {this.Owner}\n{this.Battery}\n{this.Display}");
        }

    }
}
