using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trapping_Rain_Water
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            int n = arr.Length;
            Console.WriteLine("Maximum water that can be accumulated is "
                 + findWater(arr, n));
        }

        static int findWater(int[] arr, int n)
        {
            // left[i] contains height of tallest bar to the
            // left of i'th bar including itself
            int[] left = new int[n];

            // Right [i] contains height of tallest bar to
            // the right of ith bar including itself
            int[] right = new int[n];

            // Initialize result
            int water = 0;

            // Fill left array
            left[0] = arr[0];
            for (int i = 1; i < n; i++)
                left[i] = Math.Max(left[i - 1], arr[i]);

            // Fill right array
            right[n - 1] = arr[n - 1];
            for (int i = n - 2; i >= 0; i--)
                right[i] = Math.Max(right[i + 1], arr[i]);

            // Calculate the accumulated water element by element
            // consider the amount of water on i'th bar, the
            // amount of water accumulated on this particular
            // bar will be equal to min(left[i], right[i]) - arr[i] .
            for (int i = 0; i < n; i++)
                water += Math.Min(left[i], right[i]) - arr[i];

            return water;
        }
    }
}
//http://www.geeksforgeeks.org/trapping-rain-water/

//Average Difficulty : 3.5/5.0
//Based on 98 vote(s)