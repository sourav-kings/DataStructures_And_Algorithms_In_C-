using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicographically_Minimum_String_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(minLexRotation("GEEKSFORGEEKS"));
            Console.WriteLine(minLexRotation("GEEKSQUIZ"));
            Console.WriteLine(minLexRotation("BCABDADAB"));
        }

        // This functionr return lexicographically minimum
        // rotation of str
        static string minLexRotation(string str)
        {
            // Find length of given string
            int n = str.Length;

            // Create an array of strings to store all rotations
            string[] arr = new string[n];

            // Create a concatenation of string with itself
            string concat = str + str;

            // One by one store all rotations of str in array.
            // A rotation is obtained by getting a substring of concat
            for (int i = 0; i < n; i++)
                arr[i] = concat.Substring(i, n);

            // Sort all rotations
            Array.Sort(arr);

            // Return the first rotation from the sorted array
            return arr[0];
        }
    }
}

//http://quiz.geeksforgeeks.org/lexicographically-minimum-string-rotation/
//Average Difficulty : 3.1/5.0
//Based on 10 vote(s)
/*

Following is a simple solution. Let the given string be ‘str’
1) Concatenate ‘str’ with itself and store in a temporary string say ‘concat’.
2) Create an array of strings to store all rotations of ‘str’. Let the array be ‘arr’.
3) Find all rotations of ‘str’ by taking substrings of ‘concat’ at index 0, 1, 2..n-1. Store these rotations in arr[]
4) Sort arr[] and return arr[0]. 


 */
