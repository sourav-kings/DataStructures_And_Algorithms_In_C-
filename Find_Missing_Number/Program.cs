using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Find_Missing_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 1, 2, 4, 5, 6 };
            int miss = getMissingNo(a, 5);
            Console.WriteLine(miss);
        }

        /* getMissingNo takes array and size of array as arguments*/
        static int getMissingNo(int[] a, int n)
        {
            int i;
            int x1 = a[0]; /* For xor of all the elements in array */
            int x2 = 1; /* For xor of all the elements from 1 to n+1 */

            for (i = 1; i < n; i++)
                x1 = x1 ^ a[i];

            for (i = 2; i <= n + 1; i++)
                x2 = x2 ^ i;

            return (x1 ^ x2);
        }
    }
}

//http://www.geeksforgeeks.org/find-the-missing-number/