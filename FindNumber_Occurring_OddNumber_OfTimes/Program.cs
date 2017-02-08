using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindNumber_Occurring_OddNumber_OfTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ar = new int[] { 2, 3, 5, 4, 5, 2, 4, 3, 5, 2, 4, 4, 2 };
            int n = ar.Length;
            Console.WriteLine(getOddOccurrence(ar, n));
        }

        static int getOddOccurrence(int[] ar, int ar_size)
        {
            int i;
            int res = 0;
            for (i = 0; i < ar_size; i++)
            {
                res = res ^ ar[i];
            }
            return res;
        }
    }
}

//http://www.geeksforgeeks.org/find-the-number-occurring-odd-number-of-times/