using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public class Application
    {
        public static void Start(string[] args)
        {
        option1:
            Console.Write("Enter first Number:");
            if (!float.TryParse(Console.ReadLine(), out var number1))
            {
                Console.WriteLine("Please enter a valid number\n");
                goto option1;
            }
        option2:
            Console.Write("Enter second Number:");
            if (!float.TryParse(Console.ReadLine(), out var number2))
            {
                Console.WriteLine("Please enter a valid number\n");
                goto option2;
            }
        menu:
            Console.WriteLine("\nSelect your choice:");
            Console.WriteLine("Enter '1' for Addition");
            Console.WriteLine("Enter '2' for Subtraction");
            Console.WriteLine("Enter '3' for Multiplication");
            Console.WriteLine("Enter '4' for Division");
            Console.WriteLine("Enter '5' for PowerOf");
            Console.WriteLine("Enter '10' for stopping the program");
            if (!float.TryParse(Console.ReadLine(), out float inputValue))
            {
                Console.WriteLine("Please enter a valid input");
                goto menu;
            }
            bool input = true;
            var factory = new Factory();
            while (input)
            {
                switch (inputValue)
                {
                    case 1:
                        var addition = factory.AdditionOperation;
                        Console.WriteLine($"The sum of {number1} and {number2} is:{addition.Calculate(number1, number2)}");
                        goto menu;
                    case 2:
                        var subtraction = factory.SubtractionOperation;
                        Console.WriteLine($"The difference between {number1} and {number2} is:{subtraction.Calculate(number1, number2)}");
                        goto menu;
                    case 3:
                        var multiplication = factory.MultiplicationOperation;
                        Console.WriteLine($"The multiplication of {number1} and {number2} is:{multiplication.Calculate(number1, number2)}");
                        goto menu;
                    case 4:
                        try
                        {
                            var division = factory.DivisionOperation;
                            Console.WriteLine($"The result after dividing {number1} by {number2} is:{division.Calculate(number1, number2)}");
                        }
                        catch (DivideByZeroException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        goto menu;
                    case 5:
                        var powerOf = factory.PowerOfOperation;
                        Console.WriteLine($"{number1} to the power {number2} is:{powerOf.Calculate(number1, number2)}");
                        goto menu;
                    case 10:
                        input = false;
                        break;
                    default:
                        Console.WriteLine("Enter a valid option");
                        goto menu;

                }
            }
        }
    }
}
