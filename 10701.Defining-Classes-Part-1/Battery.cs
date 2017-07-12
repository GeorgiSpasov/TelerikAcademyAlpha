using System;

namespace _10701.Defining_Classes_Part_1
{
    public class Battery
    {
        private string model;
        private BatteryType type;
        private int hoursIdle;
        private int hoursTalk;

        public Battery(string model, BatteryType type, int hoursIdle, int hoursTalk)
        {
            this.Model = model;
            this.Type = type;
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
                    throw new ArgumentException("Invalid model entered");
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
                    throw new ArgumentException("Invalid hours idle value entered");
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
                    throw new ArgumentException("Invalid hours talk value entered");
                }
                this.hoursTalk = value;
            }
        }

        public override string ToString()
        {
            return string.Format($"Battery\nModel: {this.Model}. Type: {this.Type}\nHours idle: {this.HoursIdle}. Hours talk: {this.HoursTalk}");
        }
    }
}
