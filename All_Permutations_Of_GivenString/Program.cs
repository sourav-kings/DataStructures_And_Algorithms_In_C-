using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_Permutations_Of_GivenString
{
    class Program
    {
        static void Main(string[] args)
        {
            String str = "ABCD";
            int n = str.Length;
            permute(str.ToCharArray(), 0, n - 1);
        }

        static void permute(char[] str, int l, int r)
        {
            if (l == r)
            {
                Console.WriteLine(str);
            }

            for (int i = l; i <= r; i++)
            {
                swap(str, l, i);
                permute(str, l + 1, r);
                swap(str, l, i);
            }
        }

        static void swap(char[] str, int i, int j)
        {
            char tmp = str[i];
            str[i] = str[j];
            str[j] = tmp;
        }
    }
}

//http://code.geeksforgeeks.org/H6Bs1h

//http://www.geeksforgeeks.org/write-a-c-program-to-print-all-permutations-of-a-given-string/