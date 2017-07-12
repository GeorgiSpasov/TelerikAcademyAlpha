namespace _10701.Defining_Classes_Part_1
{
    public class Battery
    {
        public Battery(string model, BatteryType type, int hoursIdle, int hoursTalk)
        {
            this.Model = model;
            this.Type = type;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
        }

        public string Model { get; set; }
        public BatteryType Type { get; set; }
        public int HoursIdle { get; set; }
        public int HoursTalk { get; set; }

        public override string ToString()
        {
            return string.Format($"Battery\nModel: {this.Model}. Type: {this.Type}\nHours idle: {this.HoursIdle}. Hours talk: {this.HoursTalk}");
        }
    }
}
