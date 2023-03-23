namespace DotNetAssignments.ArrayDetails
{
    public class Application
    {
        public static void Start(string[] args)
        {
            ArrayDetail arrayDetails = new ArrayDetail();
            Console.WriteLine();
        menu:
            Console.WriteLine("Select your choice:");
            Console.WriteLine("Enter '1' for getting minimum value from the Array");
            Console.WriteLine("Enter '2' for getting maximum value from the Array");
            Console.WriteLine("Enter '3' for getting unique value from the Array");
            Console.WriteLine("Enter '4' for getting sum of all element's value of the Array");
            Console.WriteLine("Enter '5' for getting odd elements in the Array");
            Console.WriteLine("Enter '6' for getting even elements in the Array");            
            Console.WriteLine("Enter '7' for getting unique values with count in the Array");
            Console.WriteLine("Enter '10' for stopping the program");            
            if(!int.TryParse(Console.ReadLine(), out int inputValue))
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
                        Console.WriteLine($"Minimun value in Array is:{arrayDetails.MinValueInArray}\n");
                        goto menu;
                    case 2:
                        Console.WriteLine($"Maximun value in Array is:{arrayDetails.MaxValueInArray}\n");
                        goto menu;
                    case 3:                        
                        Console.Write($"Unique values in Array are:");
                        foreach (var item in arrayDetails.UniqueValuesWithCount)
                        {
                            Console.Write(item.Key+" ");
                        }
                        Console.WriteLine("\n");
                        goto menu;
                    case 4:
                        Console.WriteLine($"Sum of all the Elements in Array is:{arrayDetails.SumOfValuesInArray}\n");
                        goto menu;
                    case 5:
                        Console.Write($"Odd elements in Array are:");
                        foreach (var item in arrayDetails.OddElement)
                        {
                            Console.Write(item+" ");
                        }
                        Console.WriteLine("\n");
                        goto menu;
                    case 6:
                        Console.Write($"Even elements in Array are:");
                        foreach (var item in arrayDetails.EvenElement)
                        {
                            Console.Write(item + " ");
                        }
                        Console.WriteLine("\n");
                        goto menu;
                    case 7:
                        Console.WriteLine($"Unique values with count in Array are:");
                        foreach (var item in arrayDetails.UniqueValuesWithCount)
                        {                            
                            Console.WriteLine($"{item.Key} is {item.Value} times");
                        }
                        Console.WriteLine();
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
