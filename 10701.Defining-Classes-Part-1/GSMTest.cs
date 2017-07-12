using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _10701.Defining_Classes_Part_1
{
    class GSMTest
    {
        static void Main(string[] args)
        {
            GSM[] gsmArray =
            {
                new GSM("Samsung","Galaxy S8",1490,"Baj Ivan",new Battery("Samsung", BatteryType.LiIon,200,20),new Display(5.8,16000000),new List<Call>()),
                new GSM("Nokia","3310",139,"Stamat", new Battery("Nokia", BatteryType.LiIon,744,22),new Display(2.4, 65000),new List<Call>()),
                new GSM("OnePlus","5",1199,"Max",new Battery("OnePlus",BatteryType.LiPo,230,20),new Display(5.5,16000000),new List<Call>())
            };

            gsmArray[1].CallHistory.Add(new Call(new DateTime(2017, 5, 10), new TimeSpan(12, 30, 22), "123-456-7899", 120));
            gsmArray[1].CallHistory.Add(new Call(new DateTime(2017, 6, 12), new TimeSpan(22, 30, 10), "1-333-4567", 90));
            gsmArray[1].CallHistory.Add(new Call(new DateTime(2017, 7, 5), new TimeSpan(10, 15, 00), "111-1000", 320));

            Console.WriteLine(GSM.IPhone4S);
            gsmArray.ToList().ForEach(Console.WriteLine);
            gsmArray[1].CallHistory.ForEach(Console.Write);
            Console.WriteLine($"Total call price: {gsmArray[1].GetTotalCallPrice().ToString("C", CultureInfo.CurrentCulture)}");
            gsmArray[1].CallHistory.Remove(gsmArray[1].CallHistory.OrderBy(call => call.CallDuration).Last());
            Console.WriteLine($"Total call price: {gsmArray[1].GetTotalCallPrice().ToString("C", CultureInfo.CurrentCulture)}");
            gsmArray[1].CallHistory.Clear();
            gsmArray[1].CallHistory.ForEach(Console.Write);
        }
    }
}
