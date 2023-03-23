using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAssignments.SortingArray
{
    public class Application
    {
        public static void Start(string[] args)
        {
            SortingArray sortingArray = new SortingArray();
        menu:
            Console.WriteLine("Select your choice:");
            Console.WriteLine("Enter 'Asc' for sorting Array in Ascending form");
            Console.WriteLine("Enter 'Desc' for sorting Array in Descending form");
            Console.WriteLine("Enter 'Stop' for stopping the program");
            string inputvalue = Console.ReadLine().ToUpper();
            bool input = true;
            while (input)
            {
                switch (inputvalue)
                {
                    case "ASC":
                        sortingArray.AscendingArray();
                        goto menu;
                    case "DESC":
                        sortingArray.DescendingArray();
                        goto menu;
                    case "STOP":
                        input = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid input\n");
                        goto menu;
                }
            }
        }
    }
}
