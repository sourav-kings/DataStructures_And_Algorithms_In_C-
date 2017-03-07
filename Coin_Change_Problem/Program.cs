using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coin_Change_Problem
{
    class Program
    {
        static int[] coins;
        static void Main(string[] args)
        {
            int i, j;
            int[] arr = { 1, 2, 3 };
            coins = arr;
            int m = arr.Length;
            Console.WriteLine(count(coins.Length, 4));

            /*
             * It should be noted that the above function computes the same subproblems again and again. 
             * See the following recursion tree for S = {1, 2, 3} and n = 5.
             * The function C({1}, 3) is called two times. If we draw the complete tree, 
             * then we can see that there are many subproblems being called more than once.
             * Like other typical Dynamic Programming(DP) problems, recomputations of same subproblems 
             * can be avoided by constructing a temporary array table[][] in bottom up manner.
             */

            Console.WriteLine(countDynamicProgramming(coins.Length, 4));
        }

        // Returns the count of ways we can sum  S[0...m-1] coins to get sum n
        static int count(int n, int amount)
        {
            // If amount is 0 then there is 1 solution (do not include any coin)
            if (amount == 0)
                return 1;

            // If amount is less than 0 then no solution exists
            if (amount < 0)
                return 0;

            // If there are no coins and n is greater than 0, then no solution exist
            if (n < 1 && amount > 0)
                return 0;

            // count is sum of solutions (i) including coins[n-1] (ii) excluding coins[n-1]
            return count(n - 1, amount) + count(n, amount - coins[n - 1]);
        }

        static long countDynamicProgramming(int n, int amount)
        {
            //Time complexity of this function: O(mn)
            //Space Complexity of this function: O(n)

            // table[i] will be storing the number of solutions
            // for value i. We need n+1 rows as the table is
            // constructed in bottom up manner using the base
            // case (n = 0)
            long[] table = new long[amount + 1];

            // Initialize all table values as 0
            //Arrays.fill(table, 0);   //O(n)

            // Base case (If given value is 0)
            table[0] = 1;

            // Pick all coins one by one and update the table[]
            // values after the index greater than or equal to
            // the value of the picked coin
            for (int i = 0; i < n; i++)
                for (int j = coins[i]; j <= amount; j++)
                    table[j] += table[j - coins[i]];

            return table[amount];
        }
    }
}


//http://www.geeksforgeeks.org/dynamic-programming-set-7-coin-change/
//Average Difficulty : 3.5/5.0
//Based on 181 vote(s)