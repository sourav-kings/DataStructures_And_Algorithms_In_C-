using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinSwaps_RequiredForArranging_PairsAdjacent_To_EachOther
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 3;
            int[] arr = new int[] { 3, 5, 6, 4, 1, 2 };
            int[] pairs = new int[] { -1, 3, 6, 1, 5, 4, 2 };
            int[] index = new int[2 * n + 1];
            for (int i = 0; i < 2 * n; i++)
            {
                index[arr[i]] = i;
            }
            Console.WriteLine(count(arr, pairs, index, n, 0));
        }

        private static int count(int[] arr, int[] pairs, int[] index, int n, int d)
        {
            if (n == 0) return 0;
            if (pairs[arr[d]] == arr[d + 1])
            {
                return count(arr, pairs, index, n - 1, d + 2);
            }
            int i = index[pairs[arr[d]]];
            swap(d + 1, i, arr);
            int a = count(arr, pairs, index, n - 1, d + 2);
            swap(d + 1, i, arr);
            int j = index[pairs[arr[d + 1]]];
            swap(d, j, arr);
            int b = count(arr, pairs, index, n - 1, d + 2);
            swap(d, j, arr);
            return 1 + Math.Min(a, b);
        }

        private static void swap(int i, int j, int[] arr)
        {
            int t = arr[i];
            arr[i] = arr[j];
            arr[j] = t;
        }
    }
}


//http://code.geeksforgeeks.org/VikuyB
//http://www.geeksforgeeks.org/minimum-number-of-swaps-required-for-arranging-pairs-adjacent-to-each-other/

//Average Difficulty : 4.5/5.0
//sBased on 77 vote(s)