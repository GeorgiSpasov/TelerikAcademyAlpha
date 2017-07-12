using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10701.Defining_Classes_Part_1
{
    public class GSM
    {
        private string manufacturer;
        private string model;
        private int price;
        private string owner;
        private Battery battery;
        private Display display;
        private List<Call> callHistory;

        public static GSM IPhone4S = new GSM("Apple", "IPhone4S", 1000, "Tosho", new Battery("Apple", BatteryType.LiIon, 48, 30), new Display(5, 5000000));

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid manufacturer name entered");
                }
                this.manufacturer = value;
            }
        }
        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid model name entered");
                }
                this.model = value;
            }
        }
        public int Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid price entered");
                }
                this.price = value;
            }
        }
        public string Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid owner entered");
                }
                this.owner = value;
            }
        }
        public Battery Battery
        {
            get
            {
                return this.battery;
            }
            set
            {
                this.battery = value;
            }
        }
        public Display Display
        {
            get
            {
                return this.display;
            }
            set
            {
                this.display = value;
            }
        }
        public List<Call> CallHistory
        {
            get
            {
                return this.callHistory;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Call history not entered");
                }
            }
        }

        public GSM(string manufacturer, string model, int price = 0, string owner = null, Battery battery = null, Display display = null, List<Call> callHistory = null)
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
