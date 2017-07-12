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
        private int price;
        private string owner;
        private Battery battery;
        private Display display;
        private List<Call> callHistory;

        public GSM(string manufacturer, string model, int price = 0, string owner = null, Battery battery = null, Display display = null, List<Call> callHistory = null)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Price = price;
            this.Owner = owner;
            this.Battery = battery;
            this.Display = display;
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

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(string.Format($"{this.Manufacturer} {this.Model} \nPrice: {this.Price.ToString("C", new CultureInfo("en-US"))}. Owner: {this.Owner}\n{this.Battery}\n{this.Display}\n"));

            if (this.CallHistory != null && this.CallHistory.Count != 0)
            {
                result.Append("Call History:\n");
                foreach (Call call in this.CallHistory)
                {
                    result.Append(call);
                }
            }
            return result.ToString();
        }

        public void AddCall(Call call)
        {
            this.CallHistory.Add(call);
        }
        public void RemoveCall(int index)
        {
            this.CallHistory.RemoveAt(index);
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
    }
}
