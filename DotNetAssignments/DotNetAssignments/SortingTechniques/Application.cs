using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAssignments.SortingTechniques
{
    public class Application
    {
        public static void Start(string[] args)
        {
            SortingTechnique sortingTechnique = new SortingTechnique();
        option:
            Console.Write("Enter the Number of elements you want to store:");
            if (!int.TryParse(Console.ReadLine(), out int elements))
            {
                Console.WriteLine("Please enter the valid data");
                goto option;
            }
            int[] arr = new int[elements];
            for (int i = 0; i < elements; i++)
            {
                Console.Write("Enter {0} element:", i + 1);
                while (!int.TryParse(Console.ReadLine(), out arr[i]))
                {
                    Console.WriteLine("Please enter the valid data");
                }
            }
        menu:
            Console.WriteLine();
            Console.WriteLine("Select your choice:");
            Console.WriteLine("Enter '1' for sorting the array using Bubble Sort");
            Console.WriteLine("Enter '2' for sorting the array using Insertion Sort");
            Console.WriteLine("Enter '3' for sorting the array using Selection Sort");
            Console.WriteLine("Enter '4' for sorting the array using Merge Sort");
            Console.WriteLine("Enter '5' for sorting the array using Quick Sort");
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
                        sortingTechnique.BubbleSort(arr);
                        goto menu;
                    case 2:
                        sortingTechnique.InsertionSort(arr);
                        goto menu;
                    case 3:
                        sortingTechnique.SelectionSort(arr);
                        goto menu;
                    case 4:
                        sortingTechnique.MergeSort(arr);
                        Console.Write("Sorted the Array using Merge Sort:");
                        sortingTechnique.Print(arr);
                        goto menu;
                    case 5:
                        sortingTechnique.QuickSort(arr);
                        Console.Write("Sorted the Array using Quick Sort");
                        sortingTechnique.Print(arr);
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
