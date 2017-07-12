using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10701.Defining_Classes_Part_1
{
    class GSMTest
    {
        static void Main(string[] args)
        {
            GSM g1 = new GSM("Samsung", "Alpha", 350, "Pesho", new Battery("Samsung", BatteryType.LiIon, 56, 20), new Display(5, 5000000),new List<Call>());
            //g1.CallHistory.Add(new Call(new DateTime(2017, 6, 12), new TimeSpan(12, 30, 22), "123-456-7899", 120));
            Console.WriteLine(g1.ToString());
            Console.WriteLine(GSM.IPhone4S);
        }
    }
}
