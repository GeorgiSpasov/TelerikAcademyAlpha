using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace _10701.Defining_Classes_Part_1
{
    public class GSM
    {
        private const double CallPrice = 0.37;

        public static GSM IPhone4S = new GSM("Apple", "iPhone4S", 399, "Tosho", new Battery("Apple", BatteryType.LiPo, 200, 14), new Display(3.4, 16000000));

        private string manufacturer;
        private string model;
        private decimal price;
        private string owner;
        private Battery battery;
        private Display display;
        private List<Call> callHistory;


        public GSM(string manufacturer, string model)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
        }
        public GSM(string manufacturer, string model, int price, Battery battery, Display display) : this(manufacturer, model)
        {
            this.Price = price;
            this.Battery = battery;
            this.Display = display;
        }
        public GSM(string manufacturer, string model, int price, string owner, Battery battery, Display display) : this(manufacturer, model, price, battery, display)
        {
            this.Owner = owner;
        }
        public GSM(string manufacturer, string model, int price, string owner, Battery battery, Display display, List<Call> callHistory) : this(manufacturer, model, price, owner, battery, display)
        {
            this.CallHistory = callHistory;
        }

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
                    throw new ArgumentException("Invalid manufacturer name entered!");
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
                    throw new ArgumentException("Invalid model name entered!");
                }
                this.model = value;
            }
        }
        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid price entered!");
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
                    throw new ArgumentException("Invalid owner entered!");
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
                this.callHistory = value;
            }
        }

        public void AddCall(Call call)
        {
            this.CallHistory.Add(call);
        }
        public void RemoveCall(Call call)
        {
            this.CallHistory.Remove(call);
        }
        public void ClearCalls()
        {
            this.CallHistory.Clear();
        }
        public double GetTotalCallPrice()
        {
            int totalCallDuration = 0;
            foreach (Call call in this.CallHistory)
            {
                totalCallDuration += call.CallDuration;
            }
            return totalCallDuration / 60 * CallPrice;
        }
        public override string ToString()
        {
            string result = string.Format($"{this.Manufacturer} {this.Model}\nPrice: {this.Price.ToString("C", new CultureInfo("en-US"))}. Owner: {this.Owner}\n{this.Battery}\n{this.Display}\n{(this.CallHistory != null && this.CallHistory.Count > 0 ? "Call history:\n" + string.Join("", this.CallHistory) : "\n")}");

            return result;
        }
    }
}
