using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuts_And_Bolts
{
    class Program
    {
        static void Main(string[] args)
        {
            // Nuts and bolts are represented as array of characters
            char[] nuts = { '@', '#', '$', '%', '^', '&' };
            char[] bolts = { '$', '%', '&', '^', '@', '#' };

            // Method based on quick sort which matches nuts and bolts
            matchPairs(nuts, bolts, 0, 5);

            Console.WriteLine("Matched nuts and bolts are : ");
            printArray(nuts);
            printArray(bolts);
        }

        // Method to print the array
        private static void printArray(char[] arr)
        {
            foreach (char ch in arr)
            {
                Console.Write(ch + " ");
            }
            Console.WriteLine("\n");
        }

        // Method which works just like quick sort
        private static void matchPairs(char[] nuts, char[] bolts, int low, int high)
        {
            if (low < high)
            {
                // Choose last character of bolts array for nuts partition.
                int pivot = partition(nuts, low, high, bolts[high]);

                // Now using the partition of nuts choose that for bolts
                // partition.
                partition(bolts, low, high, nuts[pivot]);

                // Recur for [low...pivot-1] & [pivot+1...high] for nuts and
                // bolts array.
                matchPairs(nuts, bolts, low, pivot - 1);
                matchPairs(nuts, bolts, pivot + 1, high);
            }
        }

        // Similar to standard partition method. Here we pass the pivot element
        // too instead of choosing it inside the method.
        private static int partition(char[] arr, int low, int high, char pivot)
        {
            int i = low-1;
            for (int j = low; j <= high-1; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    swap(arr, i, j);
                }
                else if (arr[j] == pivot)
                {
                    swap(arr, j, high);
                    j--;
                }
            }
            swap(arr, i+1, high);

            // Return the partition index of an array based on the pivot 
            // element of other array.
            return i+1;
        }


        static int partition2(char[] arr, int low, int high, char pi)
        {
            char pivot = pi;
            int i = (low - 1); // index of smaller element
            for (int j = low; j <= high - 1; j++)
            {
                // If current element is smaller than or
                // equal to pivot
                if (arr[j] <= pivot)
                {
                    i++;

                    // swap arr[i] and arr[j]
                    swap(arr, i, j);
                }
            }

            // swap arr[i+1] and arr[high] (or pivot)
            swap(arr, i+1, high);

            return i + 1;
        }

        static void swap(char[] arr, int i, int j)
        {
            char temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}


///http://www.geeksforgeeks.org/nuts-bolts-problem-lock-key-problem/
///Average Difficulty : 3.9/5.0
//Based on 37 vote(s)



/*
 * Given a set of n nuts of different sizes and n bolts of different sizes. 
 * There is a one-one mapping between nuts and bolts. Match nuts and bolts efficiently.
Constraint: Comparison of a nut to another nut or a bolt to another bolt is not allowed. 
It means nut can only be compared with bolt and bolt can only be compared with nut to see which one is bigger/smaller.

Other way of asking this problem is, given a box with locks and keys where one lock can be opened by one key in the box. 
We need to match the pair.
 */
