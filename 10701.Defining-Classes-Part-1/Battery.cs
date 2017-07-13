using System;
using System.Text;

namespace _10701.Defining_Classes_Part_1
{
    public class Battery
    {
        private string model;
        private BatteryType type;
        private int hoursIdle;
        private int hoursTalk;

        public Battery(string model)
        {
            this.Model = model;
        }
        public Battery(string model, BatteryType type) : this(model)
        {
            this.Type = type;
        }
        public Battery(string model, BatteryType type, int hoursIdle, int hoursTalk) : this(model, type)
        {
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
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
                    throw new ArgumentException("Invalid battery model entered!");
                }
                this.model = value;
            }
        }
        public BatteryType Type
        {
            get
            {
                return this.type;
            }
            set
            {

                this.type = value;
            }
        }
        public int HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid hours idle value entered!");
                }
                this.hoursIdle = value;
            }
        }
        public int HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid hours talk value entered!");
                }
                this.hoursTalk = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder($"Battery: {this.Model}, {this.Type}");
            if (this.HoursIdle != 0 && this.HoursTalk != 0)
            {
                result.Append($"\nHours Idle: { this.HoursIdle}. Hours Talk: { this.HoursTalk}");
            }
            return result.ToString();
        }
    }
}
