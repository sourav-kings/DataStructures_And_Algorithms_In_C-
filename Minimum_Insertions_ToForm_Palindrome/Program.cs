using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimum_Insertions_ToForm_Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "geeks";
            Console.WriteLine(findMinInsertions(str, 0, str.Length - 1));
            Console.WriteLine(findMinInsertionsDP(str, str.Length));
        }

        // A utility function to find minimum of two numbers
        static int min(int a, int b)
        { return a < b ? a : b; }

        // Recursive function to find minimum number of insersions
        static int findMinInsertions(string str, int l, int h)
        {
            // Base Cases
            if (l > h) return int.MaxValue;
            if (l == h) return 0;
            if (l == h - 1) return (str[l] == str[h]) ? 0 : 1;

            // Check if the first and last characters are same. On the basis of the
            // comparison result, decide which subrpoblem(s) to call
            return (str[l] == str[h]) ? findMinInsertions(str, l + 1, h - 1) :
                                       (min(findMinInsertions(str, l, h - 1),
                                           findMinInsertions(str, l + 1, h)) + 1);
        }

        // A DP function to find minimum number of insersions
        static int findMinInsertionsDP(string str, int n)
        {
            // Create a table of size n*n. table[i,j] will store
            // minumum number of insertions needed to convert str[i..j]
            // to a palindrome.
            int[,] table = new int[n, n]; int l, h, gap;

            // Initialize all table entries as 0
            //memset(table, 0, sizeof(table));

            // Fill the table
            for (gap = 1; gap < n; ++gap)
                for (l = 0, h = gap; h < n; ++l, ++h)
                    table[l, h] = (str[l] == str[h]) ? table[l + 1, h - 1] :
                                  (min(table[l, h - 1], table[l + 1, h]) + 1);

            // Return minimum number of insertions for str[0..n-1]
            return table[0, n - 1];
        }
    }
}


//http://www.geeksforgeeks.org/dynamic-programming-set-28-minimum-insertions-to-form-a-palindrome/
/*

 Good example to understand why to use dynamic programming and how overlapping subproblems happens in real time 
 problem.

    Average Difficulty : 3.7/5.0
Based on 40 vote(s)
*/
