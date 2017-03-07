using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumNumber_Of_Platforms_Required_RailwayStation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 900, 940, 950, 1100, 1500, 1800 };
            int[] dep = { 910, 1200, 1120, 1130, 1900, 2000 };
            int n = arr.Length;
            Console.WriteLine("Minimum Number of Platforms Required = " + findPlatform(arr, dep, n));
        }


        // Returns minimum number of platforms reqquired
        static int findPlatform(int[] arr, int[] dep, int n)
        {
            // Sort arrival and departure arrays
            Array.Sort(arr);
            Array.Sort(dep);
            //Sort(arr, arr + n);
            //sort(dep, dep + n);

            // plat_needed indicates number of platforms needed at a time
            int plat_needed = 1, result = 1;
            int i = 1, j = 0;

            // Similar to merge in merge sort to process all events in sorted order
            while (i < n && j < n)
            {
                // If next event in sorted order is arrival, increment count of
                // platforms needed
                if (arr[i] < dep[j])
                {
                    plat_needed++;
                    i++;
                    if (plat_needed > result)  // Update result if needed
                        result = plat_needed;
                }
                else // Else decrement count of platforms needed
                {
                    plat_needed--;
                    j++;
                }
            }

            return result;
        }
    }
}

//http://www.geeksforgeeks.org/minimum-number-platforms-required-railwaybus-station/

//Average Difficulty : 3.3/5.0
//Based on 46 vote(s)
