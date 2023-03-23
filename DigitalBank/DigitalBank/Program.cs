using DigitalBank.Core.Entities;
using DigitalBank.Services;
using DigitalBank.Repository;
using DigitalBank.Repository.Models;
using DigitalBank;

public class Program
{
    public static void Main(string[] args)
    {        
        ADOApplication aDOApplication = new ADOApplication();
        DapperApplication dapperApplication = new DapperApplication();
    option:
        Console.WriteLine("Enter 1 for seeing the output using ADO.Net");
        Console.WriteLine("Enter 2 for seeing the output using Dapper");
        Console.WriteLine("Enter 10 for stopping the program");
        bool input = true;
        int inputValue;
        while (!int.TryParse(Console.ReadLine(), out inputValue))
        {
            Console.WriteLine($"Enter a valid input");
        }
        while (input)
        {
            switch (inputValue)
            {
                case 1:
                    aDOApplication.Start(args);
                    goto option;
                case 2:
                    dapperApplication.Start(args);
                    goto option;
                case 10:
                    input = false;
                    break;
                default:
                    Console.WriteLine("Please enter the valid input");
                    goto option;
            }
        }
    }
}