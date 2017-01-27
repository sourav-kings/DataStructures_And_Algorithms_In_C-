using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximize_Number_0s_Flipping_Subarray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 0, 1, 0, 0, 1, 1, 0 };
            int n = arr.Length;
            Console.WriteLine(findMaxZeroCount(arr, n));
            Console.WriteLine(findMaxZeroCountFaster(arr, n));
        }


        // A Kadane's algorithm based solution to find maximum
        // number of 0s by flipping a subarray.
        static int findMaxZeroCountFaster(int[] arr, int n)
        {
            // Initialize count of zeros and maximum difference
            // between count of 1s and 0s in a subarray
            int orig_zero_count = 0;

            // Initiale overall max diff for any subarray
            int max_diff = 0;

            // Initialize current diff
            int curr_max = 0;

            for (int i = 0; i < n; i++)
            {
                // Count of zeros in original array (Not related
                // to Kadane's algorithm)
                if (arr[i] == 0)
                    orig_zero_count++;

                // Value to be considered for finding maximum sum
                int val = (arr[i] == 1) ? 1 : -1;

                // Update current max and max_diff
                curr_max = Math.Max(val, curr_max + val);
                max_diff = Math.Max(max_diff, curr_max);
            }
            max_diff = Math.Max(0, max_diff);

            return orig_zero_count + max_diff;
        }


        // A Kadane's algorithm based solution to find maximum
        // number of 0s by flipping a subarray.
        static int findMaxZeroCount(int[] arr, int n)
        {
            // Initialize max_diff = maximum of (Count of 0s -
            // count of 1s) for all subarrays.
            int max_diff = 0;

            // Initialize count of 0s in original array
            int orig_zero_count = 0;

            // Consider all Subarrays by using two nested two
            // loops
            for (int i = 0; i < n; i++)
            {
                // Increment count of zeros
                if (arr[i] == 0)
                    orig_zero_count++;

                // Initialize counts of 0s and 1s
                int count1 = 0, count0 = 0;

                // Consider all subarrays starting from arr[i]
                // and find the difference between 1s and 0s.
                // Update max_diff if required
                for (int j = i; j < n; j++)
                {
                    if (arr[j] == 1)
                        count1++;
                    else
                        count0++;
                    max_diff = Math.Max(max_diff, count1 - count0);
                }
            }

            // Final result would be count of 0s in original
            // array plus max_diff.
            return orig_zero_count + max_diff;
        }
    }
}
