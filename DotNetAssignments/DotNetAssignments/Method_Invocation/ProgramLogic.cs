using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAssignments.Method_Invocation
{
    internal class ProgramLogic
    {
        public void Cube(int n)
        {
            n = n * n * n;
            Console.WriteLine($"Inside Method calling the value of n is {n}", n);
        }
        public void Square(ref int m)
        {
            m = m * m;
            Console.WriteLine($"Inside the method calling the value of m is {m}", m);
        }
        public void EmployeeData(string name, string employeeId)
        {
            Console.WriteLine($"User Id of {name} is {employeeId}", name, employeeId);
        }
        public void FullName(string firstName, string middleName, string lastName = "Kumar")
        {
            Console.WriteLine($"Full name is {firstName} {middleName} {lastName}");
        }
    }
}
