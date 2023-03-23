using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAssignments.SortingTechniques
{
    public class SortingTechnique
    {
        int[] arr;
        public void BubbleSort(int[] arr)
        {
            int[] bubbleArray = new int[arr.Length];
            for (int j = 0; j < bubbleArray.Length; j++)
            {
                bubbleArray[j] = arr[j];
            }
            for (int i = 0; i < bubbleArray.Length; i++)
            {
                for (int j = 0; j < bubbleArray.Length - i - 1; j++)
                {
                    if (bubbleArray[j] > bubbleArray[j + 1])
                    {
                        int temp = bubbleArray[j];
                        bubbleArray[j] = bubbleArray[j + 1];
                        bubbleArray[j + 1] = temp;
                    }
                }
            }
            Console.Write("Sorted the Array using Bubble Sort:");
            for (int i = 0; i < bubbleArray.Length; i++)
            {
                Console.Write(bubbleArray[i] + " ");
            }
            Console.WriteLine("\n");
        }
        public void InsertionSort(int[] arr)
        {
            int newElement;
            for (int i = 1; i < arr.Length; i++)
            {
                newElement = arr[i];
                int j = i - 1;

                while (j >= 0 && newElement < arr[j])
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = newElement;
            }
            Console.Write("Sorted the Array using Insertion Sort:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine("\n");
        }
        public void SelectionSort(int[] arr)
        {
            int[] selectionArray = new int[arr.Length];
            for (int j = 0; j < selectionArray.Length; j++)
            {
                selectionArray[j] = arr[j];
            }
            int length = selectionArray.Length;
            for (int i = 0; i < length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < length; j++)
                {
                    if (selectionArray[j] < selectionArray[min])
                    {
                        min = j;
                    }
                }
                int temp = selectionArray[min];
                selectionArray[min] = selectionArray[i];
                selectionArray[i] = temp;
            }
            Console.Write("Sorted the Array using Selection Sort:");
            for (int i = 0; i < selectionArray.Length; i++)
            {
                Console.Write(selectionArray[i] + " ");
            }
            Console.WriteLine("\n");
        }
        public void MergeSort(int[] arr)
        {
            Sort(arr, 0, arr.Length - 1);
        }
        public void Sort(int[] arr, int l, int h)
        {
            if (l < h)
            {
                int mid = (l + h) / 2;
                Sort(arr, l, mid);
                Sort(arr, mid + 1, h);
                Merge(arr, l, h, mid);
            }
        }
        public void Merge(int[] arr, int l, int h, int mid)
        {
            int n1 = mid - l + 1;
            int n2 = h - mid;

            int[] tempArray1 = new int[n1];
            int[] tempArray2 = new int[n2];

            for (int n = 0; n < n1; n++)
            {
                tempArray1[n] = arr[l + n];
            }
            for (int n = 0; n < n2; n++)
            {
                tempArray2[n] = arr[mid + 1 + n];
            }
            int i = 0;
            int j = 0;
            int k = l;
            while (i < n1 && j < n2 && k < arr.Length)
            {
                if (tempArray1[i] < tempArray2[j])
                {
                    arr[k] = tempArray1[i];
                    i++;
                }
                else if (tempArray1[i] > tempArray2[j])
                {
                    arr[k] = tempArray2[j];
                    j++;
                }
                k++;
            }
            while (i < n1 && k < arr.Length)
            {
                arr[k] = tempArray1[i];
                k++;
                i++;
            }
            while (j < n2 && k < arr.Length)
            {
                arr[k] = tempArray2[j];
                k++;
                j++;
            }
        }
        public void QuickSort(int[] arr)
        {
            quickSort(arr, 0, arr.Length - 1);
        }
        private void quickSort(int[] arr, int l, int h)
        {
            if (l < h)
            {
                int partitionedPlace = quickSortPartition(arr, l, h);
                quickSort(arr, l, partitionedPlace - 1);
                quickSort(arr, partitionedPlace + 1, h);
            }
        }
        private int quickSortPartition(int[] arr, int l, int h)
        {
            int pivot = arr[h];
            int i = (l - 1);
            for (int j = l; j <= h - 1; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    swap(arr, i, j);
                }
            }
            swap(arr, i + 1, h);
            return (i + 1);
        }
        private static void swap(int[] arr, int index1, int index2)
        {
            int temp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = temp;
        }
        public void Print(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
