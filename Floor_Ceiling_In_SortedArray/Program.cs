using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floor_Ceiling_In_SortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 8, 10, 10, 12, 19 };
            int n = arr.Length;
            int x = 3;
            int index = ceilSearch_Faster(arr, 0, n - 1, x);
            if (index == -1)
                Console.WriteLine("Ceiling of "+ x + " doesn't exist in array ");
            else
                Console.WriteLine("Ceiling of "+ x +" is "+ arr[index]);

            int[] arr2 = { 1, 2, 4, 6, 10, 12, 14 };
            int n2 = arr2.Length;
            int x2 = 7;
            int index2 = floorSearch_Faster2(arr2, 0, n2 - 1, x2);
            if (index2 == -1)
                Console.WriteLine("Floor of " + x2 + " doesn't exist in array ");
            else
                Console.WriteLine("Floor of " + x2 + " is " + arr2[index2]);
            
        }

        /* Function to get index of ceiling of x in arr[low..high] */
        static int ceilSearch(int[] arr, int low, int high, int x)
        {
            int i;

            /* If x is smaller than or equal to first element,
              then return the first element */
            if (x <= arr[low])
                return low;

            /* Otherwise, linearly search for ceil value */
            for (i = low; i < high; i++)
            {
                if (arr[i] == x)
                    return i;

                /* if x lies between arr[i] and arr[i+1] including
                   arr[i+1], then return arr[i+1] */
                if (arr[i] < x && arr[i + 1] >= x)
                    return i + 1;
            }

            /* If we reach here then x is greater than the last element 
              of the array,  return -1 in this case */
            return -1;
        }

        static int ceilSearch_Faster(int[] arr, int low, int high, int x)
        {
            int mid;

            /* If x is smaller than or equal to the first element,
              then return the first element */
            if (x <= arr[low])
                return low;

            /* If x is greater than the last element, then return -1 */
            if (x > arr[high])
                return -1;

            /* get the index of middle element of arr[low..high]*/
            mid = (low + high) / 2;  /* low + (high - low)/2 */

            /* If x is same as middle element, then return mid */
            if (arr[mid] == x)
                return mid;

            /* If x is greater than arr[mid], then either arr[mid + 1]
              is ceiling of x or ceiling lies in arr[mid+1...high] */
            else if (arr[mid] < x)
            {
                //if (mid + 1 <= high && x <= arr[mid + 1])
                //    return mid + 1;
                //else
                    return ceilSearch_Faster(arr, mid + 1, high, x);
            }

            /* If x is smaller than arr[mid], then either arr[mid] 
               is ceiling of x or ceiling lies in arr[mid-1...high] */
            else
            {
                //if (mid - 1 >= low && x > arr[mid - 1])
                //    return mid;
                //else
                    return ceilSearch_Faster(arr, low, mid - 1, x);
            }
        }

        static int floorSearch_Faster2(int[] arr, int low, int high, int x)
        {
            // Base cases
            if (arr[high] <= x) // x is greater than all
                return high;
            if (arr[low] > x)  // x is smaller than all
                return low;

            // Find the middle point
            int mid = (low + high) / 2;  /* low + (high - low)/2 */

            /* If x is same as middle element, then return mid */
            if (arr[mid] <= x && arr[mid + 1] > x)            //if (arr[mid] == x)
                return mid;

            /* If x is greater than arr[mid], then either arr[mid + 1]
              is ceiling of x or ceiling lies in arr[mid+1...high] */
            if (arr[mid] < x)
                return floorSearch_Faster2(arr, mid + 1, high, x);

            return floorSearch_Faster2(arr, low, mid - 1, x);
        }



        /* An inefficient function to get index of floor
                of x in arr[0..n-1] */
        static int floorSearch(int[] arr, int low, int high, int x)
        {
            // If last element is smaller than x
            if (x >= arr[high])
                return high;

            // If first element is greater than x
            if (x < arr[low])
                return -1;

            // Linearly search for the first element
            // greater than x
            for (int i = 1; i < high+1; i++)
                if (arr[i] > x)
                    return (i - 1);

            return -1;
        }

        static int floorSearch_Faster(int[] arr, int low, int high, int x)
        {
            // If low and high cross each other
            if (low > high)
                return -1;

            // If last element is smaller than x
            if (x >= arr[high])
                return high;

            // Find the middle point
            int mid = (low + high) / 2;

            // If middle point is floor.
            if (arr[mid] == x)
                return mid;

            // If x lies between mid-1 and mid
            if (mid > 0 && arr[mid - 1] <= x && x < arr[mid])
                return mid - 1;

            // If x is smaller than mid, floor must be in
            // left half.
            if (x < arr[mid])
                return floorSearch_Faster(arr, low, mid - 1, x);

            // If mid-1 is not floor and x is greater than
            // arr[mid],
            return floorSearch_Faster(arr, mid + 1, high, x);
        }
    }
}

//http://www.geeksforgeeks.org/search-floor-and-ceil-in-a-sorted-array/

//http://www.geeksforgeeks.org/floor-in-a-sorted-array/

//Average Difficulty : 2.4/5.0
//Based on 55 vote(s)

/*

Given a sorted array and a value x, 
the ceiling of x is the smallest element in array greater than or equal to x, and 
the floor is the greatest element smaller than or equal to x.


For example, let the input array be {1, 2, 8, 10, 10, 12, 19}
For x = 0:    floor doesn't exist in array,  ceil  = 1
For x = 1:    floor  = 1,  ceil  = 1
For x = 5:    floor  = 2,  ceil  = 8
For x = 20:   floor  = 19,  ceil doesn't exist in array


 */
