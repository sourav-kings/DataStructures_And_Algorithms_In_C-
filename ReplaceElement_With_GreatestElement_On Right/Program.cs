using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplaceElement_With_GreatestElement_On_Right
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 16, 17, 4, 3, 5, 2 };
            nextGreatest(arr);
            Console.WriteLine("The modified array:");
            printArray(arr);
        }

        /* Function to replace every element with the
        next greatest element */
        static void nextGreatest(int[] arr)
        {
            int size = arr.Length;

            // Initialize the next greatest element
            int max_from_right = arr[size - 1];

            // The next greatest element for the rightmost
            // element is always -1
            arr[size - 1] = -1;

            // Replace all other elements with the next greatest
            for (int i = size - 2; i >= 0; i--)
            {
                // Store the current element (needed later for
                // updating the next greatest element)
                int temp = arr[i];

                // Replace current element with the next greatest
                arr[i] = max_from_right;

                // Update the greatest element, if needed
                if (max_from_right < temp)
                    max_from_right = temp;
            }
        }

        /* A utility Function that prints an array */
        static void printArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
        }
    }
}

//http://www.geeksforgeeks.org/replace-every-element-with-the-greatest-on-right-side/