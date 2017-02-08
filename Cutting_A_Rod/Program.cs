using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cutting_A_Rod
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 5, 8, 9, 10, 17, 17, 20 };
            int size = arr.Length;
            Console.Write("Maximum Obtainable Value is " +
                                cutRod(arr, size));

            Console.Write("Maximum Obtainable Value is " +
                                cutRod_DynamicProgramming(arr, size));
            
        }

        /* Returns the best obtainable price for a rod of length
       n and price[] as prices of different pieces */
        static int cutRod(int[] price, int n)
        {
            if (n <= 0)
                return 0;
            int max_val = int.MinValue;

            // Recursively cut the rod in different pieces and
            // compare different configurations
            for (int i = 0; i < n; i++)
                max_val = Math.Max(max_val,
                                  price[i] + cutRod(price, n - i - 1));

            return max_val;
        }


        /* Returns the best obtainable price for a rod of
   length n and price[] as prices of different pieces */
        static int cutRod_DynamicProgramming(int[] price, int n)
        {
            int[] val = new int[n + 1];
            val[0] = 0;

            // Build the table val[] in bottom up manner and return
            // the last entry from the table
            for (int i = 1; i <= n; i++)
            {
                int max_val = int.MinValue;
                for (int j = 0; j < i; j++)
                    max_val = Math.Max(max_val,
                                       price[j] + val[i - j - 1]);
                val[i] = max_val;
            }

            return val[n];
        }
    }
}

//http://www.geeksforgeeks.org/dynamic-programming-set-13-cutting-a-rod/