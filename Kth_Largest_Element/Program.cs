using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kth_Largest_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ropes = { 4, 3, 2, 6, 13, 9 };

            printArray(ropes);
            maxHeap(ropes);
            Console.Write(getKthLargestelement(ropes, 5));
            printArray(ropes);
        }

        private static int getKthLargestelement(int[] arr, int k)
        {

            for (int j = 0, i = arr.Length - 1; i >= 0 && j < k; i--, j++)
            {
                swap(arr, i, 0);
                heapify(arr, i, 0);
            }
            return arr[arr.Length - k];
        }
        private static void maxHeap(int[] arr)
        {

            int n = arr.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                heapify(arr, n, i);
            }
        }
        private static void heapify(int[] arr, int n, int i)
        {

            int left = 2 * i + 1;
            int right = 2 * i + 2;
            int largest = i;

            if (left < n && arr[left] > arr[largest])
            {
                largest = left;
            }
            if (right < n && arr[right] > arr[largest])
            {
                largest = right;
            }
            if (largest != i)
            {
                swap(arr, largest, i);
                heapify(arr, n, largest);
            }
        }

        private static void swap(int[] arr, int largest, int i)
        {

            int temp = arr[i];
            arr[i] = arr[largest];
            arr[largest] = temp;
        }

        private static void printArray(int[] arr)
        {

            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
    }
}

//http://ideone.com/CjpDwZ

//http://www.geeksforgeeks.org/k-largestor-smallest-elements-in-an-array/