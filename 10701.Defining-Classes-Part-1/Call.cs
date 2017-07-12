using System;
using System.Text.RegularExpressions;

namespace _10701.Defining_Classes_Part_1
{
    public class Call
    {
        private DateTime date;
        private TimeSpan time;
        private string dialedNumber;
        private int callDuration;
        //private static Regex phoneRegex = new Regex(@"[0-9-]+");

        public DateTime Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
            }
        }
        public TimeSpan Time
        {
            get
            {
                return this.time;
            }
            set
            {
                this.time = value;
            }
        }
        public string DialedNumber
        {
            get
            {
                return this.dialedNumber;
            }
            set
            {
                //if (!phoneRegex.IsMatch(value))
                //{
                //    throw new ArgumentException("Invalid phone number entered");
                //}
                this.dialedNumber = value;
            }
        }
        public int CallDuration
        {
            get
            {
                return this.callDuration;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid duration entered");
                }
                this.callDuration = value;
            }
        }

        public Call(DateTime date, TimeSpan time, string dialedNumber, int callDuration)
        {
            this.Date = date;
            this.Time = time;
            this.DialedNumber = dialedNumber;
            this.CallDuration = callDuration;
        }

        public override string ToString()
        {
            return string.Format($"Call history/nDate: {this.Date}. Time: {this.Time}/nDialed number: {this.DialedNumber}/nCall duration: {this.CallDuration}");
        }
    }
}
