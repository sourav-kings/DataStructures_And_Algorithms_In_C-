using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smallest_And_SecondSmallest_Element_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 12, 13, 1, 10, 34, 1 };
            print2Smallest(arr);
        }

        /* Function to print first smallest and second smallest
            elements */
        static void print2Smallest(int[] arr)
        {
            int first, second, arr_size = arr.Length;

            /* There should be atleast two elements */
            if (arr_size < 2)
            {
                Console.WriteLine(" Invalid Input ");
                return;
            }

            first = second = int.MaxValue;
            for (int i = 0; i < arr_size; i++)
            {
                /* If current element is smaller than first
                  then update both first and second */
                if (arr[i] < first)
                {
                    second = first;
                    first = arr[i];
                }

                /* If arr[i] is in between first and second
                   then update second  */
                else if (arr[i] < second && arr[i] != first)
                    second = arr[i];
            }
            if (second == int.MaxValue)
                Console.WriteLine("There is no second" +
                                   "smallest element");
        else
                Console.WriteLine("The smallest element is " +
                               first + " and second Smallest" +
                               " element is " + second);
        }
    }
}

//http://www.geeksforgeeks.org/to-find-smallest-and-second-smallest-element-in-an-array/