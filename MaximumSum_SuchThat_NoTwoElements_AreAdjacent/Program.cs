using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumSum_SuchThat_NoTwoElements_AreAdjacent
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 5, 5, 10, 100, 10, 5 };
            Console.WriteLine(FindMaxSum(arr, arr.Length));
        }

        /*Function to return max sum such that no two elements
        are adjacent */
        static int FindMaxSum(int[] arr, int n)
        {
            int incl = arr[0];
            int excl = 0;
            int excl_new;
            int i;

            for (i = 1; i < n; i++)
            {
                /* current max excluding i */
                excl_new = (incl > excl) ? incl : excl;

                /* current max including i */
                incl = excl + arr[i];
                excl = excl_new;
            }

            /* return max of incl and excl */
            return ((incl > excl) ? incl : excl);
        }
    }
}


//http://www.geeksforgeeks.org/maximum-sum-such-that-no-two-elements-are-adjacent/

//Average Difficulty : 3.3/5.0
//Based on 205 vote(s)

/*

 Given an array of positive numbers, find the maximum sum of a subsequence with the constraint 
 that no 2 numbers in the sequence should be adjacent in the array. So 3 2 7 10 should return 13 (sum of 3 and 10) 
 or 3 2 5 10 7 should return 15 (sum of 3, 5 and 7).Answer the question in most efficient way.

Examples :

Input : arr[] = {5, 5, 10, 100, 10, 5}
Output : 110

Input : arr[] = {1, 2, 3}
Output : 4

Input : arr[] = {1, 20, 3}
Output : 20

 */
