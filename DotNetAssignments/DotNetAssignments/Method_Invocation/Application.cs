using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAssignments.Method_Invocation
{
    internal class Application
    {
        public static void Start(string[] args)
        {
            // Method Invocation by Variable Literal and expression using call by value
            int n = 5;
            var programLogic=new ProgramLogic();
            Console.WriteLine("========Method call by passing value======");
            Console.WriteLine($"Before Method calling the value of n is {n}", n);
            programLogic.Cube(n);
            programLogic.Cube(4);
            programLogic.Cube(n+6);
            Console.WriteLine($"After Method calling the value of n is {n}", n);

            Console.WriteLine("======Method call by passing reference=====");
            int m = 10;
            Console.WriteLine($"Before Method calling the value of m is {m}", m);
            programLogic.Square(ref m);
            Console.WriteLine($"After Method calling the value of m is {m}", m);

            // Positional Arguments
            programLogic.EmployeeData("Samvid", "Q3623");

            // Named and Optional Arguments
            programLogic.FullName("Samvid", "Mokirala");            
        }
    }
}
