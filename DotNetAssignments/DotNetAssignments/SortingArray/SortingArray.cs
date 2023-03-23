using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAssignments.SortingArray
{
    public class SortingArray
    {
        int[] arr;
        public SortingArray()
        {
        menu:
            Console.Write("Enter the Number of elements you want to store:");
            if (!int.TryParse(Console.ReadLine(), out int elements))
            {
                Console.WriteLine("Please enter the valid data");
                goto menu;
            }
            arr = new int[elements];

            for (int i = 0; i < elements; i++)
            {
                Console.Write("Enter {0} element:", i+1);
                while (!int.TryParse(Console.ReadLine(), out arr[i]))
                {
                    Console.WriteLine("Please enter the valid data");
                }
            }
            Console.WriteLine("");
        }
        public void AscendingArray()
        {        
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            Console.Write("The Array in Ascending order is:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine("\n");
        }
        public void DescendingArray()
        {        
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] < arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            Console.Write("The Array in Descending order is:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine("\n");
        }
    }
}
