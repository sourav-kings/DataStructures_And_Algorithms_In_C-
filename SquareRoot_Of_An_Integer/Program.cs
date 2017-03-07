using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRoot_Of_An_Integer
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 11;
            Console.WriteLine(floorSqrt(x));
            Console.WriteLine(floorSqrtFaster(x)); 
        }

        // Returns floor of square root of x
        static int floorSqrt(int x)
        {
            // Base cases
            if (x == 0 || x == 1)
                return x;

            // Staring from 1, try all numbers until
            // i*i is greater than or equal to x.
            int i = 1, result = 1;
            while (result < x)
            {
                if (result == x)
                    return result;
                i++;
                result = i * i;
            }
            return i - 1;
        }

        public static int floorSqrtFaster(int x)
        {
            // Base Cases
            if (x == 0 || x == 1)
                return x;

            // Do Binary Search for floor(sqrt(x))
            int start = 1, end = x, ans = 0;
            while (start <= end)
            {
                int mid = (start + end) / 2;

                // If x is a perfect square
                if (mid * mid == x)
                    return mid;

                // Since we need floor, we update answer when mid*mid is
                // smaller than x, and move closer to sqrt(x)
                if (mid * mid < x)
                {
                    start = mid + 1;
                    ans = mid;
                }
                else   // If mid*mid is greater than x
                    end = mid - 1;
            }
            return ans;
        }
    }
}

//http://www.geeksforgeeks.org/square-root-of-an-integer/
/*
 * Average Difficulty : 2.2/5.0
Based on 46 vote(s)
 */
