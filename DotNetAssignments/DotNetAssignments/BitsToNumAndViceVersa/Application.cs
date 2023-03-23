using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DotNetAssignments.BitsToNumAndViceVersa
{
    internal class Application
    {        
        public static void Start(string[] args)
        {
            Regex regex = new Regex(@"^[10]+$");
            var bitsToNumAndNumToBits = new ProgramLogic();
            menu:
            Console.WriteLine("Please select the below one to get the output as per the need");
            Console.WriteLine("Enter 1 for Converting Number to Bits");
            Console.WriteLine("Enter 2 for Converting Bits to Number");                                   
            Console.WriteLine("Enter 3 for Stopping the Program");               
            if (!int.TryParse(Console.ReadLine(), out int input))
            {
                Console.WriteLine("\nPlease enter a correct value");
                goto menu;
            }
            var run = true;
            while (run)
            {
                switch (input)
                {
                    case 1:
                        getValue:
                        Console.Write("Enter your input for getting bits value of the Number:");
                        if(!int.TryParse(Console.ReadLine(), out int number))
                        {
                            Console.WriteLine("Please enter a valid number");
                            goto getValue;
                        }                       
                        bitsToNumAndNumToBits.NumberToBits(number);
                        Console.WriteLine();
                        goto menu;                        
                    case 2:
                    getInput:
                        Console.Write("Enter your input for getting the value of bits in Number:");
                        if (!int.TryParse(Console.ReadLine(), out int inputs))
                        {
                            Console.WriteLine("Please enter the valid data");
                            goto getInput;
                        }
                        if (!regex.IsMatch(inputs.ToString()))
                        {
                            Console.WriteLine("Please enter a valid number");
                            goto getInput;
                        }
                        bitsToNumAndNumToBits.BitsToNumber(inputs);
                        Console.WriteLine();
                        goto menu;
                    case 3:
                        run = false;  
                        break;
                    default:
                        Console.WriteLine("\nPlease select the valid option");
                        goto menu;
                }

            }

        }
    }
}
