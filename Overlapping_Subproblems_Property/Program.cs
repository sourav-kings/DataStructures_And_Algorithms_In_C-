using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overlapping_Subproblems_Property
{
    class Program
    {
        const int NIL = -1;
        const int MAX = 100;

        static int[] lookup = new int[MAX];

        static void Main(string[] args)
        {
            int n = 5;

            /*The slower recursion method*/
            Console.WriteLine(fib_Recursion(n));


            /*Memoization (Top Down):*/
            _initialize();
            Console.WriteLine(fib_Memoization(n));


            /*Tabulation (Bottom Up): */
            Console.WriteLine(fib_Tabulation(n));

        }

        /* simple recursive program for Fibonacci numbers */
        static int fib_Recursion(int n)
        {
            if (n <= 1)
                return n;
            return fib_Recursion(n - 1) + fib_Recursion(n - 2);
        }

        /* Function to initialize NIL values in lookup table */
        static void _initialize()
        {
            int i;
            for (i = 0; i < MAX; i++)
                lookup[i] = NIL;
        }

        /* function for nth Fibonacci number */
        static int fib_Memoization(int n)
        {
            if (lookup[n] == NIL)
            {
                if (n <= 1)
                    lookup[n] = n;
                else
                    lookup[n] = fib_Memoization(n - 1) + fib_Memoization(n - 2);
            }

            return lookup[n];
        }


        static int fib_Tabulation(int n)
        {
            int[] f = new int[n + 1];
            int i;
            f[0] = 0; f[1] = 1;
            for (i = 2; i <= n; i++)
                f[i] = f[i - 1] + f[i - 2];

            return f[n];
        }
    }
}

//http://www.geeksforgeeks.org/dynamic-programming-set-1/