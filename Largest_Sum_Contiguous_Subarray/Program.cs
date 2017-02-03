using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Largest_Sum_Contiguous_Subarray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { -2, -3, 4, -1, -2, 1, 5, -3 };
            int n = a.Length;
            int max_sum = maxSubArraySum(a, n);
            Console.WriteLine("Maximum contiguous sum is " + max_sum);
        }

        static int maxSubArraySum(int[] a, int size)
        {
            int max_so_far = a[0];
            int curr_max = a[0];

            for (int i = 1; i < size; i++)
            {
                curr_max = Math.Max(a[i], curr_max + a[i]);
                max_so_far = Math.Max(max_so_far, curr_max);
            }
            return max_so_far;
        }
    }
}
//http://www.geeksforgeeks.org/largest-sum-contiguous-subarray/