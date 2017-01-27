using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reach_Nth_Stairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int s = 4;
            Console.WriteLine("Number of ways = {0}", CountWays(s));
            Console.WriteLine("Number of generalised ways = {0}", CountGeneralisedWays(s));
        }

        // A simple recursive program to find n'th fibonacci number
        static int fib(int n)
        {
            if (n <= 1)
                return n;
            return fib(n - 1) + fib(n - 2);
        }

        // Returns number of ways to reach s'th stair
        static int CountWays(int s)
        {
            return fib(s + 1);
        }

        static int CountGeneralisedWays(int s)
        {
            return CountWaysUtil(s + 1);
        }

        // A recursive function used by countWays
        static int CountWaysUtil(int n)
        {
            if (n <= 1)
                return n;
            int res = 0;
            for (int i = 1; i <= m && i <= n; i++)
                res += CountWaysUtil(n - i);
            return res;
        }
    }
}
