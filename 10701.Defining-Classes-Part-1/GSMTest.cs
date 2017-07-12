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
            GSM g1 = new GSM("Samsung", "Alpha", 350, "Pesho", new Battery("Samsung", BatteryType.LiIon, 56, 20), new Display(5, 5000000));
            Console.WriteLine(g1.ToString());
        }
    }
}
