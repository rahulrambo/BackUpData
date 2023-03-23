using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAssignments.CounterApp
{
    internal class Application
    {
        public static void Start(string[] args)
        {
            Console.WriteLine("The total number of objects created is:");
            var counter1 = new CounterLogic("SBI", "Patna");
            var counter2 = new CounterLogic("HDFC", "Hyderabad");
            var counter3 = new CounterLogic("ICICI", "Delhi");
            var counter4 = new CounterLogic("BOI","Mumbai");           
            Console.WriteLine(CounterLogic.Counter);
        }
    }
}
