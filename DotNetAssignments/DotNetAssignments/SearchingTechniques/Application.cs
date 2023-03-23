using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAssignments.SearchingTechniques
{
    public class Application
    {
        public static void Start(string[] args)
        {
            SearchingTechnique searchingTechnique = new SearchingTechnique();
            Console.WriteLine();
        menu:
            Console.WriteLine("Select your choice:");
            Console.WriteLine("Enter '1' for searching elements using Linear Search");
            Console.WriteLine("Enter '2' for searching elements using Binar Search");
            Console.WriteLine("Enter '10' for stopping the program");
            if (!int.TryParse(Console.ReadLine(), out int inputValue))
            {
                Console.WriteLine("Please enter a valid input");
                goto menu;
            }
            bool input = true;
            while (input)
            {
                switch (inputValue)
                {
                    case 1:
                        var result = searchingTechnique.LinearSearch();
                        if (result == -1)
                        {
                            Console.WriteLine("Element is not present in array");
                        }
                        else
                        {
                            Console.WriteLine("Element is present at index " + result);
                        }
                        goto menu;
                    case 2:
                        var results = searchingTechnique.BinarySearch();
                        if (results == -1)
                        {
                            Console.WriteLine("Element is not present in array");
                        }
                        else
                        {
                            Console.WriteLine("Element is present at index " + results);
                        }
                        goto menu;
                    case 10:
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
