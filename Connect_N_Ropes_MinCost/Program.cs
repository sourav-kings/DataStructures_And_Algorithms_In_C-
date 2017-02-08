using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_N_Ropes_MinCost
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ropes = { 4, 3, 2, 6 };
            printArray(ropes);
            minHeap(ropes);
            Console.WriteLine("Connect n ropes with minimum cost of : " + getMinCost(ropes));
        }

        private static int getMinCost(int[] arr)
        {
            int totalMinCost = 0;
            int heapSize = arr.Length;
            //it will iterate until last element left in heap
            while (heapSize - 1 > 0)
            {

                int tempMinCost = arr[0];
                swap(arr, heapSize - 1, 0);

                for (int i = heapSize - 1 / 2 - 1; i >= 0; i--)
                {
                    heapify(arr, heapSize - 1, i);
                }

                arr[0] = tempMinCost + arr[0];
                totalMinCost = totalMinCost + arr[0];
                //n/2-1 its last non child node
                for (int i = heapSize - 1 / 2 - 1; i >= 0; i--)
                {
                    heapify(arr, heapSize - 1, i);
                }
                heapSize--;
            }
            return totalMinCost;
        }
        //build min heap
        private static void minHeap(int[] arr)
        {

            int n = arr.Length;
            //n/2-1 its last non child node
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                heapify(arr, n, i);
            }
        }
        //heapify min heap 
        private static void heapify(int[] arr, int n, int i)
        {

            int left = 2 * i + 1;
            int right = 2 * i + 2;
            int smalest = i;

            if (left < n && arr[left] < arr[smalest])
            {
                smalest = left;
            }
            if (right < n && arr[right] < arr[smalest])
            {
                smalest = right;
            }
            if (smalest != i)
            {
                swap(arr, smalest, i);
                heapify(arr, n, smalest);
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

//http://ideone.com/qFA0xX

//http://www.geeksforgeeks.org/connect-n-ropes-minimum-cost/