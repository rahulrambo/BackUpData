using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAssignments.PropertiesAndFields
{
    public class Employee
    {
        public string Name;
        
        public DateTime DateOfBirth { get; set; }
        public string Department { get; set; }

        
        public void GetAge()
        { 
            DateTime currentDate = DateTime.Now;
            
            int ageYear = currentDate.Year - DateOfBirth.Year;
            int ageMonth = currentDate.Month - DateOfBirth.Month;
            int ageDay = currentDate.Day - DateOfBirth.Day;
            if (ageDay < 0)
            {
                ageMonth--;
                ageDay += 31;
               
            }
            if (ageMonth < 0)
            {
                ageYear--;
                ageMonth += 12;
            }            
            Console.WriteLine($"Your Date Of Birth is {DateOfBirth} and You are {ageYear}Yrs {ageMonth}Months {ageDay}Days old now");
        }

    }
}
