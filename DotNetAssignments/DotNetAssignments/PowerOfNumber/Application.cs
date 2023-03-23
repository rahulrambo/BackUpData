using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAssignments.PowerOfNumber
{
    public class Application
    {
        public static void Start(string[] args)
        {
            var powerOfNumber=new PowerOfNumber();
            menu:
            Console.Write("Enter your base number:");
            if(!float.TryParse(Console.ReadLine(),out float input))
            {
                Console.WriteLine("Please enter a valid number");
                goto menu;
            }
            option:
            Console.Write("Enter your exponent number:");
            if(!int.TryParse(Console.ReadLine(),out int exp))
            {
                Console.WriteLine("Please enter a valid number");
                goto option;
            }
            Console.Write($"{input} to the power {exp} is:");
            Console.WriteLine(powerOfNumber.PowerOfNum(input,exp));
        }
    }
}
