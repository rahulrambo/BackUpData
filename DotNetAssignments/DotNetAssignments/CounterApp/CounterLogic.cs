using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAssignments.CounterApp
{
    internal class CounterLogic
    {
        public string BankName { get; set; }
        public string BankLocation { get; set; }
        public static int Counter = 0;
        public CounterLogic(string bankName, string bankLocation)
        {
            this.BankName = bankName;
            this.BankLocation = bankLocation;
            Counter++;
        }
    }
}
