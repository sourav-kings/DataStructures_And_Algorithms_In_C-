using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximum_And_Minimum_In_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1000, 11, 445, 1, 330, 3000 };
            minmax2(arr);
        }

        public static void minmax2(int[] a)
        {
            if (a == null || a.Length < 1)
                return;

            int min, max;

            // if only one element
            if (a.Length == 1)
            {
                max = a[0];
                min = a[0];
                Console.WriteLine("min: " + min + "\nmax: " + max);
                return;
            }

            if (a[0] > a[1])
            {
                max = a[0];
                min = a[1];
            }
            else
            {
                max = a[1];
                min = a[0];
            }

            for (int i = 2; i <= a.Length - 2;)
            {
                if (a[i] > a[i + 1])
                {
                    min = Math.Min(min, a[i + 1]);
                    max = Math.Max(max, a[i]);
                }
                else
                {
                    min = Math.Min(min, a[i]);
                    max = Math.Max(max, a[i + 1]);
                }

                i = i + 2;
            }

            if (a.Length % 2 == 1)
            {
                min = Math.Min(min, a[a.Length - 1]);
                max = Math.Max(max, a[a.Length - 1]);
            }

            Console.WriteLine("min: " + min + "\nmax: " + max);
        }
    }
}
//http://www.geeksforgeeks.org/maximum-and-minimum-in-an-array/

//http://www.programcreek.com/2014/02/find-min-max-in-an-array-using-minimum-comparisons/