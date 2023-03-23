using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAssignments.ExtensionMethod
{
    internal class Application
    {
        public static void Start(string[] args)
        {
            int num1 = 20;
            int num2 = 5;

            //There are two ways of creating and calling the extension method and they are below
            int num3 = ExtensionLogic.Sub(num1, num2);

            //Like this also we can do the same thing as we did above
            int num4 = num1.Sub(num2);

            Console.WriteLine($"Using extension method after subtracting {num2} from {num1} the value is {num3}");
            Console.WriteLine($"Using extension method after subtracting {num2} from {num1} the value is {num4}");

            //The below one is the calling static method of static class
            int a = 20;
            int b = 30;
            Console.WriteLine($"The addition of {a} and {b} is {ExtensionLogic.Add(a, b)}");
        }
    }
}
