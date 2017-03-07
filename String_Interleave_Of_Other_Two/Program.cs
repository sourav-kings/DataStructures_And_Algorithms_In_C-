using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Interleave_Of_Other_Two
{
    class Program
    {
        static void Main(string[] args)
        {
            test("XXY", "XXZ", "XXZXXXY");
            test("XY", "WZ", "WZXY");
            test("XY", "X", "XXY");
            test("YX", "X", "XXY");
            test("XXY", "XXZ", "XXXXZY");
            test("AB", "CD", "ACBG");
        }

        // A function to run test cases
        static void test(string A, string B, string C)
        {
            Console.WriteLine("Dynamic Programming Solution:-");
            if (isInterleavedDynamicProgramming(A, B, C))
                Console.WriteLine(C + " is interleaved of " + A + " and " + B);
            else
                Console.WriteLine(C + " is not interleaved of " + A + " and " + B);
        }

        // The main function that returns true if C is
        // an interleaving of A and B, otherwise false.
        static bool isInterleaved(string A, string B, string C)
        {
            // Find lengths of the two strings
            int M = A.Length, N = B.Length;

            // Let us create a 2D table to store solutions of
            // subproblems.  C[i][j] will be true if C[0..i+j-1]
            // is an interleaving of A[0..i-1] and B[0..j-1].
            bool[,] IL = new bool[M + 1, N + 1];


            //memset(IL, 0, sizeof(IL)); // Initialize all values as false.

            // C can be an interleaving of A and B only of sum
            // of lengths of A & B is equal to length of C.
            if ((M + N) != C.Length)
                return false;

            // Process all characters of A and B
            for (int i = 0; i <= M; ++i)
            {
                for (int j = 0; j <= N; ++j)
                {
                    // two empty strings have an empty string
                    // as interleaving
                    if (i == 0 && j == 0)
                        IL[i, j] = true;

                    // A is empty
                    else if (i == 0 && B[j - 1] == C[j - 1])
                        IL[i, j] = IL[i, j - 1];

                    // B is empty
                    else if (j == 0 && A[i - 1] == C[i - 1])
                        IL[i, j] = IL[i - 1, j];

                    // Current character of C matches with current character of A,
                    // but doesn't match with current character of B
                    else if (A[i - 1] == C[i + j - 1] && B[j - 1] != C[i + j - 1])
                        IL[i, j] = IL[i - 1, j];

                    // Current character of C matches with current character of B,
                    // but doesn't match with current character of A
                    else if (A[i - 1] != C[i + j - 1] && B[j - 1] == C[i + j - 1])
                        IL[i, j] = IL[i, j - 1];

                    // Current character of C matches with that of both A and B
                    else if (A[i - 1] == C[i + j - 1] && B[j - 1] == C[i + j - 1])
                        IL[i, j] = (IL[i - 1, j] || IL[i, j - 1]);
                }
            }

            return IL[M, N];
        }




        // Returns true if C is an interleaving of A and B,
        // otherwise returns false
        static bool isInterleavedDynamicProgramming(string A, string B, string C)
        {
            int x = 0, y = 0, z = 0;
            // Iterate through all characters of C.
            while (z < C.Length)
            {
                // Match first character of C with first character
                // of A. If matches them move A to next 
                if ((x < A.Length && z < C.Length) && (A[x] == C[z]))
                    x++;

                // Else Match first character of C with first 
                // character of B. If matches them move B to next 
                else if ((y < B.Length && z < C.Length) && (B[y] == C[z]))
                    y++;

                // If doesn't match with either A or B, then return
                // false
                else
                    return false;

                // Move C to next for next iteration
                z++;
            }

            // If A or B still have some characters, then length of
            // C  is smaller than sum of lengths of A and B, so 
            // return false
            if (A.Length > x || B.Length > y)
                return false;

            return true;
        }



        // A simple recursive function to check whether C is an interleaving of A and B
        //static bool isInterleavedRecursive(string A, string B, string C)
        //{
        //    // Base Case: If all strings are empty
        //    if ((A == "" || B == "" || C == ""))
        //        return true;

        //    // If C is empty and any of the two strings is not empty
        //    if (C == "" && (A != "" || B != ""))
        //        return false;

        //    // If any of the above mentioned two possibilities is true,
        //    // then return true, otherwise false
        //    //return ((C == A) && isInterleaved(A + 1, B, C + 1))
        //    //       || ((C == B) && isInterleaved(A, B + 1, C + 1));
        //}
    }
}
