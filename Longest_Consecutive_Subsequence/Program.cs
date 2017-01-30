using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longest_Consecutive_Subsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 9, 3, 10, 4, 20, 2 };
            int n = arr.Length;
            Console.WriteLine("Length of the Longest consecutive subsequence is " +
                               findLongestConseqSubseq(arr, n));
        }

        // Returns length of the longest consecutive subsequence
        static int findLongestConseqSubseq(int[] arr, int n)
        {
            HashSet<int> S = new HashSet<int>();
            int ans = 0;

            // Hash all the array elements
            for (int i = 0; i < n; ++i)
                S.Add(arr[i]);

            // check each possible sequence from the start
            // then update optimal length
            for (int i = 0; i < n; ++i)
            {
                // if current element is the starting
                // element of a sequence
                if (!S.Contains(arr[i] - 1))
                {
                    // Then check for next elements in the
                    // sequence
                    int j = arr[i];
                    while (S.Contains(j))
                        j++;

                    // update  optimal length if this length
                    // is more
                    if (ans < j - arr[i])
                        ans = j - arr[i];
                }
            }
            return ans;
        }
    }
}

//http://www.geeksforgeeks.org/longest-consecutive-subsequence/