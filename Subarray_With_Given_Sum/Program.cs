using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subarray_With_Given_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 4, 20, 3, 10, 5 };
            int sum = 33;
            subArraySum(arr, arr.Length, sum);
            Console.WriteLine();

            int[] arr2 = { 10, 2, -2, -20, 10 };
            int sum2 = -10;
            subArraySumForNonNegetive(arr2, arr2.Length, sum2);
            Console.WriteLine();

            int[] arr3 = { -10, 0, 2, -2, -20, 10};
            int sum3 = 20;
            subArraySumForNonNegetive(arr3, arr3.Length, sum3);
            Console.WriteLine();
        }

        // Function to print subarray with sum as given sum
        static void subArraySumForNonNegetive(int[] arr, int n, int sum)
        {
            // create an empty map
            Dictionary<int, int> map = new Dictionary<int, int>();

            // Maintains sum of elements so far
            int curr_sum = 0;

            for (int i = 0; i < n; i++)
            {
                // add current element to curr_sum
                curr_sum = curr_sum + arr[i];

                // if curr_sum is equal to target sum
                // we found a subarray starting from index 0
                // and ending at index i
                if (curr_sum == sum)
                {
                    Console.Write("Sum found between indexes 0 to " + i);
                    return;
                }

                // If curr_sum - sum already exists in map
                // we have found a subarray with target sum
                if (map.ContainsKey(curr_sum - sum))
                {
                    Console.Write("Sum found between indexes " + map[curr_sum - sum] + 1 + " to " + i);
                    return;
                }

                map[curr_sum] = i;
            }

            // If we reach here, then no subarray exists
            Console.Write("No subarray with given sum exists");
        }

        /* Returns true if the there is a subarray of arr[] with sum equal to
   'sum' otherwise returns false.  Also, prints the result */
        static int subArraySum(int[] arr, int n, int sum)
        {
            int curr_sum = arr[0], start = 0, i;

            // Pick a starting point
            for (i = 1; i <= n; i++)
            {
                // If curr_sum exceeds the sum, then remove the starting elements
                while (curr_sum > sum && start < i - 1)
                {
                    curr_sum = curr_sum - arr[start];
                    start++;
                }

                // If curr_sum becomes equal to sum, then return true
                if (curr_sum == sum)
                {
                    int p = i - 1;
                    Console.WriteLine("Sum found between indexes " + start
                            + " and " + p);
                    return 1;
                }

                // Add this element to curr_sum
                if (i < n)
                    curr_sum = curr_sum + arr[i];

            }

            Console.WriteLine("No subarray found");
            return 0;
        }
    }
}

//http://www.geeksforgeeks.org/find-subarray-with-given-sum-in-array-of-integers/
http://www.geeksforgeeks.org/find-subarray-with-given-sum/