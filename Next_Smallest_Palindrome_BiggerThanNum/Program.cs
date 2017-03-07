﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Next_Smallest_Palindrome_BiggerThanNum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num = { 9, 4, 1, 8, 7, 9, 7, 8, 3, 2, 2 };

            int n = num.Length;

            generateNextPalindrome(num, n);
        }


        // Returns next palindrome of a given number num[].
        // This function is for input type 2 and 3
        static void generateNextPalindromeUtil(int[] num, int n)
        {
            // find the index of mid digit
            int mid = n / 2;

            // A bool variable to check if copy of left side to right is sufficient or not
            bool leftsmaller = false;

            // end of left side is always 'mid -1'
            int i = mid - 1;

            // Begining of right side depends if n is odd or even
            int j = (n % 2 != 0) ? mid + 1 : mid;

            // Initially, ignore the middle same digits 
            while (i >= 0 && num[i] == num[j])
            {
                i--;j++;
            }

            // Find if the middle digit(s) need to be incremented or not (or copying left 
            // side is not sufficient)
            if (i < 0 || num[i] < num[j])
                leftsmaller = true;

            // Copy the mirror of left to tight
            while (i >= 0)
            {
                num[j] = num[i];
                j++;
                i--;
            }

            // Handle the case where middle digit(s) must be incremented. 
            // This part of code is for CASE 1 and CASE 2.2
            if (leftsmaller == true)
            {
                int carry = 1;
                i = mid - 1;

                // If there are odd digits, then increment
                // the middle digit and store the carry
                if (n % 2 == 1)
                {
                    num[mid] += carry;
                    carry = num[mid] / 10;
                    num[mid] %= 10;
                    j = mid + 1;
                }
                else
                    j = mid;

                // Add 1 to the rightmost digit of the left side, propagate the carry 
                // towards MSB digit and simultaneously copying mirror of the left side 
                // to the right side.
                while (i >= 0)
                {
                    num[i] += carry;
                    carry = num[i] / 10;
                    num[i] %= 10;
                    num[j++] = num[i--]; // copy mirror to right
                }
            }
        }

        // The function that prints next palindrome of a given number num[]
        // with n digits.
        static void generateNextPalindrome(int[] num, int n)
        {
            int i;

            Console.WriteLine("\nNext palindrome is:\n");

            // Input type 1: All the digits are 9, simply o/p 1
            // followed by n-1 0's followed by 1.
            if (AreAll9s(num, n))
            {
                Console.Write("1 ");
                for (i = 1; i < n; i++)
                    Console.Write("0 ");
                Console.Write("1");
            }

            // Input type 2 and 3
            else
            {
                generateNextPalindromeUtil(num, n);

                // print the result
                printArray(num, n);
            }
        }


        // A utility function to check if num has all 9s
        static bool AreAll9s(int[] num, int n)
        {
            int i;
            for (i = 0; i < n; ++i)
                if (num[i] != 9)
                    return false;
            return true;
        }

        /* Utility that prints out an array on a line */
        static void printArray(int[] arr, int n)
        {
            int i;
            for (i = 0; i < n; i++)
                Console.Write(arr[i] + " ");
            Console.Write("\n");
        }
    }
}

//http://www.geeksforgeeks.org/given-a-number-find-next-smallest-palindrome-larger-than-this-number/
//Average Difficulty : 4/5.0
//Based on 54 vote(s)