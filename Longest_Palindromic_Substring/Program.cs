using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longest_Palindromic_Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] str = "forgeeksskeegfor".ToCharArray();
            Console.WriteLine("\nLength is: " + longestPalSubstr(str));
            Console.WriteLine("\nLength is: " + longestPalSubstrSlimmer(str));
        }

        // A utility function to print a substring str[low..high]
        static void printSubStr(char[] str, int low, int high)
        {
            for (int i = low; i <= high; ++i)
                Console.Write(str[i] + " ");
        }

        // This function prints the longest palindrome substring
        // of str[].
        // It also returns the length of the longest palindrome
        static int longestPalSubstr(char[] str)
        {
            int n = str.Length; // get length of input string

            // table[i][j] will be false if substring str[i..j]
            // is not palindrome.
            // Else table[i][j] will be true
            bool[,] table = new bool[n, n];
            //memset(table, 0, sizeof(table));


            // All substrings of length 1 are palindromes
            int maxLength = 1;
            for (int i = 0; i < n; ++i)
                table[i, i] = true;

            // check for sub-string of length 2.
            int start = 0;
            for (int i = 0; i < n - 1; ++i)
            {
                if (str[i] == str[i + 1])
                {
                    table[i, i + 1] = true;
                    start = i;
                    maxLength = 2;
                }
            }

            // Check for lengths greater than 2. k is length
            // of substring
            for (int k = 3; k <= n; ++k)
            {
                // Fix the starting index
                for (int i = 0; i < n - k + 1; ++i)
                {
                    // Get the ending index of substring from
                    // starting index i and length k
                    int j = i + k - 1;

                    // checking for sub-string from ith index to
                    // jth index iff str[i+1] to str[j-1] is a
                    // palindrome
                    if (table[i + 1, j - 1] && str[i] == str[j])
                    {
                        table[i, j] = true;

                        if (k > maxLength)
                        {
                            start = i;
                            maxLength = k;
                        }
                    }
                }
            }


            Console.WriteLine("Longest palindrome substring is: ");
            printSubStr(str, start, start + maxLength - 1);

            return maxLength; // return length of LPS
        }

        // This function prints the longest palindrome substring (LPS)
        // of str[]. It also returns the length of the longest palindrome
        static int longestPalSubstrSlimmer(char[] str)
        {
            int maxLength = 1;  // The result (length of LPS)

            int start = 0;
            int len = str.Length;

            int low, high;

            // One by one consider every character as center point of 
            // even and length palindromes
            for (int i = 1; i < len; ++i)
            {
                // Find the longest even length palindrome with center points
                // as i-1 and i.  
                low = i - 1;
                high = i;
                while (low >= 0 && high < len && str[low] == str[high])
                {
                    if (high - low + 1 > maxLength)
                    {
                        start = low;
                        maxLength = high - low + 1;
                    }
                    --low;
                    ++high;
                }

                // Find the longest odd length palindrome with center 
                // point as i
                low = i - 1;
                high = i + 1;
                while (low >= 0 && high < len && str[low] == str[high])
                {
                    if (high - low + 1 > maxLength)
                    {
                        start = low;
                        maxLength = high - low + 1;
                    }
                    --low;
                    ++high;
                }
            }

            Console.WriteLine("Longest palindrome substring is: ");
            printSubStr(str, start, start + maxLength - 1);

            return maxLength;
        }
    }
}

/*
 http://www.geeksforgeeks.org/longest-palindrome-substring-set-1/ 
 The time complexity of the Dynamic Programming based solution is O(n^2) and it requires O(n^2) extra space
    
    Average Difficulty : 3.4/5.0
Based on 107 vote(s)





 http://www.geeksforgeeks.org/longest-palindromic-substring-set-2/
 We can find the longest palindrome substring in (n^2) time with O(1) extra space. 
 The idea is to generate all even length and odd length palindromes and keep track of the longest palindrome seen so far.

    Average Difficulty : 3.1/5.0
Based on 41 vote(s)





     */
