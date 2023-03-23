using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAssignments.SearchingTechniques
{
    public class SearchingTechnique
    {
        int[] arr;
        int element;
        public SearchingTechnique()
        {
        option:
            Console.Write("Enter the Number of elements you want to store:");
            if (!int.TryParse(Console.ReadLine(), out int elements))
            {
                Console.WriteLine("Please enter the valid data");
                goto option;
            }
            arr = new int[elements];
            for (int i = 0; i < elements; i++)
            {
                Console.Write("Enter {0} element:", i + 1);
                while (!int.TryParse(Console.ReadLine(), out arr[i]))
                {
                    Console.WriteLine("Please enter the valid data");
                }
            }
        menu:
            Console.Write("Enter the element which you want to search:");
            if (!int.TryParse(Console.ReadLine(), out element))
            {
                Console.WriteLine("Please enter the valid input");
                goto menu;
            }
        }
        public int LinearSearch()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == element)
                {
                    return i;
                }
            }
            return -1;
        }
        public int BinarySearch()
        {
            int[] newArr = new int[arr.Length];
            for (int j = 0; j < newArr.Length; j++)
            {
                newArr[j] = arr[j];
            }
            Array.Sort(newArr);
            int l = 0, r = newArr.Length - 1;
            while (l <= r)
            {
                int m = (l + r) / 2;
                if (newArr[m] == element)
                    return m;
                if (newArr[m] < element)
                    l = m + 1;
                else if (newArr[m] > element)
                    r = m - 1;
            }
            return -1;
        }
    }
}
