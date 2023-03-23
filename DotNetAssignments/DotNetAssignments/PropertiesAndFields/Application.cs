using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAssignments.PropertiesAndFields
{
    internal class Application
    {
       public static void Start(string[] args)
        {
            Employee employee1=new Employee();
            Employee employee2=new Employee();
            Employee employee3=new Employee();
            Employee employee4=new Employee();
            
            employee1.Name = "Rahul";
            Console.WriteLine($"Using Fields the Name is {employee1.Name}");

            Console.WriteLine("======For Non-Leap Year======");
            employee1.DateOfBirth = new DateTime(2001, 03, 12);
            employee1.GetAge();

            Console.WriteLine("======For Leap Year======");
            employee2.DateOfBirth = new DateTime(1992, 12, 25);
            employee2.GetAge();

            Console.WriteLine("====When Age-Month is Greater than present Age-Month====");
            employee3.DateOfBirth = new DateTime(1999, 12, 05);
            employee3.GetAge();

            Console.WriteLine("=====When Age-Day is Greater than present Age-Day=====");
            employee4.DateOfBirth = new DateTime(1998, 08, 25);
            employee4.GetAge();           

            employee1.Department ="Developer";
            Console.WriteLine($"Using Properties the department is {employee1.Department}");
            
        }
    }
}
