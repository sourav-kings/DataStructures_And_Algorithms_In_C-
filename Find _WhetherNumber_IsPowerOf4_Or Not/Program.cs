using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Find__WhetherNumber_IsPowerOf4_Or_Not
{
    class Program
    {
        static void Main(string[] args)
        {
            int test_no = 64;
            if (isPowerOfFour(test_no))
                Console.WriteLine(test_no + " is a power of 4");
            else
                Console.WriteLine(test_no + " is not a power of 4");


            if (isPowerOfFour_2ndMethod(test_no))
                Console.WriteLine(test_no + " is a power of 4");
            else
                Console.WriteLine(test_no + " is not a power of 4");
        }

        /* Function to check if x is power of 4*/
        static bool isPowerOfFour(int n)
        {
            if (n == 0)
                return false;
            while (n != 1)
            {
                if (n % 4 != 0)
                    return false;
                n = n / 4;
            }
            return true;
        }

        static bool isPowerOfFour_2ndMethod(int n)
        {
            int count = 0;

            /*Check if there is only one bit set in n*/
            //if (n && !(n & (n - 1)))
            if (n == (n & -n))
            {
                /* count 0 bits before set bit */
                while (n > 1)
                {
                    n >>= 1;
                    count += 1;
                }

                /*If count is even then return true else false*/
                return (count % 2 == 0) ? true : false;
            }

            /* If there are more than 1 bit set
              then n is not a power of 4*/
            return false;
        }
    }
}

//http://www.geeksforgeeks.org/find-whether-a-given-number-is-a-power-of-4-or-not/