﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longest_Palindromic_Subsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            String seq = "GEEKSFORGEEKS";
            int n = seq.Length;
            Console.WriteLine("The lnegth of the lps is " + lps(seq));
        }

        // Returns the length of the longest palindromic subsequence in seq
        static int lps(string seq)
        {
            int n = seq.Length;
            int i, j, cl;
            int[,] L = new int[n,n];  // Create a table to store results of subproblems
      
               // Strings of length 1 are palindrome of lentgh 1
               for (i = 0; i<n; i++)
                   L[i,i] = 1;
              
                // Build the table. Note that the lower diagonal values of table are
                // useless and not filled in the process. The values are filled in a
                // manner similar to Matrix Chain Multiplication DP solution (See
                // http://www.geeksforgeeks.org/archives/15553). cl is length of
                // substring
                for (cl=2; cl<=n; cl++)
                {
                    for (i=0; i<n-cl+1; i++)
                    {
                        j = i+cl-1;
                        if (seq[i] == seq[j] && cl == 2)
                           L[i,j] = 2;
                        else if (seq[i] == seq[j])
                           L[i,j] = L[i + 1,j - 1] + 2;
                        else
                           L[i,j] = max(L[i,j - 1], L[i + 1,j]);
                    }
                }
              
                return L[0,n - 1];
            }

        // A utility function to get max of two integers
        static int max(int x, int y) { return (x > y) ? x : y; }
    }
}

//http://www.geeksforgeeks.org/dynamic-programming-set-12-longest-palindromic-subsequence/
//https://www.youtube.com/watch?v=_nCsPn7_OgI&index=9&list=PLrmLmBdmIlpsHaNTPP_jHHDx_os9ItYXr
//https://github.com/mission-peace/interview/blob/master/src/com/interview/dynamic/LongestPalindromicSubsequence.java

//Average Difficulty : 3.3/5.0
//Based on 101 vote(s)