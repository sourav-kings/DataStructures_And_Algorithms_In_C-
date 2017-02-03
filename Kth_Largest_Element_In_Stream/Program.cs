using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kth_Largest_Elements_In_Stream
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 16, 17, 18, 4, 12, 9, 5, 1 };
            int size = a.Length;
            int k = 3;
            Console.WriteLine(kthLargest(a, size, k));
            kLargest2(a, k);
            Console.WriteLine("** With Max Heap **");
            kLargestMaxHeap(a, k);
        }

        static int kthLargest(int[] a, int size, int k)
        {
            int[] minHeap = new int[k];
            int i;
            for (i = 0; i < k; i++)
                minHeap[i] = a[i];
            buildMinHeap(minHeap, k);
            for (i = k; i < size; i++)
            {
                if (a[i] > minHeap[0])
                {
                    minHeap[0] = a[i];
                    minHeapify(minHeap, k, 0);
                }
            }
            return minHeap[0];
        }

        static void minHeapify(int[] a, int size, int i)
        {
            int l = 2 * i;
            int r = 2 * i + 1;
            int smallest = i;
            if (l < size && a[l] < a[smallest])
                smallest = l;
            if (r < size && a[r] < a[smallest])
                smallest = r;
            if (smallest != i)
            {
                swap(a[i], a[smallest]);
                minHeapify(a, size, smallest);
            }

        }

        static void swap(int x, int y)
        {
            int z = x;
            x = y;
            y = z;
        }

        static void buildMinHeap(int[] a, int size)
        {
            for (int i = size / 2; i >= 0; i--)
                minHeapify(a, size, i);
        }





        static void kLargest2(int[] array, int k)
        {

            int minIndex = 0, i;                            //Find Min

            for (i = k; i < array.Length; i++)
            {
                minIndex = 0;
                for (int j = 0; j < k; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                        array[minIndex] = array[j];
                    }
                }
                if (array[minIndex] < array[i])
                {         //Swap item if min < array[i]

                    int temp = array[minIndex];
                    array[minIndex] = array[i];
                    array[i] = temp;
                }
            }
            for (int q = 0; q < k; q++)
            {                            //Print output
                Console.Write(array[q] + " ");
            }
        }





        /**
 * A function to fix a heap located in an array at a particular position
 * Returns a next position to fix the heap at, or -1.
 */
        static int fixHeap(int[] array, int position, int heapSize)
        {
            int child = position * 2 + 1;
            if (child >= heapSize)
            {
                return -1;
            }
            // Notice the different comparator, this is now a max heap
            if (child + 1 < heapSize && array[child] < array[child + 1])
            {
                child++;
            }
            if (array[child] > array[position])
            {
                // swap the two values
                int temp = array[child];
                array[child] = array[position];
                array[position] = temp;
                return child;
            }
            return -1;
        }
        static void kLargestMaxHeap(int[] array, int k)
        {
            // Build a heap
            for (int i = array.Length - 1; i >= 0; i--)
            {
                int index = fixHeap(array, i, array.Length);
                while (index != -1)
                {
                    index = fixHeap(array, index, array.Length);
                }
            }
            for (int i = 0; i < k; i++)
            {
                // print the maximum
                Console.Write(array[0] + " ");
                // replace it
                array[0] = array[array.Length - 1 - i];
                // fix the heap
                int position = 0;
                while (position != -1)
                {
                    position = fixHeap(array, position, array.Length - 1 - i);
                }
            }
        }
    }
}
//http://codereview.stackexchange.com/questions/98010/finding-k-largest-or-smallest-elements-in-an-array
    
//http://www.crazyforcode.com/kth-largest-smallest-element-array/
//http://www.geeksforgeeks.org/k-largestor-smallest-elements-in-an-array/
