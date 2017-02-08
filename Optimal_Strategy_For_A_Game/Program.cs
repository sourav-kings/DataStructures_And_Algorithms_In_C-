using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimal_Strategy_For_A_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = { 8, 15, 3, 7 };
            int n = arr1.Length;
            Console.WriteLine(optimalStrategyOfGame(arr1, n));

            int[] arr2 = { 2, 2, 2, 2 };
            n = arr2.Length;
            Console.WriteLine(optimalStrategyOfGame(arr2, n));

            int[] arr3 = { 20, 30, 2, 2, 2, 10 };
            n = arr3.Length;
            Console.WriteLine(optimalStrategyOfGame(arr3, n));
        }

        // Utility functions to get maximum and minimum of two intgers
        static int max(int a, int b) { return a > b ? a : b; }
        static int min(int a, int b) { return a < b ? a : b; }

        // Returns optimal value possible that a player can collect from
        // an array of coins of size n. Note than n must be even
        static int optimalStrategyOfGame(int[] arr, int n)
        {
            // Create a table to store solutions of subproblems
            int[,] table = new int[n, n];
            int gap, i, j, x, y, z;

            // Fill table using above recursive formula. Note that the table
            // is filled in diagonal fashion (similar to http://goo.gl/PQqoS),
            // from diagonal elements to table[0][n-1] which is the result.
            for (gap = 0; gap < n; ++gap)
            {
                for (i = 0, j = gap; j < n; ++i, ++j)
                {
                    // Here x is value of F(i+2, j), y is F(i+1, j-1) and
                    // z is F(i, j-2) in above recursive formula
                    x = ((i + 2) <= j) ? table[i + 2, j] : 0;
                    y = ((i + 1) <= (j - 1)) ? table[i + 1, j - 1] : 0;
                    z = (i <= (j - 2)) ? table[i, j - 2] : 0;

                    table[i, j] = Math.Max(arr[i] + min(x, y), arr[j] + min(y, z));
                }
            }

            return table[0, n - 1];
        }
    }
}

//http://www.geeksforgeeks.org/dynamic-programming-set-31-optimal-strategy-for-a-game/